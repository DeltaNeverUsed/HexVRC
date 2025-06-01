using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;
using File = System.IO.File;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Editor {
    public static class InstructionGenerator {
        public static string OutputFile => Application.dataPath + "/Magic/Runtime/Scripts/Instruction.cs";

        public static string GetTypeName(Type t) {
            if (!t.IsGenericType) return t.FullName.Replace('+', '.');
            if (t.IsNested && t.DeclaringType.IsGenericType) throw new NotImplementedException();
            string txt = t.FullName.Substring(0, t.FullName.IndexOf('`')) + "<";
            int cnt = 0;
            foreach (Type arg in t.GetGenericArguments()) {
                if (cnt > 0) txt += ", ";
                txt += GetTypeName(arg);
                cnt++;
            }

            return (txt + ">").Replace('+', '.');
        }

        private static string GetPath(Type instructionType) {
            return instructionType.GetField("Path", BindingFlags.Static | BindingFlags.Public)
                ?.GetRawConstantValue().ToString();
        }

        private static void GeneratePathMatch(StringBuilder result, Type instructionType) {
            string path = GetPath(instructionType);
            if (!path.Contains('*'))
                return;

            MethodInfo executionMethod = instructionType.GetMethods()
                .Where(m => string.Equals(m.Name, "Execute", StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault(m => m.GetParameters().Length == 1);

            if (executionMethod == null)
                return;

            result.Append("if (Path.StartsWith(\"");
            result.Append(path[..^1]);
            result.Append("\", StringComparison.InvariantCulture)) {");
            result.Append("return ");
            result.Append(GetTypeName(executionMethod.DeclaringType));
            result.Append(".Execute(info);\n");
            result.Append("}\n");
        }

        private static void GenerateCase(StringBuilder result, Type instructionType) {
            string path = GetPath(instructionType);
            if (path.Contains('*'))
                return;

            UnityEngine.Debug.Log($"Generating case for {instructionType.Name} with path {path}");

            List<MethodInfo> executionMethods = instructionType.GetMethods()
                .Where(m => string.Equals(m.Name, "Execute", StringComparison.OrdinalIgnoreCase)).ToList();

            SortedDictionary<int, List<MethodInfo>> methodParamCounts = new();
            
            foreach (MethodInfo method in executionMethods) {
                int paramCount = method.GetParameters().Length - 1;
                if (paramCount == 0)
                    paramCount = 99; // so that functions without any params always gets used last.
                if (!methodParamCounts.ContainsKey(paramCount))
                    methodParamCounts.Add(paramCount, new List<MethodInfo>() { method });
                else
                    methodParamCounts[paramCount].Add(method);
            }

            result.Append("case \"");
            result.Append(path);
            result.Append("\":\n");


            foreach (int paramCountTemp in methodParamCounts.Keys) {
                int paramCount = paramCountTemp;
                if (paramCount == 99)
                    paramCount = 0;
                if (paramCount > 0) {
                    result.Append("if (stackSize >= ");
                    result.Append(paramCount);
                    result.Append(") {\n");
                }

                List<string> paramNames = new List<string>();
                for (int i = 0; i < paramCount; i++) {
                    paramNames.Add($"_param_{i}");
                }

                for (int i = paramNames.Count - 1; i >= 0; i--) {
                    string paramName = paramNames[i];
                    result.Append("StackItem ");
                    result.Append(paramName);
                    result.Append(" = stack.Pop();\n");
                }

                List<MethodInfo> methods = methodParamCounts[paramCountTemp];
                for (int index = methods.Count - 1; index >= 0; index--) {
                    MethodInfo method = methods[index];
                    ParameterInfo[] parameters = method.GetParameters();
                    string resultName = $"__result_{instructionType.Name}_{index}";

                    if (parameters.Length == 1) {
                        result.Append("{\nExecutionState ");
                        result.Append(resultName);
                        result.Append(" = ");
                        result.Append(GetTypeName(method.DeclaringType));
                        result.Append(".Execute(info);\n");
                        result.Append("if (!");
                        result.Append(resultName);
                        result.Append(".Success) {\n");
                        result.Append("// Restore stack if execution failed\n");
                        foreach (string paramName in paramNames) {
                            result.Append("stack.Push(");
                            result.Append(paramName);
                            result.Append(");\n");
                        }

                        result.Append("}\n");
                        result.Append("return ");
                        result.Append(resultName);
                        result.Append(";\n}\n");
                        continue;
                    }

                    result.Append("if (");
                    for (int i = 0; i < paramNames.Count; i++) {
                        string paramName = paramNames[i];

                        if (i != 0)
                            result.Append(" && ");

                        if (parameters[i + 1].ParameterType == typeof(StackItem))
                            result.Append("true");
                        else {
                            result.Append(paramName);
                            result.Append(".Type == ItemType.");
                            result.Append(StackItem.GetItemType(parameters[i + 1].ParameterType).ToString());
                        }
                    }

                    result.Append(") {\n");
                    result.Append("ExecutionState ");
                    result.Append(resultName);
                    result.Append(" = ");
                    result.Append(GetTypeName(method.DeclaringType));
                    result.Append(".Execute(info");
                    for (int i = 0; i < paramNames.Count; i++) {
                        string paramName = paramNames[i];

                        result.Append(", (");
                        result.Append(GetTypeName(parameters[i + 1].ParameterType));
                        result.Append(')');
                        result.Append(paramName);
                        if (parameters[i + 1].ParameterType != typeof(StackItem))
                            result.Append(".Value");
                    }
                    
                    result.Append(");\nif (!");
                    result.Append(resultName);
                    result.Append(".Success) {\n");
                    
                    result.Append("// Restore stack if execution failed\n");
                    foreach (string paramName in paramNames) {
                        result.Append("stack.Push(");
                        result.Append(paramName);
                        result.Append(");\n");
                    }

                    result.Append("}\n");
                    result.Append("return ");
                    result.Append(resultName);
                    result.Append(";\n");

                    result.Append("}\n");
                }

                result.Append("// Restore stack if failed\n");
                foreach (string paramName in paramNames) {
                    result.Append("stack.Push(");
                    result.Append(paramName);
                    result.Append(");\n");
                }

                if (paramCount > 0)
                    result.Append("}\n");
            }

            result.Append(
                "return ExecutionState.Err(\"Not enough items on Stack for any matching execution function\");\n");
        }

        [MenuItem("Tools/Magic/Generators/Instruction")]
        public static void Generate() {
            StringBuilder result = new StringBuilder();

            result.Append(@"
using System;
using System.Collections.Generic;
using System.Text;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class Instruction {
        public readonly string Path;
        public readonly int GlyphId = -1;

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append(Path.ToString());
            sb.Append("":\n"");
            
            sb.Append(""  GlyphId: "");
            sb.Append(GlyphId.ToString());
            
            return sb.ToString();
        }

        public Instruction(string path) {
            Path = path;
        }

        public Instruction(string path, int glyphId) {
            GlyphId = glyphId;
            Path = path;
        }
        
        public ExecutionState Execute(ExecutionInfo info) {
            info.Path = Path;
            info.GlyphId = GlyphId;
            Stack<StackItem> stack = info.Stack;
            int stackSize = stack.Count;
            switch (Path) {
");
            List<Type> classes = Assembly.GetAssembly(typeof(PlayerVM))
                .GetTypes()
                .Where(t => t.IsClass && t.Namespace != null &&
                            t.Namespace.StartsWith("BefuddledLabs.Magic.Instructions")).ToList();
            foreach (Type c in classes)
                GenerateCase(result, c);

            result.Append(@"
            }");

            classes.Sort((c1, c2) => GetPath(c2).Length.CompareTo(GetPath(c1).Length));
            foreach (Type c in classes)
                GeneratePathMatch(result, c);

            result.Append(@"
            return ExecutionState.Err(""Path was not a valid instruction."");
        }
");

            result.Append(@"
    }
}
");

            File.WriteAllText(OutputFile, result.ToString());
        }
    }
}
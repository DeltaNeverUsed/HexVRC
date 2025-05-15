using UdonSharp;
using UnityEngine;
using Varneon.VUdon.Logger;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Debug.VUdon {
    public static class UdonConsoleExtensions {
        private static Transform GetHighestParent(this Transform startObject) {
            Transform currentObject = startObject;
            for (int i = 0; i < 10; i++) {
                if (!Utilities.IsValid(currentObject.parent))
                    break;
                currentObject = currentObject.parent;
            }

            return currentObject;
        }

        private static T GetComponentInChildrenOfHighestParent<T>(this Component startObject) {
            return startObject.transform.GetHighestParent().GetComponentInChildren<T>();
        }

        private static string GetCallerName(this UdonSharpBehaviour behaviour) {
            string basename = behaviour.GetUdonTypeName();
            string[] splits = basename.Split('.');

            string recombined = "<color=#C191FFFF>" + splits[0];
            for (int i = 1; i < splits.Length; i++) {
                if (i == splits.Length - 1)
                    return recombined + "</color>.<color=#D7AFFFFF>" + splits[i] + "</color>";
                recombined += "</color>.<color=#C191FFFF>" + splits[i];
            }

            return basename;
        }

        private static UdonConsole GetConsole(this UdonSharpBehaviour behaviour) {
            UdonConsole console = (UdonConsole)behaviour.GetProgramVariable("_console");
            if (console) return console;

            console = (UdonConsole)behaviour.GetProgramVariable("Console");
            if (console) return console;

            console = behaviour.GetComponentInChildrenOfHighestParent<UdonConsole>();

            if (console)
                console.LogWarning(
                    "<color=#D7AFFFFF>UdonConsoleExtensions</color>: Couldn't get console from object, searching object tree instead!");
            return console;
        }

        public static void Log(this UdonSharpBehaviour behaviour, object message, UdonConsole console = null) {
            string caller = behaviour.GetCallerName();
            if (!Utilities.IsValid(console)) {
                console = behaviour.GetConsole();
                if (!Utilities.IsValid(console)) {
                    UnityEngine.Debug.Log(caller + ": " + message);
                    return;
                }
            }

            console.Log(caller + ": " + message);
        }

        public static void LogError(this UdonSharpBehaviour behaviour, object message, UdonConsole console = null) {
            string caller = behaviour.GetCallerName();
            if (!Utilities.IsValid(console)) {
                console = behaviour.GetConsole();
                if (!Utilities.IsValid(console)) {
                    UnityEngine.Debug.LogError(caller + ": " + message);
                    return;
                }
            }

            console.LogError(caller + ": " + message);
        }

        public static void LogWarning(this UdonSharpBehaviour behaviour, object message, UdonConsole console = null) {
            string caller = behaviour.GetCallerName();
            if (!Utilities.IsValid(console)) {
                console = behaviour.GetConsole();
                if (!Utilities.IsValid(console)) {
                    UnityEngine.Debug.LogWarning(caller + ": " + message);
                    return;
                }
            }

            console.LogWarning(caller + ": " + message);
        }
    }
}
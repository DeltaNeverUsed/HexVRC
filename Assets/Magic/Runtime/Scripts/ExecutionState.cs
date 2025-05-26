// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class ExecutionState {
        public readonly string Error;
        public readonly bool Success;
        public int EarlyReturnDepth;

        public override string ToString() {
            if (Success)
                return "Success";
            return "Failed with error message: " + Error;
        }

        private ExecutionState() {
            Success = true;
            EarlyReturnDepth = 0;
        }
        
        private ExecutionState(int earlyReturn) {
            Success = true;
            EarlyReturnDepth = earlyReturn;
        }
        
        private ExecutionState(string error) {
            Error = error;
            Success = false;
            EarlyReturnDepth = 0;
        }
        
        public bool IsOk() => Success;

        public static ExecutionState Ok() {
            return new ExecutionState();
        }
        
        public static ExecutionState OkEarlyReturn(int depth) {
            return new ExecutionState(depth);
        }

        public static ExecutionState Err(string error) {
            return new ExecutionState(error);
        }
    }
}
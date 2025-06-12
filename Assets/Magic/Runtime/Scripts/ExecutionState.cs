// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public enum ExecutionError {
        Ok,
        Garbage,
        Halt,
        Paused,
        Busy
    }
    
    public class ExecutionState {
        public readonly string Error;
        public readonly ExecutionError Success;
        public int EarlyReturnDepth;

        public override string ToString() {
            if (Success == ExecutionError.Ok)
                return "Success";
            return "Failed with error message: " + Error;
        }

        private ExecutionState() {
            Success = ExecutionError.Ok;
            EarlyReturnDepth = 0;
        }
        
        private ExecutionState(int earlyReturn) {
            Success = ExecutionError.Ok;
            EarlyReturnDepth = earlyReturn;
        }
        
        private ExecutionState(string error, bool critical) {
            Error = error;
            Success = critical ? ExecutionError.Halt : ExecutionError.Garbage;
            EarlyReturnDepth = 0;
        }

        public ExecutionState(ExecutionError error, string message) {
            Success = error;
            Error = message;
        }
        
        public bool IsOk() => Success == ExecutionError.Ok;

        public static ExecutionState Ok() {
            return new ExecutionState();
        }
        
        public static ExecutionState OkEarlyReturn(int depth) {
            return new ExecutionState(depth);
        }

        public static ExecutionState Err(string error) {
            return new ExecutionState(error, false);
        }
        
        public static ExecutionState Critical(string error) {
            return new ExecutionState(error, true);
        }
    }
}
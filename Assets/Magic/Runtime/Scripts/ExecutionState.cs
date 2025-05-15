// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class ExecutionState {
        public readonly string Error;
        public readonly bool Success;

        public override string ToString() {
            if (Success)
                return "Success";
            return "Failed with error message: " + Error;
        }

        private ExecutionState() {
            Success = true;
        }
        
        private ExecutionState(string error) {
            Error = error;
            Success = false;
        }

        public static ExecutionState Ok() {
            return new ExecutionState();
        }

        public static ExecutionState Err(string error) {
            return new ExecutionState(error);
        }
    }
}
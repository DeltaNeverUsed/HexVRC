using UdonSharp;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class InputForwarder : UdonSharpBehaviour {
        public UdonSharpBehaviour target;

        public override void OnPickup() => target.SendCustomEvent("Pickup");
        public override void OnDrop() => target.SendCustomEvent("Drop");
        public override void OnPickupUseDown() => target.SendCustomEvent("PickupUseDown");
        public override void OnPickupUseUp() => target.SendCustomEvent("PickupUseUp");
    }
}
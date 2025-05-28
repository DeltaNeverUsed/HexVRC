using TMPro;
using UdonSharp;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class TimedMessageDisplayer : UdonSharpBehaviour {
        public TextMeshProUGUI text;
        
        public void Display(string message, float fadeInLength, float timeBeforeFadeOut, float fadeOutLength) {
            _fadeInLength = fadeInLength;
            _timeBeforeFadeOut = timeBeforeFadeOut;
            _fadeOutLength = fadeOutLength;
            text.text = message;
            FadeIn();
        }

        private float _fadeInLength;
        private float _timeBeforeFadeOut;
        private float _fadeOutLength;
        private float _timePassed;
        public void FadeIn() {
            _timePassed += Time.deltaTime;

            Color color = text.color;
            color.a = Mathf.Lerp(0, 1, _timePassed / _fadeInLength);
            text.color = color;

            if (color.a > 0.99) {
                _timePassed = 0;
                SendCustomEventDelayedSeconds(nameof(FadeOut), _timeBeforeFadeOut);
            }
            else
                SendCustomEventDelayedFrames(nameof(FadeIn), 1);
        }
        public void FadeOut() {
            _timePassed += Time.deltaTime;

            Color color = text.color;
            color.a = Mathf.Lerp(1, 0, _timePassed / _fadeOutLength);
            text.color = color;

            if (color.a < 0.01)
                Destroy(gameObject);
            else
                SendCustomEventDelayedFrames(nameof(FadeOut), 1);
        }
    }
}
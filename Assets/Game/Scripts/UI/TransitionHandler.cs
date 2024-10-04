namespace Dunnatello {
    
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public static class EasingFunctions {

        public static readonly Dictionary<string, Func<float, float>> functions = new() {
            ["easeIn"] = EasingFunctions.EaseIn,
            ["easeOut"] = EasingFunctions.EaseOut,
            ["easeInOut"] = EasingFunctions.EaseInOut,
        };

        public static float EaseIn(float t) => t * t;
        public static float EaseOut(float t) => 1 - (1 - t) * (1 - t);
        public static float EaseInOut(float t) {
            if (t < 0.5f)
                return 2 * t * t;
            else
                return -1 + (4 - 2 * t) * t;
        }

    }

    public class TransitionHandler : MonoBehaviour {

        public void TweenFillAmount(Image image, float target, float duration) {
            StartCoroutine(TweenFillCoroutine(image, target, duration));
        }

        public IEnumerator TweenFillCoroutine(Image image, float target, float duration) {

            if (target == 1) {
                image.fillAmount = 0;
                image.gameObject.SetActive(true);
            }

            float elapsedTime = 0;
            while (elapsedTime < duration) {

                float t = elapsedTime / duration;
                float easedT = EasingFunctions.EaseInOut(t);

                image.fillAmount = Mathf.Lerp(image.fillAmount, target, easedT);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            image.fillAmount = target;
        }

    }
}
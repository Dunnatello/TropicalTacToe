namespace Dunnatello.UI {
    using System.Collections;
    using UnityEngine;

    public class ButtonEffect : MonoBehaviour {

        private bool isHovering = false;

        private bool transitioning = false;

        public void Enter() {

            if (isHovering)
                return;

            if (transitioning)
                StopAllCoroutines();

            isHovering = true;
            StartCoroutine(TweenSize(Vector3.one * 1.05f, 0.25f));

        }

        public void Exit(bool instantTransition) {

            if (!isHovering)
                return;

            if (transitioning)
                StopAllCoroutines();

            if (instantTransition) {

                transform.localScale = Vector3.one;
                return;
            }


            StartCoroutine(TweenSize(Vector3.one, 0.25f));

        }

        private IEnumerator TweenSize(Vector3 newScale, float duration) {

            transitioning = true;

            float elapsedTime = 0f;

            while (elapsedTime < duration) {

                transform.localScale = Vector3.Lerp(transform.localScale, newScale, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;

            }

            transform.localScale = newScale;

            if (newScale == Vector3.one)
                isHovering = false;

            transitioning = false;

        }

    }

}
namespace Dunnatello {

    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class GameSpace : MonoBehaviour {

        [SerializeField] private int position = 0;

        public int Position { get { return position; } }


        public List<Image> icons = new();

        public GameManager gameManager;
        public TransitionHandler transitionHandler;

        public void ClaimSpace(int player) {
            transitionHandler.TweenFillAmount(icons[player], 1f, 0.25f);
        }

        public void Reset() {
            foreach (var icon in icons) { icon.gameObject.SetActive(false); };
        }
        public void ActivateSpace() {
            gameManager.ClaimSpace(position);
        }

    }
}
namespace Dunnatello {

    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class GameSpace : MonoBehaviour {

        [SerializeField] private int position = 0;

        public int Position { get { return position; } }


        public List<Image> icons = new();

        [SerializeField] private GameManager gameManager;
        [SerializeField] private TransitionHandler transitionHandler;

        [SerializeField] private Image selected;

        [SerializeField] private Color selectionAllowed;
        [SerializeField] private Color selectionDisabled;
        
        public void ClaimSpace(int player) {
            transitionHandler.TweenFillAmount(icons[player], 1f, 0.25f);
        }

        public void SelectSpace() {

            selected.gameObject.SetActive(true);
            Sprite currentPlayerIcon = gameManager.CurrentMode == GameMode.Cooperative ? icons[gameManager.CurrentPlayer].sprite : icons[0].sprite; // TODO: Replace with Current Player Icon
            selected.sprite = currentPlayerIcon;

            selected.color = gameManager.IsPlayerTurn && !gameManager.IsSpaceClaimed(position) ? selectionAllowed : selectionDisabled;

        }

        public void DeselectSpace() {
            selected.gameObject.SetActive(false);
        }

        public void Reset() {
            foreach (var icon in icons) { icon.gameObject.SetActive(false); };
        }
        public void ActivateSpace() {

            if (gameManager.IsPlayerTurn)
                gameManager.ClaimSpace(position);

        }

    }
}
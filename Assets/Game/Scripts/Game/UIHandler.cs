namespace Dunnatello {
    using System.Collections;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;

    public class UIHandler : MonoBehaviour {

        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private GameObject gameScreen;

        [SerializeField] private TextMeshProUGUI playerTurn;

        [SerializeField] private WinVisualizer winVisualizer;

        public void ToggleUI(bool isVisible) {
            gameScreen.SetActive(isVisible);
            gameOverScreen.SetActive(isVisible);
        }

        public void ShowGameScreen(bool shouldShow) {
            gameScreen.SetActive(shouldShow);
        }

        public void ShowEndScreen(bool shouldShow) {
            gameOverScreen.SetActive(shouldShow);

            if (!shouldShow)
                winVisualizer.HideAll();

        }

        public void UpdateUI(string currentPlayer) {

            playerTurn.text = $"{currentPlayer}'s Turn";

        }

    }
}
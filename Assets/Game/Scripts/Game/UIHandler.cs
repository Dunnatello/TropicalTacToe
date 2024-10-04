namespace Dunnatello {
    using System.Collections;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class UIHandler : MonoBehaviour {

        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private GameObject gameScreen;

        [SerializeField] private TextMeshProUGUI playerTurn;

        [SerializeField] private WinVisualizer winVisualizer;

        [SerializeField] private GameObject restartButton;
        [SerializeField] private EventSystem eventSystem;

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
            else
                eventSystem.SetSelectedGameObject(restartButton);

        }

        public void UpdateUI(string currentPlayer) {

            playerTurn.text = $"{currentPlayer}'s Turn";

        }

    }
}
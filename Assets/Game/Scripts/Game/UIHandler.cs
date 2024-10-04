namespace Dunnatello {
    using System.Collections;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;

    public class UIHandler : MonoBehaviour {

        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private GameObject gameScreen;

        [SerializeField] private TextMeshProUGUI playerTurn;


        public void ToggleUI(bool isVisible) {
            gameScreen.SetActive(isVisible);
            gameOverScreen.SetActive(isVisible);
        }

        public void ShowGameScreen(bool shouldShow) {
            gameScreen.SetActive(shouldShow);
        }

        public void ShowEndScreen(bool shouldShow) {
            gameOverScreen.SetActive(shouldShow);
        }

        public void UpdateUI(string currentPlayer) {

            playerTurn.text = $"{currentPlayer}'s Turn";

        }

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }
}
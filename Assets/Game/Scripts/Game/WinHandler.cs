namespace Dunnatello {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class WinHandler : MonoBehaviour {

        [SerializeField] private TextMeshProUGUI gameWinner;

        [SerializeField] private GameObject uiParticle;

        [SerializeField] private WinVisualizer winVisualizer;

        public void SetWinner(string winner, bool playerWon, UIHandler uiHandler, string winType = null, int winPosition = 0) {

            uiParticle.SetActive(playerWon);

            
            string resultMessage = playerWon ? $"{winner} wins!" : "Scratch!";
            gameWinner.text = resultMessage;

            if (playerWon) {
                StartCoroutine(OnGameEndCoroutine(winType, winPosition, uiHandler));
            }
            else {
                uiHandler.ShowEndScreen(true);
            }

        }

        public IEnumerator OnGameEndCoroutine(string winType, int winPosition, UIHandler uiHandler) {

            Debug.Log($"Showing Win: {winType} {winPosition}");

            winVisualizer.ShowWin(winType, winPosition);
            yield return new WaitForSeconds(winVisualizer.TransitionDuration * 2f);
            uiHandler.ShowEndScreen(true);
        }

    }
}
namespace Dunnatello {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class WinHandler : MonoBehaviour {

        [Header("UI")]
        [SerializeField] private TextMeshProUGUI gameWinner;
        [SerializeField] private GameObject uiParticle;

        [Header("Scripts")]
        [SerializeField] private WinVisualizer winVisualizer;

        [Header("Audio")]
        [SerializeField] private AudioSource gameWin;
        [SerializeField] private AudioSource gameLost;

        public void SetWinner(string winner, bool gameWon, bool playerWon, UIHandler uiHandler, string winType = null, int winPosition = 0) {

            uiParticle.SetActive(playerWon);

            if (playerWon)
                gameWin.Play();
            else
                gameLost.Play();


            string winText = winner == "You" ? "win" : "wins";
            string resultMessage = gameWon ? $"{winner} {winText}!" : "Scratch!";
            gameWinner.text = resultMessage;

            if (gameWon) {
                StartCoroutine(OnGameEndCoroutine(winType, winPosition, uiHandler));
            }
            else {
                uiHandler.ShowEndScreen(true);
            }

        }

        public IEnumerator OnGameEndCoroutine(string winType, int winPosition, UIHandler uiHandler) {

            winVisualizer.ShowWin(winType, winPosition);
            yield return new WaitForSeconds(winVisualizer.TransitionDuration * 2f);
            uiHandler.ShowEndScreen(true);
        }

    }
}
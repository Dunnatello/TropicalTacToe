namespace Dunnatello {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class WinHandler : MonoBehaviour {

        [SerializeField] private TextMeshProUGUI gameWinner;

        [SerializeField] private GameObject uiParticle;

        public void SetWinner(string winner, bool playerWon) {

            uiParticle.SetActive(playerWon);

            
            string resultMessage = playerWon ? $"{winner} wins!" : "Scratch!";
            gameWinner.text = resultMessage;

        }

        // Update is called once per frame
        void Update() {

        }
    }
}
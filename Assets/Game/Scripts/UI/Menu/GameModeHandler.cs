namespace Dunnatello {

    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;

    public class GameModeHandler : MonoBehaviour {

        [SerializeField] private TMP_Dropdown difficultyDropdown;

        // TODO: Move to Separate Class
        public Dictionary<string, GameMode> gameModes = new() {
            ["Cooperative"] = GameMode.Cooperative,
            ["Bot"] = GameMode.Bot,
            // More game modes here.
        };

        public void ResetBotDifficulty() {
            // Reset Bot Difficulty
            difficultyDropdown.value = 0;
            SetBotDifficulty(0);
        }

        public void SetBotDifficulty(int difficulty) {
            PlayerPrefs.SetInt("Difficulty", difficulty);
        }

        public void SetGameMode(string gameMode) {

            if (gameModes.ContainsKey(gameMode)) {
                PlayerPrefs.SetString("Mode", gameMode);
            }

        }

    }

}
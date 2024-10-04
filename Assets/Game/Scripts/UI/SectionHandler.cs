namespace Dunnatello {
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class SectionHandler : MonoBehaviour {
        [System.Serializable]
        public class Section {
            public string name;
            public GameObject section;
            public GameObject firstButton;
        }

        [SerializeField] private List<Section> sections = new();

        [SerializeField] private TMP_Dropdown difficultyDropdown;
        [SerializeField] private EventSystem eventSystem;

        // TODO: Move to Separate Class
        public Dictionary<string, GameMode> gameModes = new() {
            ["Cooperative"] = GameMode.Cooperative,
            ["Bot"] = GameMode.Bot,
            // More game modes here.
        };

        private void Start() {
            GoToSection("Menu");
        }

        public void GoToSection(string sectionName) {

            foreach (Section section in sections) {
               
                bool showSection = section.name.Equals(sectionName);
                section.section.SetActive(showSection);

                if (showSection)
                    eventSystem.SetSelectedGameObject(section.firstButton);

            }

        }

        public void SetGameMode(string gameMode) {

            if (gameModes.ContainsKey(gameMode)) {
                PlayerPrefs.SetString("Mode", gameMode);

                if (gameMode == "Bot") {
                    // Reset Bot Difficulty
                    difficultyDropdown.value = 0;
                    SetBotDifficulty(0);

                }

            }

        }

        public void SetBotDifficulty(int difficulty) {
            Debug.Log($"Setting Bot Difficulty: {difficulty}");
            PlayerPrefs.SetInt("Difficulty", difficulty);
        }

    }

}
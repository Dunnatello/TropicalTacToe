namespace Dunnatello.UI {
    
    using Dunnatello.AI;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class GetBotList : MonoBehaviour {

        [SerializeField] private BotManager botManager;
        [SerializeField] private TMP_Dropdown dropdown;

        private void Start() {
            PopulateDropdown();
        }

        private void PopulateDropdown() {

            dropdown.ClearOptions();

            List<string> botNames = new();
            foreach (var bot in botManager.bots) {
                botNames.Add(bot.displayName);
            }

            dropdown.AddOptions(botNames);
            dropdown.value = 0;

        }

    }
}
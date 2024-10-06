namespace Dunnatello.UI {
    using Dunnatello.AI;

    
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class SetBotInfo : MonoBehaviour {

        [SerializeField] private BotManager botManager;

        [SerializeField] private TextMeshProUGUI botName;
        [SerializeField] private Image thumbnail;
        [SerializeField] private Image background;

        [SerializeField] private Sprite defaultSprite;

        [Header("Bot Stats")]
        [SerializeField] private TextMeshProUGUI randomness;
        [SerializeField] private TextMeshProUGUI mistakeChance;
        [SerializeField] private TextMeshProUGUI maxDepth;
        [SerializeField] private TextMeshProUGUI reactionTime;

        private readonly string statTitleColor = "#E5E5E5";

        private void Start() {
            SelectBot(0);
        }

        public void SelectBot(int botId) {

            // Get Bot
            botId = Mathf.Clamp(botId, 0, botManager.bots.Count - 1);
            Bot bot = botManager.bots[botId];

            // Set Bot Appearance
            botName.text = bot.displayName;
            thumbnail.sprite = (bot.botThumbnail != null) ? bot.botThumbnail : defaultSprite;
            background.color = bot.botBackgroundColor;

            // Set Bot Stats
            randomness.text = $"<color={statTitleColor}>Randomness</color>\n{(int) (bot.randomness * 100)}%";
            mistakeChance.text = $"<color={statTitleColor}>Mistake Chance</color>\n{(int) (bot.mistakeChance * 100)}%";
            
            maxDepth.text = $"<color={statTitleColor}>Lookahead</color>\n{bot.maxDepth / 2} moves";
            reactionTime.text = $"<color={statTitleColor}>Reaction Time</color>\n{bot.reactionTime.min}s to {bot.reactionTime.max}s";

        }

    }

}
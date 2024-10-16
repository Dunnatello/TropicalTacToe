namespace Dunnatello {
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class PlayerHandler : MonoBehaviour {

        [System.Serializable]
        public class PlayerView {
            public TextMeshProUGUI playerName;
            public TextMeshProUGUI playerTurn;
            public Image playerIcon;
            public Image spaceIcon;
            public Image background;
            public GameObject botTag;
        }

        [SerializeField] private List<PlayerView> players = new();

        [System.Serializable]
        public class StringSpritePair {
            public string key;
            public Sprite value;
        }

        [SerializeField] private List<StringSpritePair> sprites = new();

        [SerializeField] private List<Sprite> gameSpaceIcons = new();

        [Header("Player Colors")]
        [SerializeField] private Color regular;
        [SerializeField] private Color active;


        public void SetActivePlayer(int playerId) {

            for (int i = 0; i < players.Count; i++) {
                
                PlayerView player = players[i];
                //player.playerName.color = playerId.Equals(i) ? active : regular;
                player.playerTurn.gameObject.SetActive(playerId.Equals(i));
                
            }

        }

        public void SetPlayerDetails(int playerId, string playerName, Color customColor, string spriteIcon = "Player", int spaceIcon = 0, Sprite customIcon = null, bool isBot = false) {
            
            
            // Get Player View
            PlayerView playerView;
            if (playerId > players.Count)
                playerView = players.Last();
            else
                playerView = players[playerId];

            // Set Player Name
            playerView.playerName.text = playerName;

            // Set Bot Tag
            playerView.botTag.SetActive(isBot);

            // Set Player Turn Info
            playerView.playerTurn.text = spriteIcon == "Bot" ? "Their Turn" : "Your Turn"; // TODO: Use Game Mode Check
            playerView.playerTurn.gameObject.SetActive(false);

            // Set Player Game Space Icon
            playerView.spaceIcon.sprite = gameSpaceIcons[spaceIcon];

            // Set Player Icon
            var sprite = customIcon != null ? customIcon : sprites.Find(pair => pair.key.Equals(spriteIcon))?.value;

            if (sprite != null) {
                playerView.playerIcon.sprite = sprite;
            }

            // Set Background Color
            playerView.background.color = customColor;

        }

    }
}
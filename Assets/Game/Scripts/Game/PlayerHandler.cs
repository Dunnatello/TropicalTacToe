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
            public Image playerIcon;
        }

        [SerializeField] private List<PlayerView> players = new();

        [System.Serializable]
        public class StringSpritePair {
            public string key;
            public Sprite value;
        }

        [SerializeField] private List<StringSpritePair> sprites = new();

        [Header("Player Colors")]
        [SerializeField] private Color regular;
        [SerializeField] private Color active;

        public void SetActivePlayer(int playerId) {

            for (int i = 0; i < players.Count; i++) {
                
                PlayerView player = players[i];
                player.playerName.color = playerId.Equals(i) ? active : regular;

            }

        }

        public void SetPlayerDetails(int playerId, string playerName, string spriteIcon = "Player") {
            
            // Get Player View
            PlayerView playerView;
            if (playerId > players.Count)
                playerView = players.Last();
            else
                playerView = players[playerId];

            // Set Player Name
            playerView.playerName.text = playerName;

            // Set Player Icon
            var sprite = sprites.Find(pair => pair.key.Equals(spriteIcon));

            if (sprite != null) {
                playerView.playerIcon.sprite = sprite.value;
            }

        }

    }
}
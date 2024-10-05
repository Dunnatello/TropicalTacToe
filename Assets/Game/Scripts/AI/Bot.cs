namespace Dunnatello.AI {

    using Dunnatello;
    using UnityEngine;

    [System.Serializable]
    [CreateAssetMenu(fileName = "New Bot", menuName = "Dunnatello/AI/Bot", order = 1)]
    public class Bot : ScriptableObject {
        public string displayName = "Bot";
        public Sprite botThumbnail;
        public Color botBackgroundColor = new(38f / 255f, 77f / 255f, 115f / 255f); // Dark blue default.
        public int maxDepth = 0;
        public float randomness = 0f;
        public float mistakeChance = 0f;
        public FloatRange reactionTime;
    }

}
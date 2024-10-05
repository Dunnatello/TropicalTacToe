namespace Dunnatello {
    using UnityEngine;

    public class ResetDifficultyOnAwake : MonoBehaviour {
        [SerializeField] private GameModeHandler gameModeHandler;
        private void Awake() {
            gameModeHandler.ResetBotDifficulty();
        }
    }

}
namespace Dunnatello {

    [System.Serializable]
    public class BoardItem {

        public GameSpace gameSpace;
        private int claimedByPlayer = -1;

        public BoardItem(GameSpace gameSpace) {
            this.gameSpace = gameSpace;
            claimedByPlayer = -1;
        }

        public int CurrentPlayer { get { return claimedByPlayer; } set { claimedByPlayer = value; } }

        public void Reset() {
            gameSpace.Reset();
            claimedByPlayer = -1;
        }

        public bool ClaimSpace(int player) {
            if (claimedByPlayer == -1) {
                claimedByPlayer = player;
                gameSpace.ClaimSpace(player);
                return true;
            }
            else
                return false;

        }

    }

}
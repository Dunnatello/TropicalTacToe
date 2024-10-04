namespace Dunnatello {
    using System.Collections;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;

    public class GameManager : MonoBehaviour {


        [System.Serializable]
        public class BoardItem {

            public SpaceHandler spaceHandler;
            private int claimedByPlayer = -1;

            public BoardItem(SpaceHandler spaceHandler) {
                this.spaceHandler = spaceHandler;
                claimedByPlayer = -1;
            }

            public int CurrentPlayer { get { return claimedByPlayer; } }

            public void Reset() {
                spaceHandler.Reset();
                claimedByPlayer = -1;
            }

            public bool ClaimSpace(int player) {
                if (claimedByPlayer == -1) {
                    claimedByPlayer = player;
                    spaceHandler.ClaimSpace(player);
                    return true;
                }
                else
                    return false;

            }

        }

        private int currentPlayer = 0;
        private bool gameCompleted = false;

        private List<BoardItem> board = new();

        [SerializeField] private Transform boardContainer;
        [SerializeField] private TextMeshProUGUI playerTurn;


        private int currentGridSize = 3;

        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private GameObject gameScreen;
        [SerializeField] private TextMeshProUGUI gameWinner;

        // Start is called before the first frame update
        void Start() {
            gameScreen.SetActive(false);
            LoadGame();

        }

        private void LoadGame() {

            board.Clear();
            SpaceHandler[] spaces = boardContainer.GetComponentsInChildren<SpaceHandler>();

            foreach (var spaceHandler in spaces) {
                board.Add(new(spaceHandler));
            }

            board.Sort((a, b) => a.spaceHandler.Position.CompareTo(b.spaceHandler.Position));
            StartGame();
        }


        public void Quit() {
            Application.Quit();
        }

        private void StartGame() {
            currentPlayer = 0;
            UpdateUI();
            gameCompleted = false;
            gameScreen.SetActive(true);
        }

        private void UpdateUI() {

            string playerName = currentPlayer == 0 ? "Player" : "Computer";
            playerTurn.text = $"{playerName}'s Turn";

        }

        public void ClaimSpace(int position) {

            if (gameCompleted)
                return;

            if (position < 0 || position >= board.Count) {
                Debug.LogWarning($"Position out of range: {position}");
                return;
            }

            BoardItem item = board[position];
            bool claimedSpace = item.ClaimSpace(currentPlayer);

            if (claimedSpace) {
                EndTurn();

            }

        }

        public void EndTurn() {

            bool isGameOver = CheckBoard(currentGridSize);

            if (!isGameOver) {
                currentPlayer = currentPlayer == 0 ? 1 : 0;
                UpdateUI();
            } else {
                GameOver();
            }

        }

        public void GameOver() {
            gameCompleted = true;
            Debug.Log("GAME OVER");
            //gameScreen.SetActive(false);
            gameOverScreen.SetActive(true);
            
        }

        public void SetWinner(int winner) {

            string playerName = winner == 0 ? "Player" : "Computer";
            gameWinner.text = $"{playerName} wins!";

        }

        public bool CheckBoard(int gridSize) {

            if (CheckWin(gridSize, out int winner)) {
                Debug.Log($"Player {winner} wins!");
                SetWinner(winner);
                return true;
            }

            return false;
        }

        public void Restart() {
            gameOverScreen.SetActive(false);

            foreach (var space in board) {
                space.Reset();
            }
            StartGame();

        }

        public bool CheckWin(int gridSize, out int winner) {

            // Check Rows & Columns
            for (int i = 0; i < gridSize; i++) {

                // Check Row Win
                if (CheckLine(i * gridSize, 1, gridSize)) {
                    winner = board[i * gridSize].CurrentPlayer;
                    return true;
                }

                // Check Column Win
                if (CheckLine(i, gridSize, gridSize)) {
                    winner = board[i].CurrentPlayer;
                    return true;
                }

            }


            // Check Diagonal Wins
            if (CheckLine(0, gridSize + 1, gridSize)) {
                winner = board[0].CurrentPlayer;
                return true;
            }

            if (CheckLine(gridSize - 1, gridSize - 1, gridSize)) {
                winner = board[gridSize - 1].CurrentPlayer;
                return true;
            }

            winner = -1;
            return false;
        }

        public bool CheckLine(int startIndex, int step, int gridSize) {

            int currentPlayer = board[startIndex].CurrentPlayer;
            if (currentPlayer == -1) return false;

            for (int i = 1; i < gridSize; i++) {
                if (board[startIndex + i * step].CurrentPlayer != currentPlayer) return false;
            }

            return true;
        }


    }
}
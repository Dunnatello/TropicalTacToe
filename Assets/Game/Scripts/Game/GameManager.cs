namespace Dunnatello {
    using Dunnatello.AI;
    using Dunnatello.Audio;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public enum GameMode {
        Cooperative,
        Bot,
    }

    [System.Serializable]
    public class FloatRange {
        public float min = 0.1f;
        public float max = 1f;
    }



    public partial class GameManager : MonoBehaviour {

        // Game Variables
        private int currentPlayer = 0;
        private bool gameCompleted = false;
        private int spacesFilled = 0;
        [SerializeField] private int currentGridSize = 3;

        [SerializeField] private int currentBot = 0;
        [SerializeField] private BotManager botManager;

        private readonly List<BoardItem> board = new();

        // TODO: Remove Serialization Later
        [SerializeField] private GameMode gameMode = GameMode.Cooperative;

        public bool IsPlayerTurn { get { return gameMode == GameMode.Cooperative || gameMode == GameMode.Bot && currentPlayer == 0; } }
        public int CurrentPlayer { get { return currentPlayer; } }
        public GameMode CurrentMode => gameMode;

        // References
        [SerializeField] private Transform boardContainer;

        [SerializeField] private UIHandler uiHandler;
        [SerializeField] private WinHandler winHandler;
        [SerializeField] private PlayerHandler playerHandler;

        [SerializeField] private EventSystem eventSystem;

        [SerializeField] private PlayRandomPitch placementSound;

        private string winType;
        private int winPosition;

        private Color defaultColor = new(38f / 255f, 77f / 255f, 115f / 255f);

        // Start is called before the first frame update
        void Start() {

            uiHandler.ToggleUI(false);

            
            // Get Game Mode
            string newGameMode = PlayerPrefs.GetString("Mode") ?? "Bot";
            gameMode = newGameMode == "Bot" ? GameMode.Bot : GameMode.Cooperative;

            // Get Current Bot Difficulty
            if (gameMode == GameMode.Bot)
                currentBot = PlayerPrefs.GetInt("Difficulty");

            // Show Player Details
            playerHandler.SetPlayerDetails(0, GetPlayerName(0), defaultColor, "Player"); // Results in a white color

            bool isBot = gameMode == GameMode.Bot;

            if (isBot) {
                
                Bot activeBot = botManager.bots[currentBot];
                playerHandler.SetPlayerDetails(1, activeBot.displayName, activeBot.botBackgroundColor, "Bot", 1, activeBot.botThumbnail, true);

            }
            else {
                playerHandler.SetPlayerDetails(1, GetPlayerName(1), defaultColor, "Player", 1);
            }
            

            LoadGame();

        }

        private void LoadGame() {

            board.Clear();
            GameSpace[] spaces = boardContainer.GetComponentsInChildren<GameSpace>();

            foreach (var spaceHandler in spaces) {
                board.Add(new(spaceHandler));
            }

            board.Sort((a, b) => a.gameSpace.Position.CompareTo(b.gameSpace.Position));
            StartGame();
        }

        private void StartGame() {
            spacesFilled = 0;
            currentPlayer = 0;

            eventSystem.SetSelectedGameObject(board[0].gameSpace.gameObject);

            playerHandler.SetActivePlayer(currentPlayer);

            uiHandler.UpdateUI(GetPlayerName(currentPlayer));

            gameCompleted = false;

            uiHandler.ShowGameScreen(true);
        }

        public bool IsSpaceClaimed(int position) {

            if (position < 0 || position > board.Count - 1) return true;

            return board[position].CurrentPlayer != -1;

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
                spacesFilled++;
                EndTurn();
                placementSound.Play();
            }

        }

        public void EndTurn() {

            bool isGameOver = CheckBoard(currentGridSize);

            if (!isGameOver) {
                currentPlayer = currentPlayer == 0 ? 1 : 0;
                uiHandler.UpdateUI(GetPlayerName(currentPlayer));

                playerHandler.SetActivePlayer(currentPlayer);

                if (gameMode == GameMode.Bot && currentPlayer == 1 && !gameCompleted) {

                    StartCoroutine(HandleBotMove());

                }

            } else {
                GameOver();
            }

        }

        public IEnumerator HandleBotMove() {

            Bot bot = botManager.bots[currentBot];

            int bestMove = GetBestMove(bot);

            // Artificial Delay to Emulate Thinking
            yield return new WaitForSeconds(Random.Range(bot.reactionTime.min, bot.reactionTime.max));
            ClaimSpace(bestMove);

        }

        public void GameOver() {

            foreach (BoardItem item in board) {
                item.gameSpace.DeselectSpace();
            }
            
            gameCompleted = true;
        }



        public string GetPlayerName(int player) {

            if (player == -1)
                return string.Empty;

            if (gameMode == GameMode.Bot) {
                return (player == 1) ? botManager.bots[currentBot].displayName : "You";
            } else {
                return $"Player {player + 1}";
            }
        }

        public bool CheckBoard(int gridSize) {

            if (CheckWin(gridSize, out int winner)) {

                winHandler.SetWinner(GetPlayerName(winner), winner != -1,
                    (winner != -1 && gameMode == GameMode.Cooperative) || (winner == 0 && gameMode == GameMode.Bot), 
                    uiHandler, winType, winPosition);

                return true;
            }

            if (spacesFilled >= board.Count) {
                winHandler.SetWinner(GetPlayerName(-1), false, false, uiHandler);
                return true;
            }

            return false;
        }

        public void Restart() {

            uiHandler.ShowEndScreen(false);

            foreach (var space in board) {
                space.Reset();
            }
            StartGame();

        }
        
        public int ConvertWinResult(int winner) {
            return winner switch {
                1 => 1, // Bot Wins
                0 => -1, // Player Wins
                _ => 0, // Draw
            };
        }

        public bool CheckWin(int gridSize, out int winner) {

            // Check Rows & Columns
            for (int i = 0; i < gridSize; i++) {

                // Check Row Win
                if (CheckLine(i * gridSize, 1, gridSize)) {
                    winner = board[i * gridSize].CurrentPlayer;
                    winType = "Horizontal";
                    winPosition = i;
                    return true;
                }

                // Check Column Win
                if (CheckLine(i, gridSize, gridSize)) {
                    winType = "Vertical";
                    winPosition = i;
                    winner = board[i].CurrentPlayer;
                    return true;
                }

            }

            // Check Diagonal Wins
            if (CheckLine(0, gridSize + 1, gridSize)) {
                winType = "Diagonal";
                winPosition = 0;
                winner = board[0].CurrentPlayer;
                return true;
            }

            if (CheckLine(gridSize - 1, gridSize - 1, gridSize)) {
                winType = "Diagonal";
                winPosition = 1;
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
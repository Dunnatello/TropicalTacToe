namespace Dunnatello {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Rendering;

    public partial class GameManager {

        public int GetBestMoveWithMistakes(BotStats bot) {
            int bestScore = int.MinValue;
            List<int> possibleMoves = new();
            int move = -1;

            // Iterate through the entire board.
            for (int i = 0; i < board.Count; i++) {

                // Space available to claim
                if (board[i].CurrentPlayer == -1) {

                    board[i].CurrentPlayer = 1;
                    spacesFilled++;

                    int score = Minimax(false, bot.maxDepth);

                    // Undo Move
                    board[i].CurrentPlayer = -1;
                    spacesFilled--;

                    possibleMoves.Add(i);

                    // Track Best Move
                    if (score > bestScore) {
                        bestScore = score;
                        move = i;
                    }

                }

            }

            // Introduce Randomness
            if (Random.value < bot.randomness) {
                // Pick Random Move
                return possibleMoves[Random.Range(0, possibleMoves.Count)];
            }

            // Mistake Chance
            if (Random.value < bot.mistakeChance) {
                return possibleMoves[Random.Range(0, possibleMoves.Count)];
            }

            // Return Best Move
            return move;

        }

        public int Minimax(bool isMaximizing, int depth) {

            // Limit bot depth to reduce difficulty.
            if (CheckWin(currentGridSize, out int winner) || depth == 0) {
                return ConvertWinResult(winner);
            }

            if (spacesFilled >= board.Count) {
                return 0; // Draw
            }

            if (isMaximizing) {

                int bestScore = int.MinValue;
                for (int i = 0; i < board.Count; i++) {

                    if (board[i].CurrentPlayer == -1) {

                        board[i].CurrentPlayer = 1;
                        spacesFilled++;

                        int score = Minimax(false, depth - 1);
                        bestScore = Mathf.Max(score, bestScore);

                        board[i].CurrentPlayer = -1;
                        spacesFilled--;
                    }
                }

                return bestScore;

            } else {


                int bestScore = int.MaxValue;
                for (int i = 0; i < board.Count; i++) {

                    if (board[i].CurrentPlayer == -1) {

                        board[i].CurrentPlayer = 0;
                        spacesFilled++;

                        int score = Minimax(true, depth - 1);
                        bestScore = Mathf.Min(score, bestScore);

                        board[i].CurrentPlayer = -1;
                        spacesFilled--;
                    }
                }

                return bestScore;

            }

        }

    }

}
namespace Dunnatello {
    
    using Dunnatello.AI;
    using System.Collections.Generic;
    using UnityEngine;

    public partial class GameManager {

        public int GetBestMove(Bot bot) {
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
                return ConvertWinResult(winner); // Converts return result from [0: Player 1 Win, 1: AI Win, -1: Draw] to [0: Draw, 1: AI Win, -1: Player Win]
            }

            if (spacesFilled >= board.Count) {
                return 0; // Draw
            }

            int bestScore = isMaximizing ? int.MinValue : int.MaxValue;

            // Loop Through All Board Positions
            for (int i = 0; i < board.Count; i++) {

                // Available Space
                if (board[i].CurrentPlayer == -1) {

                    // Claim Space
                    board[i].CurrentPlayer = isMaximizing ? 1 : 0;
                    spacesFilled++;

                    // Recursive Call: Alternate Between Maximizing & Minimizing
                    int score = Minimax(!isMaximizing, depth - 1);

                    bestScore = isMaximizing ? Mathf.Max(score, bestScore) : Mathf.Min(score, bestScore);

                    // Undo Move
                    board[i].CurrentPlayer = -1;
                    spacesFilled--;
                }
            }

            return bestScore;

        }

    }

}
namespace Dunnatello {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class WinVisualizer : MonoBehaviour {

        [Header("UI")]
        [SerializeField] private List<Image> horizontalWins = new();
        [SerializeField] private List<Image> verticalWins = new();
        [SerializeField] private List<Image> diagonalWins = new();

        [Header("Scripts")]
        [SerializeField] private TransitionHandler transitionHandler;

        public float TransitionDuration { get; private set; } = 1f;

        public void ShowWin(string direction, int winPosition) {
            
            Image winResult = direction switch {
                "Horizontal" => horizontalWins[winPosition],
                "Vertical" => verticalWins[winPosition],
                _ => diagonalWins[winPosition],
            };
            
            transitionHandler.TweenFillAmount(winResult, 1f, TransitionDuration);
            
        }

        public void HideAll() {

            foreach (var image in horizontalWins)
                image.gameObject.SetActive(false);

            foreach (var image in verticalWins)
                image.gameObject.SetActive(false);

            foreach (var image in diagonalWins)
                image.gameObject.SetActive(false);
        }

    }
}
namespace Dunnatello {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SpaceHandler : MonoBehaviour {

        [SerializeField] private int position = 0;

        public int Position { get { return position; } }


        public List<GameObject> icons = new();

        public GameManager gameManager;

        public void ClaimSpace(int player) {

            icons[player].SetActive(true);

        }

        public void Reset() {
            foreach (var icon in icons) { icon.SetActive(false); };
        }
        public void ActivateSpace() {
            gameManager.ClaimSpace(position);
        }

    }
}
namespace Dunnatello.UI {
    using TMPro;
    using UnityEngine;

    public class GetVersionNumber : MonoBehaviour {

        [SerializeField] private TextMeshProUGUI versionText;
        void Start() {
            versionText.text = $"Version {Application.version}";
        }

    }
}
namespace Dunnatello {
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class SectionHandler : MonoBehaviour {
        [System.Serializable]
        public class Section {
            public string name;
            public GameObject section;
            public GameObject firstButton;
        }

        [SerializeField] private List<Section> sections = new();

        [SerializeField] private EventSystem eventSystem;

        [SerializeField] private string defaultSection = "Menu";
        private void Start() {
            GoToSection(defaultSection);
        }

        public void GoToSection(string sectionName) {

            foreach (Section section in sections) {
               
                bool showSection = section.name.Equals(sectionName);
                section.section.SetActive(showSection);

                if (showSection)
                    eventSystem.SetSelectedGameObject(section.firstButton);

            }

        }

    }

}
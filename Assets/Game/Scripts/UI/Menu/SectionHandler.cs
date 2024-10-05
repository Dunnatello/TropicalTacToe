namespace Dunnatello.UI {
    
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class SectionHandler : MonoBehaviour {
        [System.Serializable]
        public class Section {
            public string name;
            public GameObject section;
            public GameObject firstButton;
            public DeselectAllButtons buttonHandler;
        }

        [SerializeField] private List<Section> sections = new();

        [SerializeField] private EventSystem eventSystem;

        [SerializeField] private string defaultSection = "Menu";
        [SerializeField] private bool handleButtonDeselection = false;

        private void Start() {
            GoToSection(defaultSection);
        }

        public void GoToSection(string sectionName) {

            foreach (Section section in sections) {
               
                bool showSection = section.name.Equals(sectionName);
                section.section.SetActive(showSection);

                if (showSection) {

                    if (handleButtonDeselection)
                        section.buttonHandler.DeselectAll();
                    
                    eventSystem.SetSelectedGameObject(section.firstButton);
                }

            }

        }

    }

}
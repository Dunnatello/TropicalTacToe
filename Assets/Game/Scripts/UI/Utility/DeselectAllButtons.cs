namespace Dunnatello.UI {

    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class DeselectAllButtons : MonoBehaviour {

        public List<EventTrigger> buttonTriggers = new();

        public void DeselectAll() {

            foreach (EventTrigger trigger in buttonTriggers) {

                trigger.OnDeselect(new(EventSystem.current));

            }

        }

    }

}
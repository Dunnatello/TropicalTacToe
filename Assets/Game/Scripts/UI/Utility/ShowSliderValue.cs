using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Dunnatello.UI {

    public class ShowSliderValue : MonoBehaviour {

        [SerializeField] private TextMeshProUGUI valueField;
        [SerializeField] private Slider slider;

        [SerializeField] private bool showPercentage = false;

        public void SliderValueChanged( float newValue ) {


            valueField.text = string.Format( "{0:0}", newValue );

            if ( showPercentage )
                valueField.text += "%";

        }


        private void Start( ) {

            SliderValueChanged( slider.value );

        }

    }

}
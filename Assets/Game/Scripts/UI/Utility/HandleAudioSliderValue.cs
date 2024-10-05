namespace Dunnatello.UI {
    
    using Dunnatello.Audio;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class HandleAudioSliderValue : MonoBehaviour {

        [SerializeField] private string sliderName;
        private AudioHandler audioHandler;

        [SerializeField] private Slider slider;
        private void Awake() {

            if (audioHandler == null) {
                audioHandler = FindFirstObjectByType<AudioHandler>();
            }

            if (audioHandler != null)
                slider.value = audioHandler.GetAudioVolume(sliderName);

        }

        public void SetAudioVolume(float value) {
            audioHandler.SetAudioVolume(sliderName, value);
        }

    }

}
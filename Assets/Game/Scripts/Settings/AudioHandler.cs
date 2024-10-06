namespace Dunnatello.Audio {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Audio;

    public class AudioHandler : MonoBehaviour {

        public static AudioHandler Instance;

        [System.Serializable]
        public class StoredAudioMixer {
            public string name;
            public AudioMixer mixer;
            public float defaultVolume = 100f;
            public float volume;
        }

        [SerializeField] private List<StoredAudioMixer> audioMixers = new();

        [Header("Audio Settings")]
        [SerializeField] private float volumeDecibelLowerLimit = -60f;
        [SerializeField] private float volumeDecibelUpperLimit = 10f;
        void Start() {

            // Singleton Class Behavior
            if (Instance != null) {
                Destroy(this.gameObject);
                return;
            }

            // Don't Destroy Instance
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            // Initialize Audio Settings
            LoadAudioSettings();

        }

        private void LoadAudioSettings() {

            // Load from PlayerPrefs
            foreach (var audioMixer in audioMixers) {
                audioMixer.volume = PlayerPrefs.GetFloat(audioMixer.name, audioMixer.defaultVolume);
            }

            ApplyAudioSettings();

        }

        public float GetAudioVolume(string mixerName) {

            // Set Default Volume
            float mixerVolume = 50f;

            // Find Audio Mixer
            var audioMixer = audioMixers.Find(mixer => mixer.name.Equals(mixerName));

            // Get Actual Volume
            if (audioMixer != null)
                mixerVolume = audioMixer.volume;

            return mixerVolume;
        }

        public void SetAudioVolume(string mixerName, float volume) {

            // Get Mixer
            var audioMixer = audioMixers.Find(mixer => mixer.name.Equals(mixerName));

            // Early Return: Mixer Not Found
            if (audioMixer == null) {
                Debug.LogWarning($"Could not find AudioMixer: \"{mixerName}\" in the Audio Mixers list.");
                return;
            }

            // Early Return: Volume Already Applied
            if (audioMixer.volume == volume) {
                return;
            }

            // Apply Volume
            ApplyAudioMixerVolume(audioMixer, volume);

        }
        
        private void ApplyAudioMixerVolume(StoredAudioMixer audioMixer, float volume) {

            audioMixer.mixer.SetFloat("Volume", PercentageToDecibel(volume / 100f, volumeDecibelLowerLimit, volumeDecibelUpperLimit));
            audioMixer.volume = volume;

        }
        // min + (value * (max - min)) = Decibel (-80db - 20db)
        private float PercentageToDecibel(float value, float minDecibel, float maxDecibel) { // Takes a percentage decimal value (0-1) and returns a decibel value.
            return Mathf.Clamp(minDecibel + value * (maxDecibel - minDecibel), minDecibel, maxDecibel);
        }

        private void ApplyAudioSettings() {

            // Apply All Audio Settings
            foreach (var audioMixer in audioMixers) {
                ApplyAudioMixerVolume(audioMixer, audioMixer.volume);
            }

        }

        private void OnApplicationQuit() {
            SaveAudioSettings();
        }
        private void SaveAudioSettings() {

            // Save All Audio Settings
            foreach (var audioMixer in audioMixers) {
                PlayerPrefs.SetFloat(audioMixer.name, audioMixer.volume);
            }

        }

    }

}
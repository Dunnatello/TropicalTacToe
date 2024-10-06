namespace Dunnatello.Settings {

    using System.Collections.Generic;

    using TMPro;
    using UnityEngine;

    public class SettingsManager : MonoBehaviour {

        [SerializeField] private TMP_Dropdown resolutionDropdown;
        [SerializeField] private TMP_Dropdown fullScreenModeDropdown;

        private int currentResolution = 0;
        private bool isFullscreen = false; // true: Borderless Fullscreen; false: Windowed

        Resolution[] resolutions;

        private void GetSupportedResolutions() {

            // Refresh Resolutions
            resolutions = Screen.resolutions;

            resolutionDropdown.ClearOptions();

            List<string> supportedResolutionOptions = new();

            // Create Readable Names From Each Resolution
            for (int i = resolutions.Length - 1; i >= 0; i--) {

                string newResolutionName = $"{resolutions[i].width} x {resolutions[i].height} @ {resolutions[i].refreshRateRatio} Hz";
                if (i == resolutions.Length - 1) {
                    newResolutionName += " (Native)";
                }

                supportedResolutionOptions.Add(newResolutionName);

            }

            // Add Resolution Options
            resolutionDropdown.AddOptions(supportedResolutionOptions);

            fullScreenModeDropdown.value = isFullscreen ? 0 : 1;
            resolutionDropdown.value = currentResolution;


        }

        private void Awake() {
            currentResolution = PlayerPrefs.GetInt("Resolution", 0);
            isFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

            GetSupportedResolutions();
        }

        // Set Resolution
        public void SetResolution(int resolutionIndex) {
            currentResolution = Mathf.Clamp(resolutionIndex, 0, resolutions.Length - 1);
            ApplyDisplayChanges();
        }

        // Set Fullscreen Mode
        public void SetFullScreenMode(int fullscreenMode) {
            isFullscreen = fullscreenMode == 0;
            ApplyDisplayChanges();
        }

        private void ApplyDisplayChanges() {

            if (resolutions.Length == 0)
                GetSupportedResolutions();

            Resolution current = resolutions[resolutions.Length - 1 - currentResolution];
            Screen.SetResolution(current.width, current.height, isFullscreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed, current.refreshRateRatio);

        }

        private void SaveSettings() {
            PlayerPrefs.SetInt("Resolution", currentResolution);
            PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        }
        private void OnDestroy() {
            SaveSettings();
        }

        private void OnApplicationQuit() {
            SaveSettings();
        }

    }

}
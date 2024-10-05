namespace Dunnatello.Audio {
    using UnityEngine;

    public class PlayRandomPitch : MonoBehaviour {

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private float minPitch = 1f;
        [SerializeField] private float maxPitch = 1f;
        public void Play() {

            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.Play();

        }

    }

}
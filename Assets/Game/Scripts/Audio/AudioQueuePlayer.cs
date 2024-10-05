namespace Dunnatello.Audio {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AudioQueuePlayer : MonoBehaviour {

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private List<AudioClip> audioQueue = new();

        private int soundIndex = 0;

        [SerializeField] private bool startAtRandomSound = true;

        // Start is called before the first frame update
        void Start() {

            if (startAtRandomSound)
                soundIndex = Random.Range(0, audioQueue.Count - 1) - 1;

            PlayNextInQueue();
        }

        private IEnumerator QueueCoroutine() {

            yield return new WaitUntil(() => audioSource.time >= audioSource.clip.length);
            PlayNextInQueue();
        }

        private void PlayNextInQueue() {

            soundIndex++;

            if (soundIndex >= audioQueue.Count)
                soundIndex = 0;

            audioSource.clip = audioQueue[soundIndex];
            audioSource.Play();
            StartCoroutine(QueueCoroutine());

        }

    }

}
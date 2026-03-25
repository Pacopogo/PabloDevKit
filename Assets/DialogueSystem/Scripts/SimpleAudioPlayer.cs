using UnityEngine;

namespace PabloDialogue
{
    [RequireComponent(typeof(AudioSource))]
    public class SimpleAudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource source;

        public void PlayAudioClip(AudioClip clip)
        {
            if (clip == null)
                return;

            if (source.isActiveAndEnabled == false)
            {
                source.Stop();
                return;
            }

            source.clip = clip;
            source.Play();
        }
        public void StopAudioClip()
        {
            source.Stop();
        }

        public void SetPitch(float pitch) => source.pitch = pitch;
    }
}
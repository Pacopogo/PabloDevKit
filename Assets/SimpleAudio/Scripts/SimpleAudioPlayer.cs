using UnityEngine;

/// <summary>
/// This class is to call in a single audio source
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class SimpleAudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Set the volume of the audio source
    /// </summary>
    /// <param name="amount"></param>
    public void SetAudioVolume(float amount) => audioSource.volume = amount;

    /// <summary>
    /// Assign a clip and immediatly play it
    /// </summary>
    /// <param name="clip"></param>
    public void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    /// <summary>
    /// This plays the currently set clip in the audio source
    /// </summary>
    public void PlayCurrentClip() => audioSource.Play();

    /// <summary>
    /// This is to assign a clip to the audio source without playing it
    /// </summary>
    /// <param name="clip"></param>
    public void AssignClip(AudioClip clip) => audioSource.clip = clip;
}

using UnityEngine;

public class DreamAudioWalking : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        Bed.OpenDoorSlow += PlayAudio;
        Bed.OnSleep += DisableAudio;

        enabled = false;
    }

    private void Update()
    {
        _audioSource.volume += 0.03f * Time.deltaTime;
    }

    private void PlayAudio()
    {
        Bed.OpenDoorSlow -= PlayAudio;

        _audioSource.Play();

        enabled = true;
    }

    private void DisableAudio()
    {
        Bed.OnSleep -= DisableAudio;

        _audioSource.Stop();

        enabled = false;
    }

    private void OnDestroy()
    {
        Bed.OpenDoorSlow -= PlayAudio;
        Bed.OnSleep -= DisableAudio;
    }
}

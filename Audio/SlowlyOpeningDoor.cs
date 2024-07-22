using UnityEngine;

public class SlowlyOpeningDoor : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private void Start()
    {
        Bed.OpenDoorSlow += PlayAudio;
    }

    private void PlayAudio()
    {
        Bed.OpenDoorSlow -= PlayAudio;

        _audioSource.Play();
    }

    private void OnDestroy()
    {
        Bed.OpenDoorSlow -= PlayAudio;
    }
}

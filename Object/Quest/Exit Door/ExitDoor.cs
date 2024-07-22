using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private AudioSource _exitDoorScreamer;

    private void Start()
    {
        CompletedTasksList.ActivateForestTriger += PlaySoundEffect;
    }

    private void PlaySoundEffect()
    {
        CompletedTasksList.ActivateForestTriger -= PlaySoundEffect;

        _exitDoorScreamer.Play();
    }

    private void OnDestroy()
    {
        CompletedTasksList.ActivateForestTriger -= PlaySoundEffect;
    }
}

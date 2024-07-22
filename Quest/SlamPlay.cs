using UnityEngine;

public class SlamPlay : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    private void Start()
    {
        WashingMachine.ActivateHorrorRadio += PlayAudio;
    }

    private void PlayAudio()
    {
        WashingMachine.ActivateHorrorRadio -= PlayAudio;

        _source.Play();
    }

    private void OnDestroy()
    {
        WashingMachine.ActivateHorrorRadio -= PlayAudio;
    }
}

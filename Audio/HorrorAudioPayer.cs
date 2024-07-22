using UnityEngine;

public class HorrorAudioPayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _dreamSuspens;
    [SerializeField] private AudioClip _noise;
    [SerializeField] private AudioClip _horrorAmbient;

    private void Start()
    {
        Bed.OnDream += DreamSuspensPlay;
        TurnOffWashingMachineTrigger.PsychoTrigger += NoiseStart;
        WashingMachine.ActivateHorrorRadio += HorrorAmbientPlay;
    }

    private void DreamSuspensPlay()
    {
        Bed.OnDream -= DreamSuspensPlay;

        _audioSource.clip = _dreamSuspens;
        _audioSource.Play();
    }
    private void NoiseStart()
    {
        TurnOffWashingMachineTrigger.PsychoTrigger -= NoiseStart;

        _audioSource.clip = _noise;
        _audioSource.Play();
    }
    private void HorrorAmbientPlay()
    {
        WashingMachine.ActivateHorrorRadio -= HorrorAmbientPlay;

        _audioSource.clip = _horrorAmbient;
        _audioSource.Play();

        _audioSource.volume = 0.2f;
    }
    private void OnDestroy()
    {
        Bed.OnDream -= DreamSuspensPlay;
        TurnOffWashingMachineTrigger.PsychoTrigger -= NoiseStart;
        WashingMachine.ActivateHorrorRadio -= HorrorAmbientPlay;
    }
}

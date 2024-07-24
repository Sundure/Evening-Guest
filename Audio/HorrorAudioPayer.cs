using System;
using UnityEngine;

public class HorrorAudioPayer : MonoBehaviour
{
    public static event Action<float> AudioTrigger;

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _dreamSuspens;
    [SerializeField] private AudioClip _noise;
    [SerializeField] private AudioClip _horrorAmbient;

    private void Start()
    {
        Bed.OnDream += DreamSuspensPlay;
        TurnOffWashingMachineTrigger.PsychoTrigger += NoiseStart;
        WashingMachine.ActivateHorrorRadio += HorrorAmbientPlay;
        DisableFinalRadio.OnFinalRadioUse += FinalQuest;
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

    private void FinalQuest()
    {
        DisableFinalRadio.OnFinalRadioUse -= FinalQuest;

        _audioSource.pitch = 2;
        _audioSource.volume = 0.4f;
        _audioSource.clip = _dreamSuspens;
        _audioSource.loop = true;
        _audioSource.Play();

        AudioTrigger?.Invoke(_audioSource.clip.length / _audioSource.pitch);
    }

    private void OnDestroy()
    {
        Bed.OnDream -= DreamSuspensPlay;
        TurnOffWashingMachineTrigger.PsychoTrigger -= NoiseStart;
        WashingMachine.ActivateHorrorRadio -= HorrorAmbientPlay;
        DisableFinalRadio.OnFinalRadioUse -= FinalQuest;
    }
}

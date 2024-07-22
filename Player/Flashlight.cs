using System;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public static bool CanUse = true;
    public static bool CanLight = true;

    [SerializeField] private GameObject _flashlight;

    [SerializeField] private AudioSource _flashlightAudioSource;

    [SerializeField] private AudioClip _flashlightDisableClip;
    [SerializeField] private AudioClip _flashlightEnableClip;

    public static event Action OnEnable;

    private void Start()
    {
        Pause.OnPauseUse += FlashlightSwitch;

        CanUse = true;
        CanLight = true;
    }

    private void FlashlightSwitch(bool canUse)
    {
        CanUse = !canUse;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && CanUse && CanLight)
        {
            _flashlight.SetActive(!_flashlight.activeSelf);
            if (_flashlight.activeSelf == true)
            {
                _flashlightAudioSource.clip = _flashlightDisableClip;
                _flashlightAudioSource.Play();

                OnEnable?.Invoke();

                return;
            }
            _flashlightAudioSource.clip = _flashlightEnableClip;
            _flashlightAudioSource.Play();
        }
        else if (CanLight == false)
        {
            _flashlight.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        Pause.OnPauseUse -= FlashlightSwitch;
    }
}

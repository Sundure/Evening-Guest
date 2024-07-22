using System;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public event Action SwitchEvent;

    public bool IsActive;

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _lightEnable;
    [SerializeField] private AudioClip _lightDisable;

    public void Switch()
    {
        IsActive = !IsActive;

        if (IsActive == false)
        {
            _audioSource.clip = _lightEnable;
        }
        else
        {
            _audioSource.clip = _lightDisable;
        }

        _audioSource.Play();

        SwitchEvent?.Invoke();
    }
}

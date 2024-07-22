using System;
using UnityEngine;

public class Radio : MonoBehaviour
{
    private bool _enabled;
    private bool _activateTask;

    [SerializeField] private AudioClip _creapyClip;

    [SerializeField] private AudioSource _music;

    public static event Action OnRadioSwitchOff;

    private void Start()
    {
        DoorQuest.OnForestEnter += ChangeScreamMusic;
    }

    public void RadioSwitch()
    {
        if (_enabled == false)
        {
            _music.Play();
        }
        else
        {
            _music.Stop();

            if (_activateTask)
            {
                _activateTask = false;

                OnRadioSwitchOff?.Invoke();
            }
        }

        _enabled = !_enabled;
    }

    private void ChangeScreamMusic()
    {
        DoorQuest.OnForestEnter -= ChangeScreamMusic;

        _music.loop = false;

        _music.clip = _creapyClip;

        _music.volume = 1f;

        _enabled = false;

        RadioSwitch();

        _activateTask = true;
    }

    private void OnDestroy()
    {
        DoorQuest.OnForestEnter -= ChangeScreamMusic;
    }
}



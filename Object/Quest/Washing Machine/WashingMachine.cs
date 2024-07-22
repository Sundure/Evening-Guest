using System;
using UnityEngine;

public class WashingMachine : MonoBehaviour
{
    private bool _wash;

    private LayerMask _interactedLayer;

    [SerializeField] private AudioSource _washingAudio;

    public static event Action OnWash;

    public static event Action ActivateHorrorRadio;

    private void Start()
    {
        CompletedTasksList.ActivateWashMashine += ActivateMachine;
        Psycho.PsychoDestroy += ActivateMachine;
    }

    private void ActivateMachine()
    {
        CompletedTasksList.ActivateWashMashine -= ActivateMachine;

        _interactedLayer = LayerMask.NameToLayer("Interacted");
        gameObject.layer = _interactedLayer;
        gameObject.tag = "Washing Machine";
    }

    public void Wash()
    {
        if (_wash == false)
        {
            _interactedLayer = LayerMask.NameToLayer("Default");
            gameObject.layer = _interactedLayer;

            _washingAudio.Play();

            OnWash?.Invoke();

            _wash = true;
        }
        else
        {
            ActivateHorrorRadio?.Invoke();
        }
    }

    private void OnDestroy()
    {
        Psycho.PsychoDestroy -= ActivateMachine;
        CompletedTasksList.ActivateWashMashine -= ActivateMachine;
    }
}

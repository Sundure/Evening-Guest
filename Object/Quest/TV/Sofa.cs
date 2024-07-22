using UnityEngine;
using System;
using System.Collections;

public class Sofa : MonoBehaviour
{
    [SerializeField] private Transform _seatPosition;
    [SerializeField] private Transform _stayPosition;

    [SerializeField] private float _waitingTime;

    public static event Action OnSofaSeat;
    public static event Action DoorQuestActivate;

    private LayerMask _interactedLayer;

    private bool _seatOnSofa;
    private void Start()
    {
        CompletedTasksList.ActivateSofa += ActivateSofa;

        OnSofaSeat += StartWaitTimeCoroutine;
    }

    private void ActivateSofa()
    {
        CompletedTasksList.ActivateSofa -= ActivateSofa;

        _interactedLayer = LayerMask.NameToLayer("Interacted");
        gameObject.layer = _interactedLayer;
        gameObject.tag = "Sofa";
    }

    public void OnSofaUse()
    {
        if (_seatOnSofa == false)
        {
            SofaSeat();
        }
        else
        {
            SofaStay();
        }
    }

    private void SofaSeat()
    {
        PlayerMovement.CanMove = false;

        OnSofaSeat?.Invoke();

        Player.PlayerCharacterController.enabled = false;
        Player.PlayerPosition = _seatPosition;

        _interactedLayer = LayerMask.NameToLayer("Default");
        gameObject.layer = _interactedLayer;

        Player.ChangePosition();

        _seatOnSofa = true;
    }

    private void SofaStay()
    {

        Player.PlayerPosition = _stayPosition;

        Player.ChangePosition();

        Player.PlayerCharacterController.enabled = true;
        PlayerMovement.CanMove = true;

        _seatOnSofa = false;

        _interactedLayer = LayerMask.NameToLayer("Default");
        gameObject.layer = _interactedLayer;
    }

    private void StartWaitTimeCoroutine()
    {
        OnSofaSeat -= StartWaitTimeCoroutine;

        StartCoroutine(WaitTime());
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(_waitingTime);

        _interactedLayer = LayerMask.NameToLayer("Interacted");
        gameObject.layer = _interactedLayer;

        DoorQuestActivate?.Invoke();
    }

    private void OnDestroy()
    {
        CompletedTasksList.ActivateSofa -= ActivateSofa;
        OnSofaSeat -= StartWaitTimeCoroutine;
    }
}
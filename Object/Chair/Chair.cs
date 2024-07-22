using UnityEngine;
using System;

public class Chair : MonoBehaviour
{
    public static event Action OnChairSeat;

    private LayerMask _interactedLayer;

    private bool _seatOnChair;

    [SerializeField] private Transform _seatPosition;

    private void Start()
    {
        CompletedTasksList.ActivateChair += ActivateChair;
        OnChairSeat += ChairSeat;

        EatingCake.OnCakeDestroy += OnCakeEat;
    }

    private void ActivateChair()
    {
        _interactedLayer = LayerMask.NameToLayer("Interacted");
        gameObject.layer = _interactedLayer;
        gameObject.tag = "Chair";
    }
    public void OnChairUse()
    {
        CompletedTasksList.ActivateChair -= ActivateChair;

        if (_seatOnChair == false)
        {
            OnChairSeat?.Invoke();
        }
        else
        {
            ChairStay();
        }
    }

    private void ChairSeat()
    {
        OnChairSeat -= OnChairSeat;

        PlayerMovement.CanMove = false;

        Player.PlayerCharacterController.enabled = false;
        Player.PlayerPosition = _seatPosition;

        _interactedLayer = LayerMask.NameToLayer("Default");
        gameObject.layer = _interactedLayer;

        Player.ChangePosition();

        _seatOnChair = true;
    }

    private void ChairStay()
    {
        PlayerMovement.CanMove = true;

        Player.PlayerCharacterController.enabled = true;

        _seatOnChair = false;

        _interactedLayer = LayerMask.NameToLayer("Default");
        gameObject.layer = _interactedLayer;
    }

    private void OnCakeEat()
    {
        _interactedLayer = LayerMask.NameToLayer("Interacted");
        gameObject.layer = _interactedLayer;
    }

    private void OnDestroy()
    {
        EatingCake.OnCakeDestroy -= OnCakeEat;

        OnChairSeat -= ChairSeat;
        CompletedTasksList.ActivateChair -= ActivateChair;
    }
}

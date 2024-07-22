using System;
using System.Collections;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public static event Action<bool> OnBedUse;
    public static event Action OnSleep;
    public static event Action OnDream;
    public static event Action OpenDoorSlow;

    private LayerMask _interactedLayer;
    private LayerMask _defaultLayer;

    private void Start()
    {
        CompletedTasksList.ActivateBed += ActivateBed;
    }

    private void ActivateBed()
    {
        CompletedTasksList.ActivateBed -= ActivateBed;

        _defaultLayer = LayerMask.NameToLayer("Default");

        _interactedLayer = LayerMask.NameToLayer("Interacted");
        gameObject.layer = _interactedLayer;
        gameObject.tag = "Bed";
    }

    public void BedUse()
    {
        OnBedUse?.Invoke(true);

        gameObject.layer = _defaultLayer;

        StartCoroutine(TimeDelay());

        Sleep();
    }

    private void Sleep()
    {
        gameObject.layer = _defaultLayer;

        PlayerMovement.CanMove = false;
        PlayerCamera.CanMove = false;
    }

    private IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(5);

        OnDream?.Invoke();

        yield return new WaitForSeconds(5);

        OpenDoorSlow?.Invoke();

        yield return new WaitForSeconds(19);

        OnDream?.Invoke();

        OnBedUse?.Invoke(false);

        BedStay();

        OnSleep?.Invoke();
    }

    private void BedStay()
    {
        PlayerMovement.CanMove = true;
        PlayerCamera.CanMove = true;
    }

    private void OnDestroy()
    {
        CompletedTasksList.ActivateBed -= ActivateBed;
    }
}

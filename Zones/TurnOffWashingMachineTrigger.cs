using System;
using UnityEngine;

public class TurnOffWashingMachineTrigger : MonoBehaviour
{
    public static event Action PsychoTrigger;

    private bool _canActivate;

    private void Start()
    {
        Bed.OnSleep += SetBool;
    }

    private void SetBool()
    {
        Bed.OnSleep -= SetBool;

        _canActivate = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_canActivate)
        {
            PsychoTrigger?.Invoke();
        }
    }

    private void OnDestroy()
    {
        Bed.OnSleep -= SetBool;
    }
}

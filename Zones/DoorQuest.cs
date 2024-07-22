using System;
using UnityEngine;

public class DoorQuest : MonoBehaviour
{
    public static event Action OnForestEnter;

    private bool _canActive;

    private void Start()
    {
        CompletedTasksList.ActivateForestTriger += SetBool;
    }

    private void SetBool()
    {
        _canActive = true;

        CompletedTasksList.ActivateForestTriger -= SetBool;
    }

    private void OnDestroy()
    {
        CompletedTasksList.ActivateForestTriger -= SetBool;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_canActive == true)
        {
            OnForestEnter?.Invoke();
        }
    }
}

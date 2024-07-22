using System;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    public static event Action FridgeQuest;

    private LayerMask _interactedLayer;

    private void Start()
    {
        CompletedTasksList.ActivateFridge += ActivateFridge;

        _interactedLayer = LayerMask.NameToLayer("Interacted");
    }

    private void ActivateFridge()
    {
        gameObject.tag = "Fridge";
        gameObject.layer = _interactedLayer;
    }

    public void OnFridgeUse()
    {
        FridgeQuest?.Invoke();

        _interactedLayer = LayerMask.NameToLayer("Default");
        gameObject.layer = _interactedLayer;
    }
    private void OnDestroy()
    {
        CompletedTasksList.ActivateFridge -= ActivateFridge;
    }
}

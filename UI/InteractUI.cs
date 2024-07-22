using UnityEngine;

public class InteractUI : MonoBehaviour
{
    [SerializeField] private GameObject _interactText;

    private void Start()
    {
        Interact.ExcludeInteract += ExcludeObject;
        Interact.IncludeInteract += IncludeObject;
    }
    private void ExcludeObject()
    {
        _interactText.SetActive(false);
    }
    private void IncludeObject()
    {
        _interactText.SetActive(true);
    }
    private void OnDestroy()
    {
        Interact.ExcludeInteract -= ExcludeObject;
        Interact.IncludeInteract -= IncludeObject;
    }
}
using UnityEngine;

public class HideKnife : MonoBehaviour
{
    private void Start()
    {
        DoorQuest.OnForestEnter += SetActiveFalse;
    }

    private void SetActiveFalse()
    {
        gameObject.SetActive(false);

        DoorQuest.OnForestEnter -= SetActiveFalse;
    }

    private void OnDestroy()
    {
        DoorQuest.OnForestEnter -= SetActiveFalse;
    }
}

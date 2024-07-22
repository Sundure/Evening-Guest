using UnityEngine;

public class SetActiveBlood : MonoBehaviour
{
    [SerializeField] private GameObject _blood;
    private void Start()
    {
        DoorQuest.OnForestEnter += ActiveBlood;
    }

    private void ActiveBlood()
    {
        DoorQuest.OnForestEnter -= ActiveBlood;

        _blood.SetActive(true);
    }

    private void OnDestroy()
    {
        DoorQuest.OnForestEnter -= ActiveBlood;
    }
}

using UnityEngine;

public class ActivateLivingRoom : MonoBehaviour
{
    [SerializeField] private GameObject _livingRoom;
    [SerializeField] private GameObject _ruinedLivingRoomV2;

    private void Start()
    {
        WashingMachine.ActivateHorrorRadio += ActivateObject;
    }

    private void ActivateObject()
    {
        WashingMachine.ActivateHorrorRadio -= ActivateObject;

        _livingRoom.SetActive(false);
        _ruinedLivingRoomV2.SetActive(true);
    }

    private void OnDestroy()
    {
        WashingMachine.ActivateHorrorRadio -= ActivateObject;
    }
}

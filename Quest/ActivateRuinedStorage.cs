using UnityEngine;

public class ActivateRuinedStorage : MonoBehaviour
{
    [SerializeField] private GameObject _storage;
    [SerializeField] private GameObject _ruinedStorage;

    private void Start()
    {
        WashingMachine.ActivateHorrorRadio += ActivateStorage;
    }

    private void ActivateStorage()
    {
        WashingMachine.ActivateHorrorRadio -= ActivateStorage;

        _storage.SetActive(false);
        _ruinedStorage.SetActive(true);
    }

    private void OnDestroy()
    {
        WashingMachine.ActivateHorrorRadio -= ActivateStorage;
    }
}

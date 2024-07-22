using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    [SerializeField] private GameObject _bedroom;
    [SerializeField] private GameObject _ruinedBedroom;

    private void Start()
    {
        Bed.OnSleep += ChangeBedroom;
    }

    private void ChangeBedroom()
    {
        Bed.OnSleep -= ChangeBedroom;

        _bedroom.SetActive(false);
        _ruinedBedroom.SetActive(true);
    }

    private void OnDestroy()
    {
        Bed.OnSleep -= ChangeBedroom;
    }
}

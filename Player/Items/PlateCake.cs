using UnityEngine;

public class PlateCake : MonoBehaviour
{
    [SerializeField] private GameObject _cake;
    private void Start()
    {
        Chair.OnChairSeat += ActivateCake;
    }
    private void ActivateCake()
    {
        Chair.OnChairSeat -= ActivateCake;
        _cake.SetActive(true);
    }
    private void OnDestroy()
    {
        Chair.OnChairSeat -= ActivateCake;
    }
}

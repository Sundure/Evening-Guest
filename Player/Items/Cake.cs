using UnityEngine;

public class Cake : MonoBehaviour
{
    private void Start()
    {
        Fridge.FridgeQuest += AddCake;
        Chair.OnChairSeat += RemoveCake;
        gameObject.SetActive(false);
    }

    private void AddCake()
    {
        Fridge.FridgeQuest -= AddCake;
        gameObject.SetActive(true);
    }

    private void RemoveCake()
    {
        gameObject.SetActive(false);
        Chair.OnChairSeat -= RemoveCake;
    }

    private void OnDestroy()
    {
        Chair.OnChairSeat -= RemoveCake;
        Fridge.FridgeQuest -= AddCake;
    }
}

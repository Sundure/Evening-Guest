using UnityEngine;

public class ActivateDate : MonoBehaviour
{
    private void Start()
    {
        Bed.OnSleep += ActivateObject;

        gameObject.SetActive(false);
    }

    private void ActivateObject()
    {
        Bed.OnSleep -= ActivateObject;

        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        Bed.OnSleep -= ActivateObject;
    }
}

using UnityEngine;

public class MainDoorDestroy : MonoBehaviour
{
    private void Start()
    {
        WashingMachine.ActivateHorrorRadio += Destroy;
    }

    private void Destroy()
    {
        WashingMachine.ActivateHorrorRadio -= Destroy;

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        WashingMachine.ActivateHorrorRadio -= Destroy;
    }
}

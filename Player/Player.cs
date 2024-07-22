using UnityEngine;

public class Player : MonoBehaviour
{
    public static Transform PlayerPosition;
    public static GameObject FirstPersonController;
    public static CharacterController PlayerCharacterController;

    private void Start()
    {
        FirstPersonController = gameObject;
        PlayerCharacterController = FirstPersonController.GetComponent<CharacterController>();

        PlayerPosition = FirstPersonController.transform;
    }
    static public void ChangePosition()
    {
        FirstPersonController.transform.position = PlayerPosition.transform.position;

        PlayerPosition = FirstPersonController.transform;
    }
}

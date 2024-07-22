using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed;

    [SerializeField] private CharacterController _playerCharacterController;

    private const float _gravity = -10f;

    private Vector3 _velocity;

    public bool PlayerMove;

    public static bool CanMove = true;

    private void Start()
    {
        CanMove = true;
    }

    private void Update()
    {
        if (CanMove == true)
        {
            OnPlayerMove();

            PlayerGravity();

            return;
        }
        PlayerMove = false;

    }
    private void OnPlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _playerCharacterController.Move(PlayerSpeed * Time.deltaTime * move);

        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S))
        {
            PlayerMove = true;
        }
        else
        {
            PlayerMove = false;
        }
    }
    private void PlayerGravity()
    {
        _velocity.y += _gravity * Time.deltaTime;
        _playerCharacterController.Move(_velocity);
    }
}

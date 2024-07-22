using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    private float _playerRunSpeed;
    [SerializeField] private float _standartPlayerWalkSpeed;

    public static float PlayerWalkSpeed;

    public float SpeedBonus;

    public bool Run;

    [SerializeField] private PlayerMovement _playerMovement;

    private void Start()
    {
        PlayerWalkSpeed = _playerMovement.PlayerSpeed;

        PlayerWalkSpeed = _standartPlayerWalkSpeed;
    }
    private void Update()
    {
        _playerRunSpeed = PlayerWalkSpeed * SpeedBonus;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Run = true;

            _playerMovement.PlayerSpeed = _playerRunSpeed;
        }
        else
        {
            Run = false;
            _playerMovement.PlayerSpeed = PlayerWalkSpeed;
        }
    }
}

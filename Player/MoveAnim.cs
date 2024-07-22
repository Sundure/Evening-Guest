using UnityEngine;

public class MoveAnim : MonoBehaviour
{
    [SerializeField] private Animator _cameraAnimator;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerRun _playerRun;

    private void Update()
    {
        if (_playerRun.Run && _playerMovement.PlayerMove)
        {
            _cameraAnimator.SetBool("Run", true);

            _cameraAnimator.speed = _playerRun.SpeedBonus;
            return;
        }
        _cameraAnimator.SetBool("Run", false);

        if (_playerMovement.PlayerMove)
        {
            _cameraAnimator.SetBool("Move", true);
            _cameraAnimator.speed = 1;
        }
        else
        {
            _cameraAnimator.SetBool("Move", false);
        }
    }
}

using System.Collections;
using UnityEngine;

public class FootstepEffect : MonoBehaviour
{
    [SerializeField] private AudioSource _footstepAudio;

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerRun _playerRun;

    [SerializeField] private float _footstepSpeed;

    private bool _isPlaying;

    private float _stepSpeed;

    private void Update()
    {
        if (_playerMovement.PlayerMove && _playerRun.Run && _isPlaying == false)
        {
            _footstepAudio.pitch = _footstepSpeed * _playerRun.SpeedBonus;
            _stepSpeed = _footstepAudio.pitch;

            StartCoroutine(PlayAudioClip());
            return;
        }
        _footstepAudio.pitch = _footstepSpeed;
        _stepSpeed = _footstepAudio.pitch;

        if (_playerMovement.PlayerMove && _isPlaying == false)
        {
            StartCoroutine(PlayAudioClip());
        }
    }
    private IEnumerator PlayAudioClip()
    {
        _isPlaying = true;

        _footstepAudio.Play();
        yield return new WaitForSeconds(_footstepAudio.clip.length / _stepSpeed);

        _isPlaying = false;
    }
}

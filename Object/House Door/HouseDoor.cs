using UnityEngine;

public class HouseDoor : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _openDoorClip;
    [SerializeField] private AudioClip _closeDoorClip;

    private bool _isOpen;
    public void Door()
    {
        _isOpen = !_isOpen;

        if (_isOpen)
        {
            _audioSource.clip = _openDoorClip;
        }
        else
        {
            _audioSource.clip = _closeDoorClip;
        }
        _audioSource.Play();

        _animator.SetBool("IsOpen", _isOpen);
    }
}

using UnityEngine;

public class WindowTriger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        _audioSource.Play();
    }
}

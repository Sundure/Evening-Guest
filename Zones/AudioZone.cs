using UnityEngine;

public class AudioZone : MonoBehaviour
{

    [SerializeField] private AudioReverbZone _reverbZone;
    private void OnTriggerEnter(Collider other)
    {
        _reverbZone.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _reverbZone.enabled = false;
    }
}

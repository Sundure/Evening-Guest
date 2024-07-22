using UnityEngine;

public class ActivateRunVictum : MonoBehaviour
{
    [SerializeField] private GameObject _victum;

    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        EatingCake.WindowEvent += ActivateVictumRun;
    }

    private void ActivateVictumRun(bool victumStart)
    {
        if (victumStart == false)
        {
            _audioSource.Play();
        }
        else
        {
            EatingCake.WindowEvent -= ActivateVictumRun;

            _victum.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        EatingCake.WindowEvent -= ActivateVictumRun;
    }
}

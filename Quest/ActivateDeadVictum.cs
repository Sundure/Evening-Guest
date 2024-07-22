using UnityEngine;

public class ActivateDeadVictum : MonoBehaviour
{
    [SerializeField] private GameObject _victum;

    private void Start()
    {
        DisableFinalRadio.OnFinalRadioUse += Activate;
    }

    private void Activate()
    {
        DisableFinalRadio.OnFinalRadioUse -= Activate;

        _victum.SetActive(true);
    }

    private void OnDestroy()
    {
        DisableFinalRadio.OnFinalRadioUse -= Activate;
    }
}

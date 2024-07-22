using UnityEngine;

public class Knife : MonoBehaviour
{
    private void Start()
    {
        DisableFinalRadio.OnFinalRadioUse += ActivateKnife;

        gameObject.SetActive(false);
    }

    private void ActivateKnife()
    {
        DisableFinalRadio.OnFinalRadioUse -= ActivateKnife;

        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        DisableFinalRadio.OnFinalRadioUse -= ActivateKnife;
    }
}

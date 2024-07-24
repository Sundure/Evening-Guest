using UnityEngine;
using UnityEngine.Rendering;
using VolFx;


public class ChangeVHS : MonoBehaviour
{
    [SerializeField] private Volume _volume;

    private VhsVol _vhs;


    private void Start()
    {
        DisableFinalRadio.OnFinalRadioUse += ActivateObject;

        _volume.profile.TryGet(out _vhs);

        enabled = false;
    }

    private void ActivateObject()
    {
        DisableFinalRadio.OnFinalRadioUse -= ActivateObject;

        enabled = true;
    }

    private void Update()
    {
        _vhs._weight.value += Time.deltaTime / 8;
    }

    private void OnDestroy()
    {
        DisableFinalRadio.OnFinalRadioUse -= ActivateObject;
    }
}

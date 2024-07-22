using System;
using UnityEngine;

public class DisableFinalRadio : MonoBehaviour
{
    [SerializeField] private AudioSource _source;

    public static event Action OnFinalRadioUse;

    private LayerMask _defaultLayer;

    private void Start()
    {
        _defaultLayer = LayerMask.NameToLayer("Default");
    }

    public void RadioOff()
    {
        _source.Stop();

        OnFinalRadioUse?.Invoke();

        gameObject.layer = _defaultLayer;
    }
}

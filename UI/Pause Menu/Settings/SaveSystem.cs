using UnityEngine;
using UnityEngine.UI;
using System;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Slider _sensitivitySlider;

    [SerializeField] private Toggle _vhsEffectsToggle;

    [Header("Vol ")]

    [SerializeField] private Toggle _tonemappingToggle;
    [SerializeField] private Toggle _colorAdjustmentsToggle;
    [SerializeField] private Toggle _lensDistortionToggle;
    [SerializeField] private Toggle _vignetteToggle;
    [SerializeField] private Toggle _chromaticAberrationToggle;
    [SerializeField] private Toggle _filmGrainToggle;
    [SerializeField] private Toggle _vhsVolToggle;
    [SerializeField] private Toggle _depthOfFieldToggle;
    [SerializeField] private Toggle _bloomToggle;

    [SerializeField] private Toggle _vSyncToggle;

    public static event Action ChangeValueEvent;
    public void Save()
    {
        SettingsSave.Volume = _volumeSlider.value;
        SettingsSave.Sensitivity = _sensitivitySlider.value;

        SettingsSave.VHS = _vhsEffectsToggle.isOn;

        SettingsSave.Tonemapping = _tonemappingToggle.isOn;
        SettingsSave.ColorAdjustments = _colorAdjustmentsToggle.isOn;
        SettingsSave.LensDistortion = _lensDistortionToggle.isOn;
        SettingsSave.Vignette = _vignetteToggle.isOn;
        SettingsSave.ChromaticAberration = _chromaticAberrationToggle.isOn;
        SettingsSave.FilmGrain = _filmGrainToggle.isOn;
        SettingsSave.VhsVol = _vhsVolToggle.isOn;
        SettingsSave.MotionBlur = _depthOfFieldToggle.isOn;
        SettingsSave.DepthOfField = _depthOfFieldToggle.isOn;
        SettingsSave.Bloom = _bloomToggle.isOn;

        SettingsSave.VSync = _vSyncToggle.isOn;

        ChangeValue();
    }
    private void ChangeValue()
    {
        ChangeValueEvent?.Invoke();
    }
}

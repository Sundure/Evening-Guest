using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using VolFx;

public class VolumeEffects : MonoBehaviour
{
    private Tonemapping _tonemapping;
    private ColorAdjustments _colorAdjustments;
    private LensDistortion _lensDistortion;
    private Vignette _vignette;
    private ChromaticAberration _chromaticAberration;
    private FilmGrain _filmGrain;
    private VhsVol _vhsVol;
    private MotionBlur _motionBlur;
    private DepthOfField _depthOfField;
    private Bloom _bloom;

    [SerializeField] private Volume _volume;

    [SerializeField] private Toggle _tonemappingToggle;
    [SerializeField] private Toggle _colorAdjustmentsToggle;
    [SerializeField] private Toggle _lensDistortionToggle;
    [SerializeField] private Toggle _vignetteToggle;
    [SerializeField] private Toggle _chromaticAberrationToggle;
    [SerializeField] private Toggle _filmGrainToggle;
    [SerializeField] private Toggle _vhsVolToggle;
    [SerializeField] private Toggle _depthOfFieldToggle;
    [SerializeField] private Toggle _bloomToggle;

    private void Start()
    {
        _volume.profile.TryGet(out _tonemapping);
        _volume.profile.TryGet(out _colorAdjustments);
        _volume.profile.TryGet(out _lensDistortion);
        _volume.profile.TryGet(out _vignette);
        _volume.profile.TryGet(out _chromaticAberration);
        _volume.profile.TryGet(out _filmGrain);
        _volume.profile.TryGet(out _vhsVol);
        _volume.profile.TryGet(out _motionBlur);
        _volume.profile.TryGet(out _depthOfField);
        _volume.profile.TryGet(out _bloom);

        _tonemapping.active = SettingsSave.Tonemapping;
        _colorAdjustments.active = SettingsSave.ColorAdjustments;
        _lensDistortion.active = SettingsSave.LensDistortion;
        _vignette.active = SettingsSave.Vignette;
        _chromaticAberration.active = SettingsSave.ChromaticAberration;
        _filmGrain.active = SettingsSave.FilmGrain;
        _vhsVol.active = SettingsSave.VhsVol;
        _motionBlur.active = SettingsSave.MotionBlur;
        _depthOfField.active = SettingsSave.DepthOfField;
        _bloom.active = SettingsSave.Bloom;

        _tonemappingToggle.isOn = SettingsSave.Tonemapping;
        _colorAdjustmentsToggle.isOn = SettingsSave.ColorAdjustments;
        _lensDistortionToggle.isOn = SettingsSave.LensDistortion;
        _vignetteToggle.isOn = SettingsSave.Vignette;
        _chromaticAberrationToggle.isOn = SettingsSave.ChromaticAberration;
        _filmGrainToggle.isOn = SettingsSave.FilmGrain;
        _vhsVolToggle.isOn = SettingsSave.VhsVol;
        _depthOfFieldToggle.isOn = SettingsSave.DepthOfField;
        _bloomToggle.isOn = SettingsSave.Bloom;
    }
    public void ChangeTonemapping()
    {
        _tonemapping.active = _tonemappingToggle.isOn;
    }

    public void ChangeColorAdjustments()
    {
        _colorAdjustments.active = _colorAdjustmentsToggle.isOn;
    }

    public void ChangeLensDistortion()
    {
        _lensDistortion.active = _lensDistortionToggle.isOn;
    }

    public void ChangeVignette()
    {
        _vignette.active = _vignetteToggle.isOn;
    }

    public void ChangeChromaticAberration()
    {
        _chromaticAberration.active = _chromaticAberrationToggle.isOn;
    }

    public void ChangeFilmGrain()
    {
        _filmGrain.active = _filmGrainToggle.isOn;
    }

    public void ChangeVhsVol()
    {
        _vhsVol.active = _vhsVolToggle.isOn;
    }

    public void ChangeDepthOfField()
    {
        _depthOfField.active = _depthOfFieldToggle.isOn;
        _motionBlur.active = _depthOfFieldToggle.isOn;
    }

    public void ChangeBloom()
    {
        _bloom.active = _bloomToggle.isOn;
    }
}

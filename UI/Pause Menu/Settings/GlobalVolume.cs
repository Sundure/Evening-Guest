using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using VolFx;

public class GlobalVolume : MonoBehaviour
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

    private Volume _volume;

    private void Start()
    {
        _volume = GetComponent<Volume>();

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

        ChangeValue();
        SaveSystem.ChangeValueEvent += ChangeValue;
    }
    private void ChangeValue()
    {
        gameObject.SetActive(SettingsSave.VHS);

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

    }
    private void OnDestroy()
    {
        SaveSystem.ChangeValueEvent -= ChangeValue;
    }
}

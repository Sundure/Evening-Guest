using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    private void Start()
    {
        _volumeSlider.value = SettingsSave.Volume;
    }
}

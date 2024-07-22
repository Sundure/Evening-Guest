using UnityEngine;
using UnityEngine.UI;

public class Sensitivity : MonoBehaviour
{
    [SerializeField] private Slider _sensitivitySlider;

    private void Start()
    {
        _sensitivitySlider.value = PlayerCamera.MouseSens;
    }
    private void Update()
    {
        PlayerCamera.MouseSens = _sensitivitySlider.value;
    }
}

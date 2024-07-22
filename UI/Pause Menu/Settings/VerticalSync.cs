using UnityEngine;
using UnityEngine.UI;
public class VerticalSync : MonoBehaviour
{
    [SerializeField] private Toggle _vSync;
    private void Start()
    {
        _vSync.isOn = SettingsSave.VSync;
    }
}

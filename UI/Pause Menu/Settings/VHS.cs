using UnityEngine;
using UnityEngine.UI;

public class VHS : MonoBehaviour
{
    [SerializeField] private Toggle _vhs;
    private void Start()
    {
        _vhs.isOn = SettingsSave.VHS;
    }
}

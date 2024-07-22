using UnityEngine;

public class Bulb : MonoBehaviour
{
    [SerializeField] private LightSwitch _lightSwitch;

    [SerializeField] private GameObject _lightBulb;

    [SerializeField] private Material _lightOnMat;
    [SerializeField] private Material _lightOffMat;
    private void Start()
    {
        _lightSwitch.SwitchEvent += LightSwitch;
    }

    private void LightSwitch()
    {
        if (_lightSwitch.IsActive == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = _lightOnMat;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = _lightOffMat;
        }

        _lightBulb.SetActive(_lightSwitch.IsActive);
    }

    private void OnDestroy()
    {
        _lightSwitch.SwitchEvent -= LightSwitch;
    }
}

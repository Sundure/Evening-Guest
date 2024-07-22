using System.Collections;
using UnityEngine;

public class BedroomDisableLight : MonoBehaviour
{
    [SerializeField] private LightSwitch _lightSwitch;

    private void Start()
    {
        Bed.OpenDoorSlow += DisableLightCoroutine;
    }

    private void DisableLightCoroutine()
    {
        Bed.OpenDoorSlow -= DisableLightCoroutine;

        StartCoroutine(DisableLight());
    }
    private IEnumerator DisableLight()
    {
        yield return new WaitForSeconds(7);

        if (_lightSwitch.IsActive == true)
        {
            _lightSwitch.Switch();
        }
    }

    private void OnDestroy()
    {
        Bed.OpenDoorSlow -= DisableLightCoroutine;
    }
}

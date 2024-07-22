using UnityEngine;

public class ForestZoneDisableLight : MonoBehaviour
{
    [SerializeField] private LightSwitch _lightSwitch;

    private void Start()
    {
        DoorQuest.OnForestEnter += DisableLight;
    }

    private void DisableLight()
    {
        DoorQuest.OnForestEnter -= DisableLight;

        if (_lightSwitch.IsActive == true)
        {
            _lightSwitch.Switch();
        }
    }

    private void OnDestroy()
    {
        DoorQuest.OnForestEnter -= DisableLight;
    }
}

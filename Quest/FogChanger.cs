using UnityEngine;

public class FogChanger : MonoBehaviour
{
    private void Start()
    {
        Bed.OnSleep += ChangeFogDensity;
        BathroomSwitch.OnBathroomChange += ChangeFogColor;
    }

    private void ChangeFogDensity()
    {
        Bed.OnSleep -= ChangeFogDensity;

        RenderSettings.fogDensity = 0.02f;
    }

    private void ChangeFogColor()
    {
        BathroomSwitch.OnBathroomChange -= ChangeFogColor;

        RenderSettings.fogColor = Color.red;
    }

    private void OnDestroy()
    {
        Bed.OnSleep -= ChangeFogDensity;
        BathroomSwitch.OnBathroomChange -= ChangeFogColor;
    }
}

using UnityEngine;
using UnityEngine.Audio;
public class GameAudioMixer : MonoBehaviour
{
    public static bool CanChange = true;

    [SerializeField] private AudioMixer _audioMixer;

    private void Start()
    {
        Pause.OnPauseUse += MixerSwitch;

        _audioMixer.SetFloat("Volume", 0f);
    }

    private void MixerSwitch(bool enabled)
    {
        if (CanChange)
        {
            if (enabled)
            {
                _audioMixer.SetFloat("Volume", -80f);
            }
            else
            {
                _audioMixer.SetFloat("Volume", 0f);
            }
        }
    }

    private void OnDestroy()
    {
        Pause.OnPauseUse -= MixerSwitch;
    }
}

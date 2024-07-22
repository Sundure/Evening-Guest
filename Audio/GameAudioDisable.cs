using UnityEngine;
using UnityEngine.Audio;

public class GameAudioDisable : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private float _volume;

    private bool _isChange = true;

    private void Start()
    {
        Bed.OnDream += ChangeStatus;

        enabled = false;
    }

    private void Update()
    {
        if (_isChange && GameAudioMixer.CanChange)
        {
            _audioMixer.SetFloat("Volume", 0);

            enabled = false;
        }
        else if (_isChange == false && GameAudioMixer.CanChange)
        {
            _audioMixer.SetFloat("Volume", _volume -= Time.deltaTime * 2);

            if (_volume <= -20f)
            {
                GameAudioMixer.CanChange = false;

                _audioMixer.SetFloat("Volume", -20);

                enabled = false;
            }
        }
    }

    private void ChangeStatus()
    {
        _isChange = !_isChange;
        GameAudioMixer.CanChange = true;

        enabled = true;
    }

    private void OnDestroy()
    {
        Bed.OnDream -= ChangeStatus;
    }
}

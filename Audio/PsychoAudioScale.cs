using UnityEngine;

public class PsychoAudioScale : MonoBehaviour
{
    [SerializeField] private Psycho _psycho;

    [SerializeField] private AudioSource _source;
    private void Start()
    {
        TurnOffWashingMachineTrigger.PsychoTrigger += OnEvent;

        Psycho.PsychoDestroy += Destroy;

        enabled = false;
    }

    private void OnEvent()
    {
        TurnOffWashingMachineTrigger.PsychoTrigger -= OnEvent;

        _source.loop = true;

        enabled = true;
    }

    private void Update()
    {
        _source.volume = _psycho.Scale / 15;
    }

    private void Destroy()
    {
        _source.volume = 1;

        _source.Stop();

        _source.loop = false;

        Destroy(this);
    }

    private void OnDestroy()
    {
        Psycho.PsychoDestroy -= Destroy;
        TurnOffWashingMachineTrigger.PsychoTrigger -= OnEvent;
    }
}

using Unity.Mathematics;
using UnityEngine;

public class PsychoPlayerSpeedScale : MonoBehaviour
{
    [SerializeField] private Psycho _psycho;

    [SerializeField] private float _scale;

    private void Start()
    {
        TurnOffWashingMachineTrigger.PsychoTrigger += SetActive;
        Psycho.PsychoDestroy += Destroy;

        enabled = false;
    }

    private void SetActive()
    {
        TurnOffWashingMachineTrigger.PsychoTrigger -= SetActive;

        enabled = true;
    }

    private void Update()
    {
        PlayerRun.PlayerWalkSpeed = math.clamp(_psycho.Distance / _scale, 1, 4);
    }

    private void Destroy()
    {
        PlayerRun.PlayerWalkSpeed = 4;

        Destroy(this);
    }

    private void OnDestroy()
    {
        TurnOffWashingMachineTrigger.PsychoTrigger -= SetActive;
    }
}

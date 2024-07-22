using UnityEngine;
using UnityEngine.Rendering;
using VolFx;


public class ChangeVHS : MonoBehaviour
{
    [SerializeField] private Volume _volume;

    private VhsVol _vhs;


    private void Start()
    {
        TaskManager.FinalTaskDone += ActivateObject;

        _volume.profile.TryGet(out _vhs);

        enabled = false;
    }

    private void ActivateObject()
    {
        TaskManager.FinalTaskDone -= ActivateObject;

        enabled = true;
    }

    private void Update()
    {
        _vhs._weight.value += Time.deltaTime / 8;
    }

    private void OnDestroy()
    {
        TaskManager.FinalTaskDone -= ActivateObject;
    }
}

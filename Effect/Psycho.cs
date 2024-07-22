using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using VolFx;

public class Psycho : MonoBehaviour
{
    public static event Action PsychoDestroy;

    [SerializeField] private Transform _point;

    [SerializeField] private Volume _volume;

    private VhsVol _vhs;

    private const float _minDistance = 0;
    private const float _maxDistance = 20;

    public float Scale;

    public float Distance;

    private void Start()
    {
        TurnOffWashingMachineTrigger.PsychoTrigger += ActivateObject;

        _volume.profile.TryGet(out _vhs);

        gameObject.SetActive(false);
    }

    private void ActivateObject()
    {
        TurnOffWashingMachineTrigger.PsychoTrigger -= ActivateObject;

        gameObject.SetActive(true);
    }

    private void Update()
    {
        Distance = Vector3.Distance(_point.position, transform.position);


        if (Distance < _maxDistance)
        {
            float scale = (_maxDistance - Distance) / _maxDistance;

            Scale = math.lerp(_minDistance, _maxDistance, scale / 16);

            _vhs._weight.value = Scale;

            if (Distance <= 2)
            {
                _vhs._weight.value = 0.02f;

                PsychoDestroy?.Invoke();

                Destroy(gameObject);
            }
        }
        else
        {
            _vhs._weight.value = 0.02f;
        }
    }

    private void OnDestroy()
    {
        TurnOffWashingMachineTrigger.PsychoTrigger -= ActivateObject;
    }
}

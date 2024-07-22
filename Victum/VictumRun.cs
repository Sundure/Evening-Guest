using UnityEngine;
using UnityEngine.AI;

public class VictumRun : MonoBehaviour
{
    [SerializeField] private GameObject _point;

    [SerializeField] private float _victumSpeed;

    [SerializeField] private NavMeshAgent _agent;

    [SerializeField] private float _metersToPoint;

    private void Start()
    {
        _agent.destination = _point.transform.position;
    }

    private void Update()
    {
        _agent.speed = _victumSpeed;

        Vector3 vector3 = _point.transform.position;

        Vector3 magnituda = vector3 - transform.position;

        _metersToPoint = magnituda.magnitude;

        if (_metersToPoint <= 1)
            Destroy(gameObject);
    }
}

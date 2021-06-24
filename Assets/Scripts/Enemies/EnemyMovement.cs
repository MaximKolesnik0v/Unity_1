using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{ 
    [SerializeField] private float _DistanceForPlayer = 10f;
    [SerializeField] private Transform _PlayerPosition;

    public NavMeshAgent _navMeshAgent;
    public Transform[] _waypoints;

    int _CurrentWaypointIndex;

    private void Start()
    {
        _navMeshAgent.GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        if (Vector3.Distance(transform.position, _PlayerPosition.position) <=_DistanceForPlayer )
        {
            _navMeshAgent.SetDestination(_PlayerPosition.position);
        }

        else if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _CurrentWaypointIndex = (_CurrentWaypointIndex + 1) % _waypoints.Length;
            _navMeshAgent.SetDestination(_waypoints[_CurrentWaypointIndex].position);
        }
    }
}
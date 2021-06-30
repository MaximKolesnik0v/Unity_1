using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{ 
    [SerializeField] private Animator _animator;

    public NavMeshAgent _navMeshAgent;
    public Transform[] _waypoints;


    int _CurrentWaypointIndex;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _navMeshAgent.GetComponent<NavMeshAgent>();
    }


    private void FixedUpdate()
    {

        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _CurrentWaypointIndex = (_CurrentWaypointIndex + 1) % _waypoints.Length;
            _navMeshAgent.SetDestination(_waypoints[_CurrentWaypointIndex].position);

            _animator.SetBool("EnemyRun", true);
        }
    }
}
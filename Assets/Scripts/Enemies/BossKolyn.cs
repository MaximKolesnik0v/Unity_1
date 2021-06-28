using UnityEngine;
using UnityEngine.AI;

public class BossKolyn : MonoBehaviour
{
    [SerializeField] private float _DistanceForPlayer = 10f;
    [SerializeField] private Transform _PlayerPosition;
    [SerializeField] private int _MaxHp ;

    private int _hp;

    public NavMeshAgent _navMeshAgent;
    public Transform[] _waypoints;

    int _CurrentWaypointIndex;
    
    private void Awake()
    {
        _hp = _MaxHp;
    }

    private void Start()
    {
        _navMeshAgent.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _PlayerPosition.position) <= _DistanceForPlayer)
        {
            _navMeshAgent.SetDestination(_PlayerPosition.position);
        }

        else if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _CurrentWaypointIndex = (_CurrentWaypointIndex + 1) % _waypoints.Length;
            _navMeshAgent.SetDestination(_waypoints[_CurrentWaypointIndex].position);
        }
    }

    public void Damage(int _Damage)
    {
        Debug.Log("Enemy" + _hp);
        _hp -= _Damage;

        if (_hp <= 0)
            Death();
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}

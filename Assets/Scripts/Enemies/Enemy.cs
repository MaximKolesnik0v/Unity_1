using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _MaxHp;
    [SerializeField] private Transform _target;

    private NavMeshAgent _agent;
    private int _hp;

    private void Awake()
    {
        _hp = _MaxHp;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _agent.SetDestination(_target.position);
    }


    public void TakeDamage(int _Damage)
    {
        _hp -= _Damage;

        if (_hp <= 0)
            Death();
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}

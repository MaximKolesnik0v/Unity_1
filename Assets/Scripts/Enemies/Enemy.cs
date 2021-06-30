using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int _MaxHp = 50;
    [SerializeField] private float _DistanceForPlayer = 10f;
    [SerializeField] private Transform _PlayerPosition;
    [SerializeField] private int _Damage;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _DistanceAttack = 2f;

    private int _hp;

    public NavMeshAgent _navMeshAgent;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _hp = _MaxHp;
    }

    private void Start()
    {
        _navMeshAgent.GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _PlayerPosition.position) <= _DistanceForPlayer)
        {
            _navMeshAgent.SetDestination(_PlayerPosition.position);
            _animator.SetBool("EnemyRun", true);
        }

        else if (Vector3.Distance(transform.position, _PlayerPosition.position) <= _DistanceAttack)
        {
            _animator.SetBool("EnemyAtack", true);

            Fire();
        }
    }


    private void Fire()
    {
        MovePlayer _player = new MovePlayer();
        _player.Damage(_Damage);
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
        _animator.SetTrigger("EnemyDead");
    }
}

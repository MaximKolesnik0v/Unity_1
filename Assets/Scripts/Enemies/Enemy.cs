using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int _MaxHp = 50;

    private int _hp;

    private void Awake()
    {
        _hp = _MaxHp;
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

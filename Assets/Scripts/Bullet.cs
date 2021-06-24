
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _MaxLifeTime = 15;
    [SerializeField] private int _Damage = 10;

    Vector3 _direction;

    public void Init(Vector3 _Direction)
    {
        Destroy(gameObject, _MaxLifeTime);
        _direction = _Direction;
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().Damage(_Damage);
            Destroy(gameObject);
        }
        else other.GetComponent<MovePlayer>();
        { 
            other.GetComponent<MovePlayer>().Damage(_Damage);
            Destroy(gameObject);
        }
    }
}
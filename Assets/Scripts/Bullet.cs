
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _MaxLifeTime = 15;
    [SerializeField] private int _Damage = 10;

    public void Init()
    {
        Destroy(gameObject, _MaxLifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().TakeDamage(_Damage);
            Destroy(gameObject);
        }
        else other.GetComponent<MovePlayer>();
        { 
            other.GetComponent<MovePlayer>().TakeDamage(_Damage);
            Destroy(gameObject);
        }
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mina : MonoBehaviour
{
    [SerializeField] private float _Timer = 2f;
    [SerializeField] private float _radius = 3f;
    [SerializeField] private int _Damage;

    public void Boom(Vector3 _Direction)
    {
        Invoke("MineData", _Timer);
    }

    private void MineData()
    {
        var colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var hit in colliders)
        {
            if (hit.gameObject.CompareTag("Enemy"))
            {
                hit.GetComponent<Enemy>().Damage(_Damage);
            }
            else if (hit.gameObject.CompareTag("Player"))
            {
                hit.GetComponent<MovePlayer>().Damage(_Damage);
            }
        }
        Destroy(gameObject);
    }
}

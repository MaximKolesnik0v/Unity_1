using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _MaxLifeTime = 15;

    public void Init()
    {
        Debug.Log("Create bullet");
        Destroy(gameObject, _MaxLifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}

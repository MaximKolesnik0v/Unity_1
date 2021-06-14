using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _BulletPref;
    [SerializeField] private Transform _BulletStartPosition;

    private Vector3 _dir;

    void Update()
    {
        _dir.x = Input.GetAxis("Horizontal");
        _dir.z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    void FixedUpdate()
    {
        var speed = _dir * _speed * Time.fixedDeltaTime;
        transform.Translate(speed);
    }

    private void Fire()
    {
        var Bullet = Instantiate(_BulletPref, _BulletStartPosition.position, Quaternion.identity);
        var b = Bullet.GetComponent<Bullet>();
        b.Init();
    }
}

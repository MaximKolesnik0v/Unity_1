using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _target;


    private bool _IsOpen = false;

    private void Update()
    {
        if (_IsOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(_target), _speed * Time.deltaTime);
        }
    }

    public void Open()
    {
        _IsOpen = true;
    }
}

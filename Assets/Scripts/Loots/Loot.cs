using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{

    [SerializeField] private float _speed = 0.15f;

    void Update()
    {
        float degree = 2 * _speed;
        transform.Rotate(0, degree, 0);
    }
}

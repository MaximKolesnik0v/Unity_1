using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _HealthPoint;

    private float _HP;

    private void Awake()
    {
        _HP = 100f;
    }

    private void Update()
    {
        _HealthPoint.value = _HP;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolynDoor : MonoBehaviour
{
    [SerializeField] private Vector3 _Tp;
    private int _bootle = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovePlayer>())
        {
            other.GetComponent<MovePlayer>().TakeBottle(_bootle);
        }
    }

    private void Teleport()
    {
        transform.position =_Tp;
    }
}

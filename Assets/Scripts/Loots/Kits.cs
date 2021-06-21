using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kits : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovePlayer>())
        {
            other.GetComponent<MovePlayer>().Kit();
        }
        Destroy(gameObject);
    }
}

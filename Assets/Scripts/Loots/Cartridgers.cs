using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartridgers : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovePlayer>())
        {
            other.GetComponent<MovePlayer>().TakeBullet();
            Destroy(gameObject);
        }
    }
}

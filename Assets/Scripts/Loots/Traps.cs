using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovePlayer>())
        {
            other.GetComponent<MovePlayer>().Trap();

            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    private int _NumberOfBottles = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovePlayer>())
        {
            other.GetComponent<MovePlayer>().TakeBottle(_NumberOfBottles);
            Destroy(gameObject);
        }
    }
}

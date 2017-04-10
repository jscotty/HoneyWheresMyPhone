using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockyTest : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGERED!!");
    }
}

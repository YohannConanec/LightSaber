using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearObjects : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjectToHit"))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}

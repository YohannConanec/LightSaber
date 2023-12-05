using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnStart : MonoBehaviour
{
    void Awake()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

 
}

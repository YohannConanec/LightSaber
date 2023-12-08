using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjectToHit"))
        {
            Destroy(other.gameObject);
            //print(other.gameObject.name);
            if(this.CompareTag("Blade")){
                audioSource.Play();
                GlobalScore.Score += 1;
                Debug.Log(GlobalScore.Score);
            }
            
        }
    }
}
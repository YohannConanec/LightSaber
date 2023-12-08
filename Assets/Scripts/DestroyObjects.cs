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
            if (this.CompareTag("BladeLeft") || this.CompareTag("BladeRight"))
            {
                bool isLeft = other.GetComponent<DestroyableObject>().isLeft;
                if ((isLeft && this.CompareTag("BladeLeft")) || (!isLeft && this.CompareTag("BladeRight")))
                {
                    Destroy(other.gameObject);
                    audioSource.Play();
                    GlobalScore.Score += 1;
                    Debug.Log(GlobalScore.Score);
                }

            }
            else
            {
                Destroy(other.gameObject);
                if (this.CompareTag("Blade"))
                {
                    audioSource.Play();
                    GlobalScore.Score += 1;
                    Debug.Log(GlobalScore.Score);
                }

            }
        }

    }
}
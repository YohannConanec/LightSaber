using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                    var particles = isLeft ? GameObject.Find("fire_blue").GetComponent<ParticleSystem>() : GameObject.Find("fire_pink").GetComponent<ParticleSystem>();
                    particles.transform.position = other.transform.position;
                    particles.Play();
                    audioSource.Play();
                    Destroy(other.gameObject,particles.main.duration);
                    //Destroy(other.gameObject);
                    GlobalScore.Score += 1;
                    Debug.Log(GlobalScore.Score);
                }

            }
        }
        else if (other.CompareTag("MenuPlay"))
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (other.CompareTag("MenuQuit"))
        {
            Application.Quit();
        }
    }
}
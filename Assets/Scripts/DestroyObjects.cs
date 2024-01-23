using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObjects : MonoBehaviour
{
    // Déclaration des variables
    public AudioSource audioSource;
    private GameObject manager;
    private GameObject endgame;
    private ParticleSystem particles;

    void Start()
    {
        // Recherche des objets avec les tags "MenuManager" et "EndGame"
        manager = GameObject.FindGameObjectsWithTag("MenuManager")[0];
        endgame = GameObject.FindGameObjectsWithTag("EndGame")[0];
    }

    // Méthode appelée lorsqu'un objet entre en collision avec le collider attaché à ce GameObject
    private void OnTriggerEnter(Collider other)
    {
        // Switch pour traiter différents cas en fonction du tag de l'objet entrant en collision
        switch (other.tag)
        {
            // Cas où l'objet a le tag "ObjectToHit"
            case "ObjectToHit":
                if (this.CompareTag("BladeLeft") || this.CompareTag("BladeRight"))
                {
                    // Vérifie si cette lame touche l'objet de gauche ou de droite
                    bool isLeft = other.GetComponent<DestroyableObject>().isLeft;

                    // Vérifie si la lame correspond à la direction de l'objet à toucher
                    if ((isLeft && this.CompareTag("BladeLeft")) || (!isLeft && this.CompareTag("BladeRight")))
                    {
                    particles = isLeft ? GameObject.Find("fire_blue").GetComponent<ParticleSystem>() : GameObject.Find("fire_pink").GetComponent<ParticleSystem>();
                    particles.transform.position = other.transform.position;
                    Destroy(other.gameObject);
                    particles.Play();
                    if(isLeft){
                        VibL();
                    }else{
                        VibR();
                    }
                    audioSource.Play();
                    GlobalScore.Score += 1;

                    }
                }else{
                    Destroy(other.gameObject);
                }
                break;

            // Cas où l'objet a le tag "buzzer_pause"
            case "buzzer_pause":
                Debug.Log("buzzer");
                // Active la pause dans le gestionnaire de menu
                manager.GetComponent<MenuPauseManager>().PauseOn();
                break;

            // Cas où l'objet a le tag "Resume"
            case "Resume":
                // Désactive la pause dans le gestionnaire de menu
                manager.GetComponent<MenuPauseManager>().PauseOff();
                break;

            // Cas où l'objet a le tag "GoToPrincipal"
            case "GoToPrincipal":
                // Charge la scène du menu principal
                SceneManager.LoadScene("Menu");
                break;

            // Cas où l'objet a le tag "MenuPlay"
            case "MenuPlay":
                particles = GameObject.Find("fire_blue").GetComponent<ParticleSystem>();
                particles.transform.position = other.transform.position;
                particles.Play();
                audioSource.Play();
                GameObject.Find("cube_Play").SetActive(false);
                GameObject.Find("cube_Quit").SetActive(false);

                GameObject.Find("Select song").GetComponent<Elevate>().StartMoove();
                break;

            // Cas où l'objet a le tag "MenuQuit"
            case "MenuQuit":
                // Quitte l'application
                Application.Quit();
                break;

            // Cas où l'objet a le tag "EndWall"
            case "EndWall":
                // Appelle la méthode "End" du script attaché à l'objet "endgame"
                endgame.GetComponent<EndGame>().End();
                break;

            // Cas où l'objet a le tag "Retry"
            case "Retry":
                // Réinitialise le score global et recharge la scène actuelle
                GlobalScore.Score = 0;
                Application.LoadLevel(Application.loadedLevel);
                break;

            case "SelectNiveauMenu":
                if(GameObject.Find("Select song").GetComponent<Elevate>().GetPhase() == 3)
                {
                    int id=other.GetComponent<Id>().getId();

                    //show particules
                    particles = id == 0 ? GameObject.Find("fire_pink").GetComponent<ParticleSystem>() : GameObject.Find("fire_blue").GetComponent<ParticleSystem>();
                    particles.transform.position = other.transform.position;
                    particles.Play();
                    audioSource.Play();

                    //hide other cubes
                    other.transform.parent.transform.parent.gameObject.SetActive(false);

                    GameObject.Find("animDown").GetComponent<AnimGoDown>().AnimMenuDown(other.transform.parent.transform.parent, id);
                }

                break;
        }
    }

    // Méthode pour activer la vibration du contrôleur droit
    public void VibR()
    {
        Invoke("startVibR", .0001f);
        Invoke("stopVibR", .1f);
    }

    // Méthode pour démarrer la vibration du contrôleur droit
    public void startVibR()
    {
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
    }

    // Méthode pour arrêter la vibration du contrôleur droit
    public void stopVibR()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }

    // Méthode pour activer la vibration du contrôleur gauche
    public void VibL()
    {
        Invoke("startVibL", .0001f);
        Invoke("stopVibL", .15f);
    }

    // Méthode pour démarrer la vibration du contrôleur gauche
    public void startVibL()
    {
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
    }

    // Méthode pour arrêter la vibration du contrôleur gauche
    public void stopVibL()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }
}

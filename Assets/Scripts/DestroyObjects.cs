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

    // Méthode appelée au démarrage du script
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
                        // Obtient les particules associées à la couleur de l'objet touché
                        var particles = isLeft ? GameObject.Find("fire_blue").GetComponent<ParticleSystem>() : GameObject.Find("fire_pink").GetComponent<ParticleSystem>();
                        
                        // Positionne les particules sur l'objet touché, détruit l'objet et active les particules
                        particles.transform.position = other.transform.position;
                        Destroy(other.gameObject);
                        particles.Play();

                        // Active la vibration du contrôleur gauche ou droit, joue un son et met à jour le score global
                        if (isLeft)
                        {
                            VibL();
                        }
                        else
                        {
                            VibR();
                        }
                        audioSource.Play();
                        GlobalScore.Score += 1;
                    }
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
                // Charge la scène de la première chanson
                SceneManager.LoadScene("FirstSong");
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
        }
    }

    // Méthode pour activer la vibration du contrôleur droit
    public void VibR()
    {
        Invoke("startVibR", .1f);
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
        Invoke("startVibL", .1f);
        Invoke("stopVibL", .1f);
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

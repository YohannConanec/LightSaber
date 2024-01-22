using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevate : MonoBehaviour
{
    public float decalage = 1f; // Distance à laquelle l'objet doit s'élever
    public float decalage_ressort = 0.2f; // Distance à laquelle l'objet doit redescendre
    public float initspeed = 0.008f; // Vitesse initiale de déplacement
    private Vector3 posOffset = new Vector3(); // Position initiale de l'objet
    public int phase = 0; // Phase de déplacement
    private float speed; // Vitesse de déplacement
    private float initdeltaY; // Différence de hauteur initiale

    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position; // Stocke la position initiale de l'objet
        initdeltaY = posOffset.y + decalage - transform.position.y; // Calcule la différence de hauteur initiale
        if (transform.position.y < posOffset.y + decalage)
        {
            gameObject.GetComponent<Floating>().SetMoove(false); // Désactive le mouvement flottant si l'objet est en dessous de la position initiale
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 1)
        {
            if (transform.position.y < posOffset.y + decalage)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z); // Déplace l'objet vers le haut
                float delta = posOffset.y + decalage - transform.position.y; // Calcule la différence de hauteur actuelle
                speed = initspeed * delta / initdeltaY; // Calcule la vitesse de déplacement en fonction de la différence de hauteur
                if (speed < 0.0003f)
                {
                    speed = 0.0003f; // Vitesse minimale pour éviter un arrêt complet
                }
            }
            else
            {
                phase = 2; // Passe à la phase de descente
                posOffset = transform.position; // Met à jour la position initiale pour la descente
                initdeltaY = posOffset.y - decalage_ressort - transform.position.y; // Calcule la différence de hauteur initiale pour la descente
                initspeed = initspeed/3; // Stocke la vitesse de déplacement pour la descente
            }
        }
        if (phase == 2)
        {
            if (transform.position.y > posOffset.y - decalage_ressort)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z); // Déplace l'objet vers le bas
                float delta = transform.position.y - posOffset.y - decalage_ressort; // Calcule la différence de hauteur actuelle
                speed = initspeed * delta / initdeltaY; // Calcule la vitesse de déplacement en fonction de la différence de hauteur
                if (speed < 0.000f)
                {
                    speed = 0.0001f; // Vitesse minimale pour éviter un arrêt complet
                }
            }
            else
            {
                phase = 3; // Passe à la phase de fin de déplacement
                gameObject.GetComponent<Floating>().SetPosOffset(transform.position); // Met à jour la position de référence pour le mouvement flottant
                gameObject.GetComponent<Floating>().SetMoove(true); // Active le mouvement flottant
            }
        }
    }

    public void StartMoove()
    {
        phase = 1; // Réinitialise la phase de déplacement
    }
}

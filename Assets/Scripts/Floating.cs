using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public float amplitude = 0.08f; // Amplitude du mouvement de flottement
    public float speed = 0.0001f; // Vitesse du mouvement de flottement
    private Vector3 posOffset = new Vector3(); // Position initiale de l'objet
    private bool moove=true; // Indicateur pour activer ou désactiver le mouvement
    private bool phase= true; // indicateur pour la phase de montée ou de descente

    // Start est appelée avant le premier frame
    void Start()
    {
        posOffset = transform.position; // Stocke la position initiale de l'objet
    }

    // Update est appelée une fois par frame
    void Update()
    {
        if(moove)
        {
            // Si l'objet est en phase de montée
            if (phase)
            {
                // Si l'objet est en dessous de la position initiale
                if (transform.position.y < posOffset.y)
                {
                    // Déplace l'objet vers le haut
                    transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
                }
                else
                {
                    phase = false; // Passe à la phase de descente
                }
            }
            // Si l'objet est en phase de descente
            else
            {
                // Si l'objet est au dessus de la position initiale
                if (transform.position.y > posOffset.y - amplitude)
                {
                    // Déplace l'objet vers le bas
                    transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
                }
                else
                {
                    phase = true; // Passe à la phase de montée
                }
            }  
        }
    }

    // Méthode pour définir une nouvelle position initiale de l'objet
    public void SetPosOffset(Vector3 newPosOffset)
    {
        posOffset = newPosOffset;
    }

    // Méthode pour activer ou désactiver le mouvement de flottement
    public void SetMoove(bool newMoove)
    {
        moove = newMoove;
    }

    // Méthode pour obtenir la position verticale initiale de l'objet
    public float GetPosOffset()
    {
        return posOffset.y;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    private float amplitude = 0.02f; // Amplitude du mouvement de flottement
    private float frequency = 1f; // Fréquence du mouvement de flottement
    private Vector3 posOffset = new Vector3(); // Position initiale de l'objet
    private bool moove=true; // Indicateur pour activer ou désactiver le mouvement

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
            // Applique un mouvement de flottement à l'objet en utilisant la fonction sinus
            // pour créer une variation verticale de la position en fonction du temps
            transform.position = posOffset + new Vector3(0, Mathf.Sin(Time.time * frequency) * amplitude, 0);  
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
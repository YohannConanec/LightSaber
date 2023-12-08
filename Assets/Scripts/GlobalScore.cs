using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalScore : MonoBehaviour
{

    public static int Score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;


    void Update()
    {
        scoreText.text = "Score: " + Score;
    }


}
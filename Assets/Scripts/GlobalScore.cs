using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalScore : MonoBehaviour
{

    public static int Score = 0;
    public bool end=false;
    public int scoremax=291;
    [SerializeField] private TextMeshProUGUI scoreText;

    //score song 1 max 291
    void Update()
    {
        if(end){
            scoreText.text = "Score\n" + Score+"/"+scoremax+" "+(Score*100/scoremax)+"% ";
        }else{
        scoreText.text = "Score\n" + Score;
        }
    }

}

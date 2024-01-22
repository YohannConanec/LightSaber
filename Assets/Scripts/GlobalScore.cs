using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalScore : MonoBehaviour
{

    public static int Score = 0;
    public bool end=false;
    [SerializeField] private TextMeshProUGUI scoreText;

    //score song 1 max 291
    void Update()
    {
        if(end){
            scoreText.text = "Score\n" + Score+"/291  "+(Score*100/291)+"% ";
        }else{
        scoreText.text = "Score\n" + Score;
        }
    }

}

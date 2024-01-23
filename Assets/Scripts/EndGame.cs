using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject menu;
    public GameObject score;

 public void End()
    {
        menu.SetActive(true);
        score.GetComponent<GlobalScore>().end=true;
        GameObject.Find("buzzer").SetActive(false);
        GameObject.Find("pause Menu").SetActive(false);
    }
}

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
    }
}

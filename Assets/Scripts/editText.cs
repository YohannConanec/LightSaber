using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class editText : MonoBehaviour
{
     TextMeshPro text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        //text.SetText("Score: " + GlobalScore.Score);
        text.SetText("Score: ");
    }
}

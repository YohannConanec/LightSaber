using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isLeft= true;
    public Material matleft;
    public Material matright;
    void Start()
    {
        if(isLeft){
            GetComponent<Renderer>().material = matleft;
        }else{
            GetComponent<Renderer>().material = matright;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

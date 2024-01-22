using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMenu : MonoBehaviour
{
    public void launchScene(int idscene){
        switch(idscene){
            case 0:
                Debug.Log("Scene tuto");
                break;
            case 1:
                Debug.Log("Scene 1");
                break;
            case 2:
                Debug.Log("Scene 2");
                break;
            case 3:
                Debug.Log("Scene 3");
                break;
            case 4:
                Debug.Log("Scene 4");
                break;
        }
    }


}

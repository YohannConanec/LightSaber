using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimGoDown : MonoBehaviour
{
    public GameObject[] walls;
    public GameObject plafond;
    public GameObject pisteToReveal;

    public float interval = 0.5f; //seconds
    public float wallAnimDuration = 2.0f; //seconds
    public float Ythreshold = -4.2f; //seuil altitude
    public float pisteAnimSpeed = 2.0f;
    public float Ypistetarget = 2f; 
    private Transform _parentObj;
    private int _id;


    public void AnimMenuDown(Transform parentObj, int id)
    {
        _parentObj = parentObj;
        _id = id;   
        StartCoroutine(LaunchAnim());
    }

    IEnumerator LaunchAnim()
    {
        //le plafond monte
        StartCoroutine(TranslatePlafond(plafond, Vector3.down, Ythreshold, wallAnimDuration));

        //les 4 murs translatent vers le bas
        foreach (GameObject wall in walls)
        {
            print("call wall down");
            StartCoroutine(TranslateWall(wall, Vector3.down, Ythreshold, wallAnimDuration));
            yield return new WaitForSeconds(interval);
        }

        //la pise monte
        print("call piste down");
        StartCoroutine(TranslatePiste(pisteToReveal, Vector3.up, Ypistetarget, pisteAnimSpeed));

        //on cache le plafond et les murs
        plafond.SetActive(false);
        foreach(GameObject wall in walls)
        {
            wall.SetActive(false);
        }

    }

    IEnumerator TranslatePlafond(GameObject plafond, Vector3 targetDirection, float targetY, float duration)
    {
        Vector3 startPosition = plafond.transform.position;
        Vector3 targetPosition = startPosition + targetDirection * targetY;

        float spentTime = 0f;

        print("wall down");
        while (spentTime < duration && plafond.transform.position.y > targetY)
        {
            plafond.transform.position = Vector3.Lerp(startPosition, targetPosition, spentTime / duration);
            spentTime += Time.deltaTime;
            yield return null;
        }

        plafond.transform.position = targetPosition;
    }

    IEnumerator TranslateWall(GameObject wall, Vector3 targetDirection, float targetY, float duration)
    {
        Vector3 startPosition = wall.transform.position;
        Vector3 targetPosition = startPosition - targetDirection * targetY;

        float spentTime = 0f;

        print("wall down");
        while (spentTime < duration && wall.transform.position.y > targetY)
        {
            wall.transform.position = Vector3.Lerp(startPosition, targetPosition, spentTime / duration);
            spentTime += Time.deltaTime;
            yield return null;
        }

        wall.transform.position = targetPosition;

    }

    IEnumerator TranslatePiste(GameObject piste, Vector3 targetDirection, float targetY, float speed)
    {
        Vector3 startPosition = piste.transform.position;
        Vector3 targetPosition = startPosition + targetDirection * targetY;
        float spentTime = 0f;
        pisteToReveal.SetActive(true);

        print("pist up");
        while (piste.transform.position.y < targetPosition.y)
        {
            piste.transform.position = Vector3.Lerp(startPosition, targetPosition, spentTime * speed);
            spentTime += Time.deltaTime;
            yield return null;
        }

        piste.transform.position = targetPosition;

        //Load the level scene
        //SceneManager.LoadScene("FirstSong");
        _parentObj.GetComponent<SelectMenu>().launchScene(_id);
    }
    

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //pour gérer les fichiers


[System.Serializable]
public class ObjectData
{
    public float x;
    public float y;
    public float z;

    public ObjectData(Vector3 position)
    {
        x = position.x;
        y = position.y;
        z = position.z;
    }
}

public class AddObjects : MonoBehaviour
{

    public Transform wallcreaL;
    public Transform wallcreaR;
    public Transform hitzone;
    public GameObject emptyObject;
    public GameObject parentLeft;
    public GameObject parentRight;

    private Vector3 objPoseL;
    private Vector3 objPoseR;


    private string pathJSON = "Assets/Scripts/JSON/";


    public void InstanciateObject(bool left)
    {

        if (left) //LEFT BUTTON
        {
            objPoseL = new Vector3(wallcreaL.position.x, 1, hitzone.position.z);
            var newObject = Instantiate(emptyObject, objPoseL, Quaternion.identity);
            newObject.transform.parent = parentLeft.gameObject.transform;
  
            //add newObject.transform.position into JSON file :
            SavePositionToJson(pathJSON + "allObjL.json", newObject.transform.localPosition);
            
        }
        else //RIGHT BUTTON
        {

            objPoseR = new Vector3(wallcreaR.position.x, 1, hitzone.position.z);
            var newObject = Instantiate(emptyObject, objPoseR, Quaternion.identity);
            newObject.transform.parent = parentRight.gameObject.transform;

            //add newObject.transform.position into JSON file : 
            SavePositionToJson(pathJSON + "allObjR.json", newObject.transform.localPosition);
            
        }
       
    }

    public void InsertObjects()
    {
        foreach(string line in File.ReadAllLines(pathJSON + "allObjL.json"))
        {
            ObjectData objData = JsonUtility.FromJson<ObjectData>(line);

            var newObject = Instantiate(emptyObject, new Vector3(objData.x, objData.y, objData.z), Quaternion.identity);
            newObject.transform.parent = parentLeft.gameObject.transform;
        }

        foreach (string line in File.ReadAllLines(pathJSON + "allObjR.json"))
        {
            ObjectData objData = JsonUtility.FromJson<ObjectData>(line);
            var newObject = Instantiate(emptyObject, new Vector3(objData.x, objData.y, objData.z), Quaternion.identity);
            newObject.transform.parent = parentRight.gameObject.transform;
        }

        print("objects inserted");

    }

    private void SavePositionToJson(string fileName, Vector3 position)
    {
        //créer une instance de ObjectData avec la position :
        ObjectData objectData = new ObjectData(position);

        //convertir ObjectData en une chaîne JSON :
        string jsonData = JsonUtility.ToJson(objectData);

        //sauvegarder la chaîne JSON dans un fichier :
        File.AppendAllText(fileName, jsonData + "\n");
    }

    public void ClearJSON()
    {
        File.WriteAllText(pathJSON + "allObjL.json", string.Empty);
        File.WriteAllText(pathJSON + "allObjR.json", string.Empty);
    }



}

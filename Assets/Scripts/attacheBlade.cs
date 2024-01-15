using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacheBlade : MonoBehaviour
{
    public GameObject bladePrefab; // Assign your prefab in the Unity Editor
    public bool isLeftHand = true; // Set this to true if the prefab is for the left hand, false if for the right hand
    
    

    private void Start()
    {
        
        // Assuming you have a way to get the hand GameObject (OVRHand, etc.)
        GameObject handObject = GetHandObject(); // Implement this according to your setup

        if (handObject != null && bladePrefab != null)
        {
            // Instantiate the prefab and make it a child of the hand
            GameObject prefabInstance = Instantiate(bladePrefab, handObject.transform);
            // Optionally, adjust the position, rotation, and scale of the prefab to fit the hand
            prefabInstance.transform.localPosition = Vector3.zero;
            if(isLeftHand){
                prefabInstance.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
            }else{
                prefabInstance.transform.localRotation = Quaternion.Euler(180f, 0f, 90f);
                }
            handObject.GetComponent<OVRMeshRenderer>().enabled = false;
        }
    }

    // Implement the method to get the hand object based on your setup
    private GameObject GetHandObject()
    {
        // Implement this method based on how you are getting the hand object
        // For example, you might use OVRHand.HandLeft or OVRHand.HandRight
        // Return the GameObject representing the hand
        OVRHand[] ovrHands = FindObjectsOfType<OVRHand>();
            // Check if the OVRHand has the same hand type (left or right) as your prefab
            if (isLeftHand)
            {
                // Return the GameObject representing the hand
                return ovrHands[0].gameObject;
            }else{
                return ovrHands[1].gameObject;
            }
        

        // Return null if no matching hand object is found
        return null;
    }
}
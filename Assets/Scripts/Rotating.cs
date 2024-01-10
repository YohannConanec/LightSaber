using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float RotationSpeed = 20f;
    private float randomRight; //random -1 or 1
    private float randomUp;
    private float randomForward;

    private void Start()
    {
        randomRight = (Random.Range(0, 2) == 0) ? 1 : -1;
        randomUp = (Random.Range(0, 2) == 0) ? 1 : -1;
        randomForward = (Random.Range(0, 2) == 0) ? 1 : -1;
    }
    void Update()
    {
        transform.Rotate(randomRight * Vector3.right * RotationSpeed * Time.deltaTime +
                        randomUp * Vector3.up * RotationSpeed * Time.deltaTime +
                        randomForward * Vector3.forward * RotationSpeed * Time.deltaTime, Space.Self);

    }
}

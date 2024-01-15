using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform _movingObjects;
    private float speed;

    void Start()
    {
        speed = 4;
    }
    private void Update()
    {
        _movingObjects.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }




}

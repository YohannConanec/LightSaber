using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform _movingObjects;
    [SerializeField] private float _speed;


    private void Update()
    {
        _movingObjects.Translate(Vector3.forward * _speed * Time.deltaTime);
    }





}

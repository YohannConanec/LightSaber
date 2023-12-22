using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shape
{
    Cube,
    Cone,
    Sphere,
    Torus
};

public class ShapeChoice : MonoBehaviour
{
    [SerializeField] private GameObject PrefabCube;
    [SerializeField] private GameObject PrefabCone;
    [SerializeField] private GameObject PrefabSphere;
    [SerializeField] private GameObject PrefabTorus;


    [SerializeField] public Shape chosenShape = new Shape();

    private void Start()
    {
        
        switch (chosenShape)
        {
            case Shape.Cube:
                GameObject cube = Instantiate(PrefabCube, transform.position, Quaternion.identity);
                cube.transform.parent = this.transform;
                //cube.transform.localPosition = Vector3.zero;
                break;

            case Shape.Cone:
                GameObject cone = Instantiate(PrefabCone, transform.position, Quaternion.identity);
                cone.transform.parent = this.transform;
                break;

            case Shape.Sphere:
                GameObject sphere = Instantiate(PrefabSphere, transform.position, Quaternion.identity);
                sphere.transform.parent = this.transform;
                break;

            case Shape.Torus:
                GameObject torus = Instantiate(PrefabTorus, transform.position, Quaternion.identity);
                torus.transform.parent = this.transform;
                break;
        }
        
    }




}







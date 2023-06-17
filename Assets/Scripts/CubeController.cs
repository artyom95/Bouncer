using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class CubeController : FigureBehaviour
{
    [SerializeField] private GameObject _plane;

    [SerializeField] private GameObject _prefabCube;
    
   
    private GameObject _cube;
    private Rigidbody _cubeRigidBody;
    private static Color _currentColor; // сделать синглтон;
    const float Force = 250f;

    //  private const float LineBorder = 9.5f;

    // Start is called before the first frame update

    private void Start()
    {
        ColliderBorderBehaviour.OffSiteCube += SpawnCube;
        ColliderBorderBehaviour.SetColor += SaveCurrentColor;
      
    }


    public void SpawnCube()
    {
        _cube = FigureBehaviour.Initialize(_prefabCube, _plane);

        _cube.transform.localPosition = FigureBehaviour.ObjectSetCentrePosition();

        _cubeRigidBody = _cube.GetComponent<Rigidbody>();
        SetColor();
    }

    private void SetColor()
    {
        if (_currentColor != default)
        {
            _cube.GetComponent<MeshRenderer>().material.color = _currentColor;
        }
        else
        {
            _cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

    private void SaveCurrentColor()
    {
        _currentColor = _cube.GetComponent<MeshRenderer>().material.color;
    }

    public void MoveCube(Vector3 mousePoint)
    {
        _cubeRigidBody.AddForce((mousePoint - _cube.transform.position).normalized * Force);
    }

    private void OnDestroy()
    {
        ColliderBorderBehaviour.OffSiteCube -= SpawnCube;
      
    }


    
}
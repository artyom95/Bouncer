using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private CubeController _cubeController;

    [SerializeField] private MousePointProvider _mousePointProvider;
    [SerializeField] private CylinderController _cylinderController;
    [SerializeField] private SphereController _sphereController;
    [SerializeField] private CountManager _countManager;


    private void Start()
    {
        _cubeController.SpawnCube();
        _sphereController.SpawnSphere();
        _cylinderController.AccomodateCylinder();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo))
            {
                var positionMousePoint = _mousePointProvider.GetMouseCoordinates(hitInfo.point);
                _cubeController.MoveCube(positionMousePoint);
                _countManager.IncreaseAmountMouseClicks();
            }
        }

        //  _cubeController.CheckPosition();
    }
}
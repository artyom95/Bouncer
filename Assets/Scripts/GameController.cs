using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private CubeController _cubeController;
    
    [SerializeField] private MousePointProvider _mousePointProvider;
    private Vector3 _placeforClick;


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
            }
        }

        _cubeController.CheckPosition();
    }
}
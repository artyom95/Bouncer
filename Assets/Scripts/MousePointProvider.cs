using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointProvider : MonoBehaviour
{
    [SerializeField] private GameObject _plane;
    public Vector3 GetMouseCoordinates(Vector3 mousePosition)
    {
       // var transformVector = _plane.transform.InverseTransformDirection(mousePosition);
       // Vector3 pointClick = new Vector3(transformVector.x, 0f, transformVector.z);
        Vector3 pointClick = new Vector3(mousePosition.x, 0f, mousePosition.z);
        return pointClick;
    }
    
}

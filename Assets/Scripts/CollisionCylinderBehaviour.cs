using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DecreaseAmountCylinder(string s1, string s);

public class CollisionCylinderBehaviour : MonoBehaviour
{
    private Color _currentColorCylinder;
    public static event DecreaseAmountCylinder decreaseAmuountCylinder;

    private void OnCollisionEnter(Collision collision)
    {
        _currentColorCylinder = gameObject.GetComponent<MeshRenderer>().material.color;
        if (gameObject.CompareTag(GlobalConstant.CYLINDER_TAG) &&
            collision.gameObject.CompareTag(GlobalConstant.PLAYER_TAG))
        {
            if (AreColorEquals(collision.gameObject))
            {
                CheckCylinderToColor();
                Destroy(this.gameObject);
            }
        }
    }

    private bool AreColorEquals(GameObject cube)
    {
        if (_currentColorCylinder == cube.GetComponent<MeshRenderer>().material.color)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void CheckCylinderToColor()
    {
        if (_currentColorCylinder == Color.green)
        {
            decreaseAmuountCylinder?.Invoke("green", "decrease");

            return;
        }

        if (_currentColorCylinder == Color.red)
        {
            decreaseAmuountCylinder?.Invoke("red", "decrease");

            return;
        }

        if (_currentColorCylinder.Equals(Color.yellow))
        {
            decreaseAmuountCylinder?.Invoke("yellow", "decrease");
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class FigureBehaviour : MonoBehaviour
{
    private static readonly Vector2 _borderLine = new Vector2(-4.0f, 4.0f);

    private static readonly Vector3 _centrePosition = new Vector3(0f, 0f, 0f); 
   

   

    // Start is called before the first frame update
    protected static GameObject Initialize(GameObject prefab, GameObject parent)
    {
        var gameObject = Instantiate(prefab);
        gameObject.transform.SetParent(parent.transform);
        

        return gameObject;
    }

    protected static Vector3 ObjectSetPosition()
    {
        var positionX = GetPoint();
        var positionZ = GetPoint();
        var positionY = 0.65f;
        var numberCombination = Random.Range(0, 7);
        if (numberCombination %2 ==0)
        {
            return new Vector3(positionX, positionY, positionZ);
        }
        return new Vector3(positionZ, positionY, positionX);
    }

    protected static Vector3 ObjectSetCentrePosition()
    {
        var positionCentre = _centrePosition;
        return positionCentre;
    }

    private static float GetPoint()
    {
        var point = Random.Range(_borderLine.x, _borderLine.y);
        return point;
    }

   
}
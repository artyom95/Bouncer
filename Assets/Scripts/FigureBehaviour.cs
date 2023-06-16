using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class FigureBehaviour : MonoBehaviour
{
    private static Vector2 _borderLine = new Vector2(-4.0f, 4.0f);

    private static Vector3 _centrePosition = new Vector3(0f, 0f, 0f); 
   

   

    // Start is called before the first frame update
    public static GameObject Initialize(GameObject prefab, GameObject parent)
    {
        var gameObject = Instantiate(prefab);
        
      
        gameObject.transform.SetParent(parent.transform);
        

        return gameObject;
    }

    public static Vector3 ObjectSetPosition()
    {
        var positionX = GetPoint();
        var positionZ = GetPoint();
        var positionY = 0.55f;
        return new Vector3(positionX, positionY, positionZ);
    }

    public static Vector3 ObjectSetCentrePosition()
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
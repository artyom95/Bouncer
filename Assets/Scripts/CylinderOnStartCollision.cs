using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CylinderOnStartCollision : MonoBehaviour
{
    [SerializeField] private List<GameObject> _gameObjects = new List<GameObject>();
   // public static Action InstatiateCube;
   // public static Action InstantiateCylinder;
  //  public static Action InstantiateSphere;


    // Start is called before the first frame update
    private void Awake()
    {
        //    CylinderController.CheckCollisionCylinder += CheckPosition;
    }


    public void CheckPosition(GameObject gameObject)
    {
        Collider[] _colliders =
            Physics.OverlapBox(gameObject.transform.localPosition, new Vector3(3.0f, 0.5f, 3.0f));
        if ((_colliders.Length > 0))
        {
            Destroy(gameObject.gameObject);
            Debug.Log("Collision detected with ");
            Debug.Log(gameObject.transform.localPosition.x);

            Debug.Log(gameObject.transform.localPosition.y);

            Debug.Log(gameObject.transform.localPosition.z);

          //  InstantiateCylinder?.Invoke();
        }
    }


    private void OnDestroy()
    {
        //  CylinderController.CheckCollisionCylinder -= CheckPosition;
    }
}
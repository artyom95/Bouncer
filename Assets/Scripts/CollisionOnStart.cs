using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CollisionOnStart : MonoBehaviour
{
    [SerializeField] private  List<GameObject> _gameObjects = new List<GameObject>();
    public static Action InstatiateCube;
    public static Action InstantiateCylinder;
    public static Action InstantiateSphere;

    private bool _isStartedGame = true;

    // Start is called before the first frame update
   private void Start()
    {
       CheckSphere();
       
    }
  

   public void CheckSphere()
   {
       Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, 0.45f);
       if (colliders.Length >1)
       {
           for (int i = 0; i < colliders.Length; i++)
           {
               if (AreColliderDifferent(colliders[i], colliders[0]) )
               {
                   switch (colliders[i].gameObject.tag)
                   {
                       case GlobalConstant.PLAYER_TAG :
                           Destroy(colliders[0].gameObject);
                           InstantiateCylinder?.Invoke();
                           Debug.Log("Cube was destroyed"  + "actually cylinder");

                           break;
                       case GlobalConstant.SPHERE_TAG :
                           Destroy(colliders[i].gameObject);
                           InstantiateSphere?.Invoke();
                           Debug.Log("Sphere was destroyed" );

                           break;
                       case GlobalConstant.CYLINDER_TAG :
                           Destroy(colliders[i].gameObject);
                           Debug.Log("Cylinder was destroyed");
                        //   Destroy(colliders[0].gameObject);
                           InstantiateCylinder?.Invoke();
                          // Debug.Log("Cylinder was destroyed");
                           break;
                   }
                 //  Debug.Log("Somethingis here");
               }  
           }
       }
       

       
   }

   private bool AreColliderDifferent(Collider firstCollider, Collider secondCollider)
   {
       if (secondCollider != default && firstCollider.gameObject.transform.position != secondCollider.gameObject.transform.position )
       {
           return true;
       }

       return false;
   }
}


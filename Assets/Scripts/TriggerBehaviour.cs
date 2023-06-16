using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerBehaviour : MonoBehaviour
{
    public static Action InstantiateObject;


    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag(GlobalConstant.SPHERE_TAG) && other.CompareTag(GlobalConstant.PLAYER_TAG))
        {
            other.gameObject.GetComponent<MeshRenderer>().material.color =
                GetComponent<MeshRenderer>().material.color;
            Destroy(this.gameObject);
            InstantiateObject?.Invoke();
        }
        
    }

   

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCylinderBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag(GlobalConstant.CYLINDER_TAG) && collision.gameObject.CompareTag(GlobalConstant.PLAYER_TAG))
        {
            if (AreColorEquals(collision.gameObject))
            {
                Destroy(this.gameObject);
            }
        }
    }

    private bool AreColorEquals(GameObject cube)
    {
        if (gameObject.GetComponent<MeshRenderer>().material.color == cube.GetComponent<MeshRenderer>().material.color)
        {
            return true;
        }
        else
        {
            return false;
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
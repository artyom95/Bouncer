using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CylinderController : MonoBehaviour
{
    
    [SerializeField] 
    private GameObject _cylinderPrefab;

    [SerializeField] 
    private GameObject _plane;

    [SerializeField] 
    private List<Color> _colors = new ();

  //  [SerializeField] private CubeController _cubeController;    // убрать
    private int _amountCylinder = 6;

    private GameObject _cylinder;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _amountCylinder; i++)
        {
            Instance();
        }
    }

    private void Instance()
    {
        var positionX = GetPoint();
        var positionY = GetPoint();

        _cylinder = Instantiate(_cylinderPrefab);
        _cylinder.transform.SetParent(_plane.transform);
        _cylinder.transform.localPosition = new Vector3(positionX, 0.5f, positionY);
        _cylinder.GetComponent<MeshRenderer>().material.color = GetColor();
    }

    private Color GetColor()
    {
        var number = Random.Range(0, 3);
        var color = _colors[number];
        return color;
    }
    private float GetPoint()
    {
        var point = Random.Range(-4.0f, 4.0f);
        return point;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.gameObject.GetComponent<MeshRenderer>().material.color ==  _cylinder.GetComponent<MeshRenderer>().material.color )
            {
                Destroy(_cylinder);
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SphereController : MonoBehaviour
{
    [SerializeField] private GameObject _spherePrefab;

    [SerializeField] private GameObject _plane;

    [SerializeField] private List<Color> _colors = new();


    private GameObject _sphere;

    // Start is called before the first frame update
    void Start()
    {
        Instance();
    }

    public void Instance()
    {
        var positionX = GetPoint();
        var positionY = GetPoint();

        _sphere = Instantiate(_spherePrefab);
        _sphere.transform.SetParent(_plane.transform);
        _sphere.transform.localPosition = new Vector3(positionX, 0.5f, positionY);
        _sphere.GetComponent<MeshRenderer>().material.color = GetColor();
       
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

    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.gameObject.GetComponent<MeshRenderer>().material.color =
                    _sphere.GetComponent<MeshRenderer>().material.color;
                Destroy(_sphere);
                Instance();
            }
        }
    
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SphereController : FigureBehaviour
{
    [SerializeField] private GameObject _spherePrefab;

    [SerializeField] private GameObject _plane;


    [SerializeField] private ProviderColor _providerColor;

    private GameObject _sphere;
   

    // Start is called before the first frame update
    private void Start()
    {
        TriggerBehaviour.InstantiateObject += SpawnSphere;
        CylinderOnStartCollision.InstantiateSphere += SpawnSphere;
       
    }

    public void SpawnSphere()
    {
        _sphere = FigureBehaviour.Initialize(_spherePrefab, _plane);
        _sphere.transform.localPosition = FigureBehaviour.ObjectSetPosition();
        _sphere.GetComponent<MeshRenderer>().material.color = _providerColor.GetColor();
    }


    private void OnDestroy()
    {
        TriggerBehaviour.InstantiateObject -= SpawnSphere;
        CylinderOnStartCollision.InstantiateSphere -= SpawnSphere;
       
    }

   
}
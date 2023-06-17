using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CylinderController : FigureBehaviour
{
    [SerializeField] private GameObject _cylinderPrefab;

    [SerializeField] private GameObject _plane;

    [SerializeField] private ProviderColor _providerColor;
    [SerializeField] private CylinderOnStartCollision _collisionOnStart;

    private int _amountCylinder = 6;

    private GameObject _cylinder;
    //  public static Action <GameObject> CheckCollisionCylinder;

    private void Start()
    {
        CylinderOnStartCollision.InstantiateCylinder += SpawnCylinder;
    }

    // Start is called before the first frame update
    public void AccomodateCylinder()
    {
        for (int i = 0; i < _amountCylinder; i++)
        {
            SpawnCylinder();
        }
    }

    private void SpawnCylinder()
    {
        _cylinder = FigureBehaviour.Initialize(_cylinderPrefab, _plane);

        _cylinder.transform.localPosition = FigureBehaviour.ObjectSetPosition();

        // CheckCollisionCylinder?.Invoke(_cylinder);
        _cylinder.GetComponent<MeshRenderer>().material.color = _providerColor.GetColor();
    }


    private void OnDestroy()
    {
        CylinderOnStartCollision.InstantiateCylinder -= SpawnCylinder;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CylinderController : FigureBehaviour
{
    [SerializeField] 
    private GameObject _cylinderPrefab;
    [SerializeField] 
    private GameObject _plane;
    [SerializeField] 
    private ProviderColor _providerColor;
    [SerializeField] 
    private CountManager _countManager;
    [SerializeField]
    private CylinderOnStartCollision _collisionOnStart;

    private int _amountCylinder = 6;
    private GameObject _cylinder;
    private Color _currentColorCylinder;
    //  public static Action <GameObject> CheckCollisionCylinder;

    private void Start()
    {
       
        //   CylinderOnStartCollision.InstantiateCylinder += SpawnCylinder;
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
        _currentColorCylinder = _providerColor.GetColor();
        _cylinder.GetComponent<MeshRenderer>().material.color = _currentColorCylinder;
        CheckCylinderToColor();
    }

    private void CheckCylinderToColor()
    {
        if (_currentColorCylinder == Color.green)
        {
            _countManager.SetAmountColorCylinder("green", "increase");
            return;
        }

        if (_currentColorCylinder == Color.red)
        {
            _countManager.SetAmountColorCylinder("red", "increase");
            return;
        }

        if (_currentColorCylinder.Equals(Color.yellow))
        {
            _countManager.SetAmountColorCylinder("yellow", "increase");
        }
    }

    private void OnDestroy()
    {
        //   CylinderOnStartCollision.InstantiateCylinder -= SpawnCylinder;
    }
}
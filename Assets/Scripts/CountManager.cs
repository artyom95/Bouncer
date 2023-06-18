using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountManager : MonoBehaviour
{
    [SerializeField] 
    private GameController _gameController;
    [SerializeField] 
    private UiController _uiController;
    private int _countMouseClick = 0;
    private int _countRedCylinder = 0;
    private int _countYellowCylinder = 0;
    private int _countGreenCylinder = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        CollisionCylinderBehaviour.decreaseAmuountCylinder += SetAmountColorCylinder;
    }

    public void IncreaseAmountMouseClicks()
    {
        _countMouseClick++;
        _uiController.SetAmountClick(_countMouseClick);
    }

    public void SetAmountColorCylinder(string color, string state)
    {
        if (state.Equals("increase"))
        {
            switch (color)
            {
                case "green":
                    _countGreenCylinder++;
                    _uiController.SetAmountCylinder(_countGreenCylinder, "green");
                    break;
                case "yellow":
                    _countYellowCylinder++;
                    _uiController.SetAmountCylinder(_countYellowCylinder, "yellow");
                    break;
                case "red":
                    _countRedCylinder++;
                    _uiController.SetAmountCylinder(_countRedCylinder, "red");
                    break;
            }
        }
        else if (state.Equals("decrease"))
        {
            switch (color)
            {
                case "green":
                    _countGreenCylinder--;
                    _uiController.SetAmountCylinder(_countGreenCylinder, "green");
                    break;
                case "yellow":
                    _countYellowCylinder--;
                    _uiController.SetAmountCylinder(_countYellowCylinder, "yellow");
                    break;
                case "red":
                    _countRedCylinder--;
                    _uiController.SetAmountCylinder(_countRedCylinder, "red");
                    break;
            }
        }
    }

    private void OnDestroy()
    {
        CollisionCylinderBehaviour.decreaseAmuountCylinder -= SetAmountColorCylinder;
    }
}
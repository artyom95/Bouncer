using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Image = UnityEngine.UI.Image;

public class UiController : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI _amountMouseClick;
    [SerializeField] 
    private GameObject _mouseIconClick;
    [SerializeField]
    private GameObject _IconRedCylinder;
    [SerializeField] 
    private GameObject _IconGreenCylinder;
    [SerializeField] 
    private GameObject _IconYellowCylinder;
    [SerializeField]
    private TextMeshProUGUI _amountGreenCylinder;
    [SerializeField]
    private TextMeshProUGUI _amountYellowCylinder;
    [SerializeField] 
    private TextMeshProUGUI _amountRedCylinder;

    // Start is called before the first frame update
    private void Start()
    {
        _mouseIconClick.SetActive(true);
    }

    public void SetAmountClick(int amount)
    {
        _amountMouseClick.text = amount.ToString();
    }

    public void SetAmountCylinder(int amount, string color)
    {
        switch (color)
        {
            case "green":
                _amountGreenCylinder.text = amount.ToString();
                if (amount > 0)
                {
                    _IconGreenCylinder.SetActive(true);
                }
                else
                {
                    _IconGreenCylinder.SetActive(false);
                }

                break;
            case "yellow":
                _amountYellowCylinder.text = amount.ToString();
                if (amount > 0)
                {
                    _IconYellowCylinder.SetActive(true);
                }
                else
                {
                    _IconYellowCylinder.SetActive(false);
                }

                break;
            case "red":
                _amountRedCylinder.text = amount.ToString();
                if (amount > 0)
                {
                    _IconRedCylinder.SetActive(true);
                }
                else
                {
                    _IconRedCylinder.SetActive(false);
                }

                break;
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
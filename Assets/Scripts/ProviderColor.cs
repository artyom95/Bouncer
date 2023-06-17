using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProviderColor : MonoBehaviour
{
    [SerializeField] private List<Color> _colors = new();

    public Color GetColor()
    {
        var number = Random.Range(0, _colors.Count);
        var color = _colors[number];
        return color;
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
  
}

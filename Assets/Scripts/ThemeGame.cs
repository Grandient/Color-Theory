using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that deals with the color theming game
public class ThemeGame : MonoBehaviour
{
    // Canvas
    public GameObject Canvas;

    // Colors
    public List<GameObject> ColorsGO;
    public List<Color> Colors;

    // Values
    public Color SelectedValue = new Color();
    public Color TrueValue = new Color();

    // Results
    public GameObject Result;
    public GameObject SelectedColor;

    // Increment
    public int increment = 25;
    List<int> possibleValues = new List<int>();
    System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        DivisibleByIncrement();
        GenerateColors(9);
        AddColors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DivisibleByIncrement()
    {
        int max = 0;
        while (max+increment <= 255)
        {
            max += increment;
            possibleValues.Add(max);
        }
    }

    public void GenerateColors(int length)
    {
        int truthSpot = rand.Next(0, possibleValues.Count - 1);
        for (int i = 0; i < length; i++)
        {
            if (truthSpot == i)
            {
                Color result = GetComplement(TrueValue);
                Colors.Add(result);
                continue;
            }
            float max = 255;
            float red = possibleValues[rand.Next(0, possibleValues.Count - 1)]/max;
            float green = possibleValues[rand.Next(0, possibleValues.Count - 1)]/max;
            float blue = possibleValues[rand.Next(0, possibleValues.Count - 1)]/max;

            Colors.Add(new Color(red, green, blue));
        }
        Debug.Log(Colors.Count);
    }

    public Color GetComplement(Color value)
    {
        return Color.clear;
    }

    public void AddColors()
    {
        int length = Canvas.transform.childCount;
        for (int i = 0; i < length; i++)
        {
            CM.SetColorMaterialTransform(Colors[i], Canvas.transform.GetChild(i));
            Debug.Log(CM.GetColorMaterialTransform(Canvas.transform.GetChild(i)));
        }
    }

    public void Select(Color select)
    {
        CM.SetColorMaterialTransform(select, SelectedColor.transform);
    }


    public void Match()
    {
        if (SelectedValue == TrueValue)
        {
            Debug.Log("Color Matched");
            CM.SetColorMaterialTransform(Color.green, Result.transform);
        }
        else
        {
            Debug.Log("Color Not matched");
            CM.SetColorMaterialTransform(Color.red, Result.transform);
        }
    }
}



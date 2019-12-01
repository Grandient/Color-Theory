using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that deals with the color theming game
public class ThemeGame : MonoBehaviour
{
    public Camera cam;
    // Canvas
    public GameObject Canvas;

    // Colors
    public List<Color> Colors;

    // Values
    public Color SelectedValue = new Color();
    public Color TrueValue = new Color();
    public Color BaseValue = new Color();

    // Results
    public GameObject Result;
    public GameObject SelectedColor;
    public GameObject BaseValueGO;

    // Increment
    public int increment = 25;
    List<int> possibleValues = new List<int>();
    System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        SetBaseValue();
        DivisibleByIncrement();
        GenerateColors(9);
        AddColors();
    
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.transform.parent.name == "Colors")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Pressed primary button.");
                Select(CM.GetColorMaterialTransform(hit.transform));
            }
        }
        else if (Physics.Raycast(ray, out hit) && hit.transform.name == "PickedColor")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Match();
            }
        }
    }

    public void SetBaseValue()
    {
        BaseValue = Color.red;
        CM.SetColorMaterialTransform(BaseValue, BaseValueGO.transform);
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
                Color result = GetComplement(BaseValue);
                TrueValue = result;
                Colors.Add(result);
                continue;
            }
            
            Colors.Add(GenerateRandomColor());
        }
        Debug.Log(Colors.Count);
    }

    public Color GenerateRandomColor()
    {
        float max = 255;
        float red = possibleValues[rand.Next(0, possibleValues.Count - 1)] / max;
        float green = possibleValues[rand.Next(0, possibleValues.Count - 1)] / max;
        float blue = possibleValues[rand.Next(0, possibleValues.Count - 1)] / max;
        return new Color(red, green, blue);
    }

    public Color GetComplement(Color color)
    {
        float hue = 0;
        float saturation = 0;
        float value = 0;
        Color.RGBToHSV(color, out hue, out saturation, out value);

        float newhue = (hue + 0.5f) % 1f;
        color = Color.HSVToRGB(newhue, saturation, value);
        return color;
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
        SelectedValue = select;
        CM.SetColorMaterialTransform(SelectedValue, SelectedColor.transform);
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



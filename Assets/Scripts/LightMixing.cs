using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMixing : MonoBehaviour
{
    // Material for Line
    public Material LineMaterial;

    // Lasers
    LineRenderer RedLaser;
    LineRenderer GreenLaser;
    LineRenderer BlueLaser;
    LineRenderer OutputLaser;

    // Mirror Gameobject
    public GameObject Mirror;

    // Laser GameObject
    public GameObject RedLaserGO;
    public GameObject GreenLaserGO;
    public GameObject BlueLaserGO;
    public GameObject OutputLaserGO;

    // Current Color
    public Color RedValue = Color.red;
    public Color GreenValue = Color.green;
    public Color BlueValue = Color.blue;
    public Color OutputVal;

    // Current Color String
    public string RedValueStr = "";
    public string GreenValueStr = "";
    public string BlueValueStr = "";
    public string OutputValueStr = "";

    // Boolean
    bool Red = true;
    bool Green = false;
    bool Blue = false;

    // Selections
    KeyCode left = KeyCode.Alpha0;
    KeyCode right = KeyCode.Alpha1;
    
    // Power
    KeyCode up = KeyCode.Alpha2;
    KeyCode down = KeyCode.Alpha3;

    // Index
    // 0 = Red
    // 1 = Green
    // 2 = Blue
    public int index = 0;

    // Variable
    public int increment = 25;

    // Start is called before the first frame update
    void Start()
    {
        OutputVal = Color.white;
        RedLaser = RedLaserGO.AddComponent<LineRenderer>();
        GreenLaser = GreenLaserGO.AddComponent<LineRenderer>();
        BlueLaser = BlueLaserGO.AddComponent<LineRenderer>();
        OutputLaser = OutputLaserGO.AddComponent<LineRenderer>();

        CM.DrawLineBetweenTwoVectors(RedLaserGO.transform.position, Mirror.transform.position, RedValue, LineMaterial, RedLaserGO, RedLaser, false);
        CM.DrawLineBetweenTwoVectors(BlueLaserGO.transform.position, Mirror.transform.position, BlueValue, LineMaterial, BlueLaserGO, BlueLaser, true);
        CM.DrawLineBetweenTwoVectors(GreenLaserGO.transform.position, Mirror.transform.position, GreenValue, LineMaterial, GreenLaserGO, GreenLaser, false);
        CM.DrawLineBetweenTwoVectors(Mirror.transform.position, OutputLaserGO.transform.position, OutputVal, LineMaterial, OutputLaserGO, OutputLaser, true);
    }

    // Update is called once per frame
    void Update()
    {
        // Switch left
        if (Input.GetKeyDown(left))
        {
            Red = false;
            Green = false;
            Blue = false;
            switch (index)
            {
                case 0:
                    Debug.Log("Cannot turn left");
                    Red = true;
                    break;
                case 1:
                    Red = true;
                    index--;
                    break;
                case 2:
                    Green = true;
                    index--;
                    break;
                default:
                    break;
            }
        }

        PrintColor();

        // Switch Right
        if (Input.GetKeyDown(right))
        {
            Red = false;
            Green = false;
            Blue = false;
            switch (index)
            {
                case 0:
                    Green = true;
                    index++;
                    break;
                case 1:
                    Blue = true;
                    index++;
                    break;
                case 2:
                    Debug.Log("Cannot turn right");
                    Blue = true;
                    break;
                default:
                    break;
            }
        }

        if (Red)
        {
            if (Input.GetKeyDown(up))
            {
                ChangeRed(true);
            }

            if (Input.GetKeyDown(down))
            {
                ChangeRed(false);
            }
            
        }

        if (Green)
        {
            ChangeGreen();
        }

        if (Blue)
        {
            ChangeBlue();
        }
    }

    public void Match()
    {

    }

    public void Brighten()
    {

    }

    public void Darken()
    {

    }

    public void ChangeRed(bool up)
    {
        string result = CM.ConvertToHex(OutputVal);
        string redstr = result[1].ToString() + result[2].ToString();
        int red = int.Parse(redstr, System.Globalization.NumberStyles.HexNumber);
        int newred = 0;
        if (up)
        {
            newred = red + increment;
        } else
        {
            newred = red - increment;
        }
        
        string hexValue = newred.ToString("X");
        RedValue = new Color(newred, 0f, 0f);
        CM.DrawLineBetweenTwoVectors(RedLaserGO.transform.position, Mirror.transform.position, RedValue, LineMaterial, RedLaserGO, RedLaser, false);
    }

    public void ChangeGreen()
    {

    }

    public void ChangeBlue()
    {

    }

    public void PrintColor()
    {
        string result = CM.ConvertToHex(OutputVal);
        Debug.Log("Color: " + result);
        string redstr = result[1].ToString() + result[2].ToString();
        string greenstr = result[3].ToString() + result[4].ToString();
        string bluestr = result[3].ToString() + result[4].ToString();

        int red = int.Parse(redstr, System.Globalization.NumberStyles.HexNumber);
        int green = int.Parse(greenstr, System.Globalization.NumberStyles.HexNumber); 
        int blue = int.Parse(bluestr, System.Globalization.NumberStyles.HexNumber);
        Debug.Log("Red: " + red + " Green: " + green + " Blue: " + blue);

        string hexValue = red.ToString("X");
        Debug.Log("NewRed: " + hexValue);

    }
}

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
            Debug.Log("Left");
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
            Debug.Log("Right");
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
                Debug.Log("Up");
                ChangeRed(true);
            }

            if (Input.GetKeyDown(down))
            {
                Debug.Log("Down");
                ChangeRed(false);
            }
            
        }

        if (Green)
        {
            if (Input.GetKeyDown(up))
            {
                Debug.Log("Up");
                ChangeGreen(true);
            }

            if (Input.GetKeyDown(down))
            {
                Debug.Log("Down");
                ChangeGreen(false);
            }
        }

        if (Blue)
        {
            if (Input.GetKeyDown(up))
            {
                Debug.Log("Up");
                ChangeBlue(true);
            }

            if (Input.GetKeyDown(down))
            {
                Debug.Log("Down");
                ChangeBlue(false);
            }
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
        string result = CM.ConvertToHex(RedValue);
        string redstr = result[1].ToString() + result[2].ToString();
        int red = int.Parse(redstr, System.Globalization.NumberStyles.HexNumber);

        int newred = 0;
        if (up)
        {
            if(red+increment >= 255)
            {
                Debug.Log("Red at maximum");
                return;
            } else
            {
                newred = red + increment;
            }
            
        } else {

            if(red-increment<= 0)
            {
                Debug.Log("Red at zero");
                return;
            } else
            {
                newred = red - increment;
            }
            
        }

        Debug.Log(newred);
        string hexValue = "#" + newred.ToString("X") + "0000";
        RedValue = CM.ConvertToColor(hexValue);
        
        CM.DrawLineBetweenTwoVectors(RedLaserGO.transform.position, Mirror.transform.position, RedValue, LineMaterial, RedLaserGO, RedLaser, false);
        ChangeOutput();
    }

    public void ChangeGreen(bool up)
    {
        string result = CM.ConvertToHex(GreenValue);
        string greenstr = result[3].ToString() + result[4].ToString();
        int green = int.Parse(greenstr, System.Globalization.NumberStyles.HexNumber);

        int newgreen = 0;
        if (up)
        {
            if (green+increment >= 255)
            {
                Debug.Log("Green at maximum");
                return;
            }
            else
            {
                newgreen = green + increment;
            }

        }
        else
        {

            if (green-increment <= 0)
            {
                Debug.Log("Green at zero");
                return;
            }
            else
            {
                newgreen = green - increment;
            }

        }

        Debug.Log(newgreen);
        string hexValue = "#00" + newgreen.ToString("X") + "00";
        GreenValue = CM.ConvertToColor(hexValue);
        CM.DrawLineBetweenTwoVectors(GreenLaserGO.transform.position, Mirror.transform.position, GreenValue, LineMaterial, GreenLaserGO, GreenLaser, false);
        ChangeOutput();
    }

    public void ChangeBlue(bool up)
    {
        string result = CM.ConvertToHex(BlueValue);
        string bluestr = result[5].ToString() + result[6].ToString();
        int blue = int.Parse(bluestr, System.Globalization.NumberStyles.HexNumber);

        int newblue = 0;
        if (up)
        {
            if (blue+increment >= 255)
            {
                Debug.Log("Blue at maximum");
                return;
            }
            else
            {
                newblue = blue + increment;
            }
        }
        else
        {
            if (blue-increment <= 0)
            {
                Debug.Log("Green at zero or will be below zero.");
                return;
            }
            else
            {
                newblue = blue - increment;
            }

        }

        Debug.Log(newblue);
        string hexValue = "#0000" + newblue.ToString("X");
        BlueValue = CM.ConvertToColor(hexValue);
        Debug.Log(BlueValue);
        CM.DrawLineBetweenTwoVectors(BlueLaserGO.transform.position, Mirror.transform.position, BlueValue, LineMaterial, BlueLaserGO, BlueLaser, true);
        ChangeOutput();
    }

    public void ChangeOutput()
    {
        string red = CM.ConvertToHex(RedValue);
        string green = CM.ConvertToHex(GreenValue);
        string blue = CM.ConvertToHex(BlueValue);

        string hexValue = "#" + red[1] + red[2] + green[3] + green[4] + blue[5] + blue[6];
        OutputVal = CM.ConvertToColor(hexValue);
        CM.DrawLineBetweenTwoVectors(Mirror.transform.position, OutputLaserGO.transform.position, OutputVal, LineMaterial, OutputLaserGO, OutputLaser, true);
    }

    public void PrintColor()
    {
        string result = CM.ConvertToHex(OutputVal);
        //Debug.Log("Color: " + result);
        string redstr = result[1].ToString() + result[2].ToString();
        string greenstr = result[3].ToString() + result[4].ToString();
        string bluestr = result[3].ToString() + result[4].ToString();

        int red = int.Parse(redstr, System.Globalization.NumberStyles.HexNumber);
        int green = int.Parse(greenstr, System.Globalization.NumberStyles.HexNumber); 
        int blue = int.Parse(bluestr, System.Globalization.NumberStyles.HexNumber);
        //Debug.Log("Red: " + red + " Green: " + green + " Blue: " + blue);

        string hexValue = red.ToString("X");
        //Debug.Log("NewRed: " + hexValue);

    }
}

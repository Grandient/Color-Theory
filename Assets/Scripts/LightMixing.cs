using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    // Matching GameObject
    public GameObject ColorMatcher;
    public GameObject Result;

    // Knobs
    public GameObject redKnob;
    public GameObject greenKnob;
    public GameObject blueKnob;

    // Laser GameObject
    public GameObject RedLaserGO;
    public GameObject GreenLaserGO;
    public GameObject BlueLaserGO;
    public GameObject OutputLaserGO;

    // Current Color
    public Color RedValue = Color.clear;
    public Color GreenValue = Color.clear;
    public Color BlueValue = Color.clear;
    public Color OutputVal;

    // Current Color String
    public string RedValueStr = "";
    public string GreenValueStr = "";
    public string BlueValueStr = "";
    public string OutputValueStr = "";

    // Boolean
    public bool Red = true;
    public bool Green = false;
    public bool Blue = false;

    // Selections
    KeyCode left = KeyCode.Alpha0;
    KeyCode right = KeyCode.Alpha1;
    KeyCode select = KeyCode.Return;
    KeyCode reset = KeyCode.R;
    
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
    Color TrueValue = Color.magenta;

    // Start is called before the first frame update
    void Start()
    {

        OutputVal = Color.white;

        // Add The Line Renderers
        RedLaser = RedLaserGO.AddComponent<LineRenderer>();
        GreenLaser = GreenLaserGO.AddComponent<LineRenderer>();
        BlueLaser = BlueLaserGO.AddComponent<LineRenderer>();
        OutputLaser = OutputLaserGO.AddComponent<LineRenderer>();

        // Set Colors
        CM.SetColorMaterialTransform(TrueValue, ColorMatcher.transform);
        CM.SetColorMaterialTransform(Color.red, redKnob.transform);
        CM.SetColorMaterialTransform(Color.green, greenKnob.transform);
        CM.SetColorMaterialTransform(Color.blue, blueKnob.transform);

        // Draw Lines
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
            SelectKnob();
        }

        //PrintColor();

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
            SelectKnob();
        }

        // Choose
        if (Input.GetKeyDown(select))
        {
            Match();
        }

        // Reset
        if (Input.GetKeyDown(reset))
        {
            Debug.Log("Reset");
            ResetColors();
        }

        //Red
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

        // Green
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

        // Blue
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

    public void RotateKnob(bool up)
    {
        float angle = 360;
        float color = 255;
        float rotationMultiplier = angle/color;
        Vector3 rotation = new Vector3(0f, rotationMultiplier * increment, 0f);
        if (up)
        {
            if (Red)
            {
                redKnob.transform.eulerAngles += rotation;
            }

            if (Green)
            {
                greenKnob.transform.eulerAngles += rotation;
            }

            if (Blue)
            {
                blueKnob.transform.eulerAngles += rotation;
            }

        } else
        {
            if (Red)
            {
                redKnob.transform.eulerAngles -= rotation;
            }

            if (Green)
            {
                greenKnob.transform.eulerAngles -= rotation;
            }

            if (Blue)
            {
                blueKnob.transform.eulerAngles -= rotation;
            }
        }
       
    }

    public void SelectKnob()
    {
        if (Red)
        {
            redKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
            greenKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            blueKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        }

        if (Green)
        {
            redKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            greenKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
            blueKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        }

        if (Blue)
        {
            redKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            greenKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            blueKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
        }
    }

    public void SetKnob()
    {
        Vector3 rotation = Vector3.zero;
        if (Red)
        {
            redKnob.transform.eulerAngles = rotation;
        }

        if (Green)
        {
            greenKnob.transform.eulerAngles = rotation;
        }

        if (Blue)
        {
            blueKnob.transform.eulerAngles = rotation;
        }
    }

    public void ResetColors()
    {
        RedValue = Color.clear;
        BlueValue = Color.clear;
        GreenValue = Color.clear;
        OutputVal = Color.clear;
        CM.DrawLineBetweenTwoVectors(RedLaserGO.transform.position, Mirror.transform.position, RedValue, LineMaterial, RedLaserGO, RedLaser, false);
        CM.DrawLineBetweenTwoVectors(BlueLaserGO.transform.position, Mirror.transform.position, BlueValue, LineMaterial, BlueLaserGO, BlueLaser, true);
        CM.DrawLineBetweenTwoVectors(GreenLaserGO.transform.position, Mirror.transform.position, GreenValue, LineMaterial, GreenLaserGO, GreenLaser, false);
        CM.DrawLineBetweenTwoVectors(Mirror.transform.position, OutputLaserGO.transform.position, OutputVal, LineMaterial, OutputLaserGO, OutputLaser, true);

    }

    public void GenerateTruth()
    {
        
    }

    public void Match()
    {
        string resultOutput = CM.ConvertToHex(OutputVal);
        // Red
        string redstr1 = resultOutput[1].ToString() + resultOutput[2].ToString();
        int red1 = int.Parse(redstr1, System.Globalization.NumberStyles.HexNumber);
        // Green
        string greenstr1 = resultOutput[3].ToString() + resultOutput[4].ToString();
        int green1 = int.Parse(greenstr1, System.Globalization.NumberStyles.HexNumber);
        // Blue
        string bluestr1 = resultOutput[5].ToString() + resultOutput[6].ToString();
        int blue1 = int.Parse(bluestr1, System.Globalization.NumberStyles.HexNumber);

        string result = CM.ConvertToHex(TrueValue);
        // Red
        string redstr2 = result[1].ToString() + result[2].ToString();
        int red2 = int.Parse(redstr2, System.Globalization.NumberStyles.HexNumber);
        // Green
        string greenstr2 = result[3].ToString() + result[4].ToString();
        int green2 = int.Parse(greenstr2, System.Globalization.NumberStyles.HexNumber);
        // Blue
        string bluestr2 = result[5].ToString() + result[6].ToString();
        int blue2 = int.Parse(bluestr2, System.Globalization.NumberStyles.HexNumber);

        int redResult = red1 - red2;
        int blueResult = blue1 - blue2;
        int greenResult = green1 - green2;

        int[] arr = new int[] { redResult, blueResult, greenResult };
        int max = arr.Max();

        
        if (max <= increment)
        {
            Debug.Log("Color Matched");
            CM.SetColorMaterialTransform(Color.green, Result.transform);
        } else
        {
            Debug.Log("Color Unmatched");
            CM.SetColorMaterialTransform(Color.red, Result.transform);
        }


    }

    public void ChangeRed(bool up)
    {
        string result = CM.ConvertToHex(RedValue);
        string redstr = result[1].ToString() + result[2].ToString();
        int red = int.Parse(redstr, System.Globalization.NumberStyles.HexNumber);

        //int alpha = increment / 3;

        int newred = 0;
        
        if (up)
        {
            if(red+increment >= 255)
            {
                Debug.Log("Red at maximum");
                SetKnob();
                return;
            } else
            {
                newred = red + increment;
                RotateKnob(up);
            }
            
        } else {

            if(red-increment <= 0)
            {
                Debug.Log("Red at zero");
                RedValue = Color.clear;
                CM.DrawLineBetweenTwoVectors(RedLaserGO.transform.position, Mirror.transform.position, RedValue, LineMaterial, RedLaserGO, RedLaser, false);
                ChangeOutput();
                SetKnob();
                return;
            } else
            {
                newred = red - increment;
                RotateKnob(up);
            }
            
        }

        Debug.Log(newred);
        string hexValue = "#" + newred.ToString("X") + "0000";
        if(hexValue.Length == 6)
        {
            hexValue = hexValue.Insert(1, "0");
        }
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
                SetKnob();
                return;
            }
            else
            {
                newgreen = green + increment;
                RotateKnob(up);
            }

        }
        else
        {

            if (green-increment <= 0)
            {
                Debug.Log("Green at zero");
                GreenValue = Color.clear;
                CM.DrawLineBetweenTwoVectors(GreenLaserGO.transform.position, Mirror.transform.position, GreenValue, LineMaterial, GreenLaserGO, GreenLaser, false);
                ChangeOutput();
                SetKnob();
                return;
            }
            else
            {
                newgreen = green - increment;
                RotateKnob(up);
            }

        }

        Debug.Log(newgreen);
        string hexValue = "#00" + newgreen.ToString("X") + "00";
        if (hexValue.Length == 6)
        {
            hexValue = hexValue.Insert(3, "0");
        }
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
                SetKnob();
                return;
            }
            else
            {
                newblue = blue + increment;
                RotateKnob(up);
            }
        }
        else
        {
            if (blue-increment <= 0)
            {
                Debug.Log("Blue at zero or will be below zero.");
                BlueValue = Color.clear;
                CM.DrawLineBetweenTwoVectors(BlueLaserGO.transform.position, Mirror.transform.position, BlueValue, LineMaterial, BlueLaserGO, BlueLaser, true);
                ChangeOutput();
                SetKnob();
                return;
            }
            else
            {
                newblue = blue - increment;
                RotateKnob(up);
            }

        }

        Debug.Log(newblue);
        string hexValue = "#0000" + newblue.ToString("X");
        if (hexValue.Length == 6)
        {
            hexValue = hexValue.Insert(5, "0");
        }
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
        if (RedValue == Color.clear && GreenValue == Color.clear && BlueValue == Color.clear)
        {
            OutputVal = Color.clear;
        }
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

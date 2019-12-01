using System.Linq;
using UnityEngine;
public class PigmentMixing : MonoBehaviour
{

    // Matching GameObject
    public GameObject ColorMatcher;
    public GameObject Result;

    // Particle System
    public ParticleSystem mixture;

    // Knobs
    public GameObject cyanKnob;
    public GameObject magentaKnob;
    public GameObject yellowKnob;

    // Current Color
    public Color CyanValue = Color.white;
    public Color MagnetaValue = Color.white;
    public Color YellowValue = Color.white;
    public Color OutputVal;

    // Boolean
    public bool Cyan = true;
    public bool Magneta = false;
    public bool Yellow = false;

    // Selections
    KeyCode left = KeyCode.Alpha0;
    KeyCode right = KeyCode.Alpha1;
    KeyCode select = KeyCode.Return;
    KeyCode reset = KeyCode.R;

    // Power
    KeyCode up = KeyCode.Alpha2;
    KeyCode down = KeyCode.Alpha3;

    // Index
    // 0 = Cyan
    // 1 = Magneta
    // 2 = Yellow
    public int index = 0;

    // Variable
    public int increment = 25;
    float color = 255;
    float angle = 360;
    public float mixtureMax = 0;
    float heightMax = 2.3f;
    float heightMin = 0.166f;
    Color TrueValue = Color.magenta;

    // Start is called before the first frame update
    void Start()
    {
        OutputVal = Color.white;
        CyanValue = Color.white;
        MagnetaValue = Color.white;
        YellowValue = Color.white;


        // Maximum Mixture
        float mixtureMultplier = angle / color;
        float piece = 0;
        while (piece <= color)
        {
            piece += increment;
            mixtureMax++;
        }


        // Set Colors
        CM.SetColorMaterialTransform(TrueValue, ColorMatcher.transform);
        CM.SetColorMaterialTransform(Color.cyan, cyanKnob.transform);
        CM.SetColorMaterialTransform(Color.magenta, magentaKnob.transform);
        CM.SetColorMaterialTransform(Color.yellow, yellowKnob.transform);
    }

    // Update is called once per frame
    void Update()
    {
        // Switch left
        if (Input.GetKeyDown(left))
        {
            Debug.Log("Left");
            Cyan = false;
            Magneta = false;
            Yellow = false;
            switch (index)
            {
                case 0:
                    Debug.Log("Cannot turn left");
                    Cyan = true;
                    break;
                case 1:
                    Cyan = true;
                    index--;
                    break;
                case 2:
                    Magneta = true;
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
            Cyan = false;
            Magneta = false;
            Yellow = false;
            switch (index)
            {
                case 0:
                    Magneta = true;
                    index++;
                    break;
                case 1:
                    Yellow = true;
                    index++;
                    break;
                case 2:
                    Debug.Log("Cannot turn right");
                    Yellow = true;
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
        if (Cyan)
        {
            if (Input.GetKeyDown(up))
            {
                Debug.Log("Up");
                ChangeCyan(true);
            }

            /*
            if (Input.GetKeyDown(down))
            {
                Debug.Log("Down");
                ChangeCyan(false);
            }*/

        }

        // Green
        if (Magneta)
        {
            if (Input.GetKeyDown(up))
            {
                Debug.Log("Up");
                ChangeMagenta(true);
            }
            /*
            if (Input.GetKeyDown(down))
            {
                Debug.Log("Down");
                ChangeMagenta(false);
            }*/
        }

        // Blue
        if (Yellow)
        {
            if (Input.GetKeyDown(up))
            {
                Debug.Log("Up");
                ChangeYellow(true);
            }

            /*
            if (Input.GetKeyDown(down))
            {
                Debug.Log("Down");
                ChangeYellow(false);
            }*/
        }
    }

    public void RotateKnob(bool up)
    {
        angle = 360;
        color = 255;
        float rotationMultiplier = angle / color;
        Vector3 rotation = new Vector3(0f, rotationMultiplier * increment, 0f);
        if (up)
        {
            if (Cyan)
            {
                cyanKnob.transform.eulerAngles += rotation;
            }

            if (Magneta)
            {
                magentaKnob.transform.eulerAngles += rotation;
            }

            if (Yellow)
            {
                yellowKnob.transform.eulerAngles += rotation;
            }

        }
        else
        {
            if (Cyan)
            {
                cyanKnob.transform.eulerAngles -= rotation;
            }

            if (Magneta)
            {
                magentaKnob.transform.eulerAngles -= rotation;
            }

            if (Yellow)
            {
                yellowKnob.transform.eulerAngles -= rotation;
            }
        }

    }

    public void SelectKnob()
    {
        if (Cyan)
        {
            cyanKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
            magentaKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            yellowKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        }

        if (Magneta)
        {
            cyanKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            magentaKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
            yellowKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        }

        if (Yellow)
        {
            cyanKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            magentaKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            yellowKnob.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
        }
    }

    public void SetKnob()
    {
        Vector3 rotation = Vector3.zero;
        if (Cyan)
        {
            cyanKnob.transform.eulerAngles = rotation;
        }

        if (Magneta)
        {
            magentaKnob.transform.eulerAngles = rotation;
        }

        if (Yellow)
        {
            yellowKnob.transform.eulerAngles = rotation;
        }
    }

    public void ResetColors()
    {
        CyanValue = Color.clear;
        YellowValue = Color.clear;
        MagnetaValue = Color.clear;
        OutputVal = Color.clear;
    }


    public void Match()
    {
        // Output
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

        // True
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

        // Result
        int redResult = red1 - red2;
        int blueResult = blue1 - blue2;
        int greenResult = green1 - green2;

        // Array
        int[] arr = new int[] { redResult, blueResult, greenResult };
        int max = arr.Max();


        if (max <= increment)
        {
            Debug.Log("Color Matched");
            CM.SetColorMaterialTransform(Color.green, Result.transform);
        }
        else
        {
            Debug.Log("Color Unmatched");
            CM.SetColorMaterialTransform(Color.red, Result.transform);
        }


    }

    public void ChangeCyan(bool up)
    {
        string result = CM.ConvertToHex(CyanValue);
        string redstr = result[1].ToString() + result[2].ToString();
        int red = int.Parse(redstr, System.Globalization.NumberStyles.HexNumber);
        int newred = 0;

        if (up)
        {
            // Max
            if (red - increment <= 0)
            {
                Debug.Log("Cyan at maximum");
                CyanValue = Color.black;
                ChangeOutput(up);
                SetKnob();
                return;
            }
            else
            {
                // Approach 0 
                newred = red - increment;
                RotateKnob(up);
            }
        }
        else
        {
            //Minimum
            if (red + increment >= 255)
            {
                Debug.Log("Cyan at minimum.");
                CyanValue = Color.white;
                ChangeOutput(up);
                SetKnob();
                return;
            }
            else
            {
                // Approach 255
                newred = red + increment;
                RotateKnob(up);
            }
        }

        Debug.Log(newred);
        string hexValue = "#" + newred.ToString("X") + "0000";
        if (hexValue.Length == 6)
        {
            hexValue = hexValue.Insert(1, "0");
        }
        CyanValue = CM.ConvertToColor(hexValue);
        ChangeOutput(up);
    }

    public void ChangeMagenta(bool up)
    {
        string result = CM.ConvertToHex(MagnetaValue);
        string greenstr = result[3].ToString() + result[4].ToString();
        int green = int.Parse(greenstr, System.Globalization.NumberStyles.HexNumber);
        int newgreen = 0;

        if (up)
        {
            if (green - increment <= 0)
            {
                Debug.Log("Magenta at maximum");
                MagnetaValue = Color.black;
                ChangeOutput(up);
                SetKnob();
                return;
            }
            else
            {
                newgreen = green - increment;
                RotateKnob(up);
            }
        }
        else
        {
            if (green + increment >= 255)
            {
                Debug.Log("Magenta at minimum");
                MagnetaValue = Color.white;
                ChangeOutput(up);
                SetKnob();
                return;
            }
            else
            {
                newgreen = green + increment;
                RotateKnob(up);
            }

        }

        Debug.Log(newgreen);
        string hexValue = "#00" + newgreen.ToString("X") + "00";
        if (hexValue.Length == 6)
        {
            hexValue = hexValue.Insert(3, "0");
        }
        MagnetaValue = CM.ConvertToColor(hexValue);
        ChangeOutput(up);
    }

    public void ChangeYellow(bool up)
    {
        string result = CM.ConvertToHex(YellowValue);
        string bluestr = result[5].ToString() + result[6].ToString();
        int blue = int.Parse(bluestr, System.Globalization.NumberStyles.HexNumber);

        int newblue = 0;
        if (up)
        {
            if (blue - increment <= 0)
            {
                Debug.Log("Yellow at maximum.");
                YellowValue = Color.black;
                ChangeOutput(up);
                SetKnob();
                return;
            }
            else
            {
                newblue = blue - increment;
                RotateKnob(up);
            }
        }
        else
        {
            if (blue + increment >= 255)
            {
                Debug.Log("Yellow at minimum");
                YellowValue = Color.white;
                ChangeOutput(up);
                SetKnob();
                return;
            }
            else
            {
                newblue = blue + increment;
                RotateKnob(up);
            }

        }

        string hexValue = "#0000" + newblue.ToString("X");
        if (hexValue.Length == 6)
        {
            hexValue = hexValue.Insert(5, "0");
        }
        YellowValue = CM.ConvertToColor(hexValue);
        ChangeOutput(up);
    }

    public void ChangeOutput(bool up)
    {
        // CMY
        string cyan = CM.ConvertToHex(CyanValue);
        string magenta = CM.ConvertToHex(MagnetaValue);
        string yellow = CM.ConvertToHex(YellowValue);
        string hexValue = "#" + cyan[1] + cyan[2] + magenta[3] + magenta[4] + yellow[5] + yellow[6];

        // Change color
        OutputVal = CM.ConvertToColor(hexValue);
        if (CyanValue == Color.black && MagnetaValue == Color.black && YellowValue == Color.black)
        {
            OutputVal = Color.black;
        }

        // Color
        ParticleSystem.MainModule psMain = mixture.main;
        psMain.startColor = OutputVal;

        // Length
        float length = heightMax * (1 / mixtureMax);
        ParticleSystem.ShapeModule psShape = mixture.shape;
        if (up)
        {
            if (psShape.length + length < heightMax)
            {
                psShape.length += length;
            }
        }
        else
        {
            if (psShape.length - length > heightMin)
            {
                psShape.length -= length;
            }
        }


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
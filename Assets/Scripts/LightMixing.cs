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
    public Color OutputValue = Color.red;

    // Current Color String
    public string RedValueStr = "";
    public string GreenValueStr = "";
    public string BlueValueStr = "";
    public string OutputValueStr = "";

    // Boolean
    bool Red = false;
    bool Green = false;
    bool Blue = false;

    // Selections
    KeyCode left = KeyCode.Alpha0;
    KeyCode right = KeyCode.Alpha1;
    
    // Power
    KeyCode up = KeyCode.Alpha0;
    KeyCode down = KeyCode.Alpha0;


    // Variable
    public int increment = 25;

    // Start is called before the first frame update
    void Start()
    {
        RedLaser = RedLaserGO.AddComponent<LineRenderer>();
        GreenLaser = GreenLaserGO.AddComponent<LineRenderer>();
        BlueLaser = BlueLaserGO.AddComponent<LineRenderer>();
        OutputLaser = OutputLaserGO.AddComponent<LineRenderer>();

        CM.DrawLineBetweenTwoVectors(RedLaserGO.transform.position, Mirror.transform.position, RedValue, LineMaterial, RedLaserGO, RedLaser, false);
        CM.DrawLineBetweenTwoVectors(BlueLaserGO.transform.position, Mirror.transform.position, BlueValue, LineMaterial, BlueLaserGO, BlueLaser, true);
        CM.DrawLineBetweenTwoVectors(GreenLaserGO.transform.position, Mirror.transform.position, GreenValue, LineMaterial, GreenLaserGO, GreenLaser, false);
        CM.DrawLineBetweenTwoVectors(Mirror.transform.position, OutputLaserGO.transform.position, OutputValue, LineMaterial, OutputLaserGO, OutputLaser, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(left))
        {
            
        }
        if (Input.GetKeyDown(right))
        {
            
        }

        if (Red)
        {
            ChangeRed();
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

    public void ChangeRed()
    {

    }

    public void ChangeGreen()
    {

    }

    public void ChangeBlue()
    {

    }
}

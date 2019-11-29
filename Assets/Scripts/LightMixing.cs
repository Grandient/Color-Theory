using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMixing : MonoBehaviour
{
    public Material LineMaterial;
    // Lasers
    LineRenderer RedLaser;
    LineRenderer GreenLaser;
    LineRenderer BlueLaser;

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
    public Color OutputValue = new Color();

    // Current Color String
    public string RedValueStr = "";
    public string GreenValueStr = "";
    public string BlueValueStr = "";
    public string OutputValueStr = "";

    // Boolean
    bool Red = false;
    bool Green = false;
    bool Blue = false;

    // Variable
    public int increment = 25;

    // Start is called before the first frame update
    void Start()
    {
        RedLaser = RedLaserGO.AddComponent<LineRenderer>();
        GreenLaser = GreenLaserGO.AddComponent<LineRenderer>();
        BlueLaser = BlueLaserGO.AddComponent<LineRenderer>();

        CM.DrawLineBetweenTwoVectors(RedLaserGO.transform.position, Mirror.transform.position, RedValue, LineMaterial, RedLaserGO, RedLaser);
        CM.DrawLineBetweenTwoVectors(BlueLaserGO.transform.position, Mirror.transform.position, BlueValue, LineMaterial, BlueLaserGO, BlueLaser);
        CM.DrawLineBetweenTwoVectors(GreenLaserGO.transform.position, Mirror.transform.position, GreenValue, LineMaterial, GreenLaserGO, GreenLaser);
    }

    // Update is called once per frame
    void Update()
    {
        if (Red)
        {

        }

        if (Green)
        {

        }

        if (Blue)
        {

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

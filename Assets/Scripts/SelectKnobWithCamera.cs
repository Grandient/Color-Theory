using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectKnobWithCamera : MonoBehaviour
{
    Camera cam;
    public GameObject lightMixGO;
    public LightMixing lightMixGame;
    public GameObject pigmentMixGO;
    public PigmentMixing pigmentMixGame;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        lightMixGame = lightMixGO.GetComponent<LightMixing>();
        pigmentMixGame = pigmentMixGO.GetComponent<PigmentMixing>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.transform.name == "Red-Cyl")
        {
            lightMixGame.Green = false;
            lightMixGame.Blue = false;
            lightMixGame.Red = true;
            if (Input.GetMouseButtonDown(0))
            {
                lightMixGame.ChangeRed(false);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                lightMixGame.ChangeRed(true);
            }
        }
        else if (Physics.Raycast(ray, out hit) && hit.transform.name == "Green-Cyl")
        {
            lightMixGame.Red = false;
            lightMixGame.Blue = false;
            lightMixGame.Green = true;
            if (Input.GetMouseButtonDown(0))
            {
                lightMixGame.ChangeGreen(false);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                lightMixGame.ChangeGreen(true);
            }
        }
        else if (Physics.Raycast(ray, out hit) && hit.transform.name == "Blue-Cyl")
        {
            lightMixGame.Red = false;
            lightMixGame.Green = false;
            lightMixGame.Blue = true;
            if (Input.GetMouseButtonDown(0))
            {
                lightMixGame.ChangeBlue(false);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                lightMixGame.ChangeBlue(true);
            }
        }

        if (Physics.Raycast(ray, out hit) && hit.transform.name == "Cyan-Cyl")
        {
            pigmentMixGame.Magneta = false;
            pigmentMixGame.Yellow = false;
            pigmentMixGame.Cyan = true;
            /*
            if (Input.GetMouseButtonDown(0))
            {
                pigmentMixGame.ChangeCyan(false);
            }*/
            if (Input.GetMouseButtonDown(1))
            {
                pigmentMixGame.ChangeCyan(true);
            }
        }
        else if (Physics.Raycast(ray, out hit) && hit.transform.name == "Magenta-Cyl")
        {
            pigmentMixGame.Cyan = false;
            pigmentMixGame.Yellow = false;
            pigmentMixGame.Magneta = true;
            /*
            if (Input.GetMouseButtonDown(0))
            {
                pigmentMixGame.ChangeMagenta(false);
            }*/
            if (Input.GetMouseButtonDown(1))
            {
                pigmentMixGame.ChangeMagenta(true);
            }
        }
        else if (Physics.Raycast(ray, out hit) && hit.transform.name == "Yellow-Cyl")
        {
            pigmentMixGame.Cyan = false;
            pigmentMixGame.Magneta = false;
            pigmentMixGame.Yellow = true;
            /*
            if (Input.GetMouseButtonDown(0))
            {
                pigmentMixGame.ChangeYellow(false);
            }*/
            if (Input.GetMouseButtonDown(1))
            {
                pigmentMixGame.ChangeYellow(true);
            }
        }
    }
}

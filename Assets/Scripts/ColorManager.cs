using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages the colors with the scene and has interfaces allow for functions to change colors of objects

public class CM
{
    public static void SetColorMaterialTransform(string colorString, Transform target)
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(colorString, out color))
        {
            target.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
        }
    }


    public static void SetColorMaterialTransform(Color color, Transform target)
    {
        target.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
    }

    public static Color GetColorMaterialTransform(Transform target)
    {
        return target.GetComponent<MeshRenderer>().material.color;
    }

    public static string ConverToHex(Color color)
    {
        return "#" + ColorUtility.ToHtmlStringRGB(color);
    }

    public static Color ConvertToColor(string colorString)
    {
        Color color;
        if (!colorString.Contains("#"))
        {
            colorString.Insert(0, "#");
        }
        if (ColorUtility.TryParseHtmlString(colorString, out color))
        {
            return color;
        }
        return color;
    }

    public void GetMaterialsFromObject(Transform Handpan, List<Material> Materials)
    {
        foreach (Transform trans in Handpan)
        {
            Materials.Add(trans.GetChild(0).GetComponent<MeshRenderer>().material);
            Materials.Add(trans.GetChild(1).GetComponent<MeshRenderer>().material);
        }
    }

    public static void DrawLineBetweenTwoVectors(Vector3 v1, Vector3 v2, Color color, Material lineMat, GameObject go, LineRenderer lineRenderer)
    {
        go.transform.position = v2;
        lineRenderer.material = lineMat;
        lineRenderer.SetPosition(0, v1);
        lineRenderer.SetPosition(1, v2);
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
    }

}

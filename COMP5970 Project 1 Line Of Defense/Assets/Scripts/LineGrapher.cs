using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LineGrapher : MonoBehaviour
{
    private Transform graphTransform;
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeColl;

    public GameObject xTwoInputField;
    public GameObject xOneInputField;
    public GameObject xZeroInputField;

    public float xTwo;
    public float xOne;
    public float xZero;

    public void UpdateEquation()
    {
        xTwo = float.Parse(xTwoInputField.GetComponent<TMP_InputField>().text);    
        xOne = float.Parse(xOneInputField.GetComponent<TMP_InputField>().text);
        xZero = float.Parse(xZeroInputField.GetComponent<TMP_InputField>().text);
        DrawLine();
    }

    private void DrawLine()
    {
        lineRenderer.useWorldSpace = false;   
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.positionCount = 20;

        var points = new Vector3[20];
        for (int i = -10; i < 10; i++)
        {
            float y = ((((float)i)/2.5f * (((float)i) / 2.5f) * (xTwo)) + (((float)i)/2.5f * xOne) + xZero);
            points[i+10] = new Vector3(((float)i)/2.5f, y, -10f);
            Debug.Log(points[i+10]);
            
        }
        lineRenderer.SetPositions(points);
        Vector2[] v2 = MyVector3Extension.ToVector2Array(points);
        edgeColl.points = v2;
    }
}

public static class MyVector3Extension
{

    public static Vector2[] ToVector2Array(this Vector3[] v3)
    {
        return System.Array.ConvertAll<Vector3, Vector2>(v3, getV3fromV2);
    }

    public static Vector2 getV3fromV2(Vector3 v3)
    {
        return new Vector2(v3.x, v3.y);
    }

}
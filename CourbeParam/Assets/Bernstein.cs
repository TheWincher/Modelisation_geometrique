using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bernstein : MonoBehaviour
{
    public List<Vector3> controlPoints;
    LineRenderer lineRendererControl, lineRenderer;
    public int nbPoints;
    int numPoint;
    // Start is called before the first frame update
    void Start()
    {
        GameObject lineControl = new GameObject("PolyControlPoint");
        lineRendererControl = lineControl.AddComponent<LineRenderer>();
        lineRendererControl.positionCount = controlPoints.Count;
        lineRendererControl.SetPositions(controlPoints.ToArray());
        lineRendererControl.startColor = lineRendererControl.endColor = Color.red;
        lineRendererControl.startWidth = lineRendererControl.endWidth = 0.087f;
        lineRenderer = GetComponent<LineRenderer>();
        lineRendererControl.material = lineRenderer.material;
        List<Vector3> points = BezierCurveByBernstein();
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }

    List<Vector3> BezierCurveByBernstein()
    {
        List<Vector3> res = new List<Vector3>();
        for(int i = 0; i <= nbPoints; i++)
        {
            float u = (float)i / (float)nbPoints;
            Vector3 point = Vector3.zero;

            for(int j = 0; j < controlPoints.Count; j++)
            {
                float degre = controlPoints.Count - 1;
                float polyBernstein = (factorial(degre) / (factorial(j) * factorial(degre - j))) * Mathf.Pow(u, j) * Mathf.Pow(1 - u, degre - j);

                point += polyBernstein * controlPoints[j];
            }
            res.Add(point);  
        }
        return res;
    }

    float factorial(float n)
    {
        float facto = 1.0f;
        for (int i = 1; i <= n; i++)
        {
            facto *= i;
        }
        return facto;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha0))
            numPoint = 0;
        else if (Input.GetKey(KeyCode.Alpha1))
            numPoint = 1;
        else if(Input.GetKey(KeyCode.Alpha2))
            numPoint = 2;
        else if(Input.GetKey(KeyCode.Alpha3))
            numPoint = 3;

        Debug.Log(numPoint);

        Vector3 v = Vector3.zero;
        if (Input.GetKey(KeyCode.Z))
            v += Vector3.up;
        if (Input.GetKey(KeyCode.S))
            v += Vector3.down;
        if (Input.GetKey(KeyCode.Q))
            v += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            v += Vector3.right;

        switch (numPoint)
        {
            case 0 :
                controlPoints[0] += v;
                break;
            case 1:
                controlPoints[1] += v;
                break;
            case 2:
                controlPoints[2] += v;
                break;
            case 3:
                controlPoints[3] += v;
                break;
            default :
                break;
        }

        lineRendererControl.SetPositions(controlPoints.ToArray());
        List<Vector3> points = BezierCurveByBernstein();
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }
}

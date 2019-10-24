using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class courbeHermite : MonoBehaviour
{
    public int nbPoint;
    public Vector3 P0, P1, V0, V1;

    // Start is called before the first frame update
    void Start()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        List<Vector3> points = new List<Vector3>();
        
        for(int i = 0; i <= nbPoint; i++)
        {
            float u = (float)i / (float)nbPoint;
            points.Add(CalculCourbeHermite(P0, P1, V0, V1, u));
        }

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }

    Vector3 CalculCourbeHermite(Vector3 P0, Vector3 P1, Vector3 V0, Vector3 V1, float u)
    {
        float u2 = u * u;
        float u3 = u2 * u;

        float f1 = 2 * u3 - 3 * u2 + 1;
        float f2 = -2 * u3 + 3 * u2;
        float f3 = u3 - 2 * u2 + u;
        float f4 = u3 - u2;

        return f1 * P0 + f2 * P1 + f3 * V0 + f4 * V1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

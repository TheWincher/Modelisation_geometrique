using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lChaikin : MonoBehaviour
{
    public GameObject line;
    public int nbIteration = 1;
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < nbIteration; j++)
        {
            GameObject newLine = new GameObject();
            LineRenderer lineRender = newLine.AddComponent<LineRenderer>();
            lineRender.positionCount = 0;
            lineRender.sortingOrder = line.GetComponent<LineRenderer>().sortingOrder + 1;
            lineRender.endWidth = lineRender.startWidth = 0.087f;
            lineRender.startColor = lineRender.endColor = new Color(Random.value, Random.value, Random.value);
            lineRender.material = mat;
            for (int i = 0; i < line.GetComponent<LineRenderer>().positionCount - 1; i++)
            {
                lineRender.positionCount += 2;
                lineRender.SetPosition(2 * i, 0.75f * line.GetComponent<LineRenderer>().GetPosition(i) + 0.25f * line.GetComponent<LineRenderer>().GetPosition(i + 1));
                lineRender.SetPosition(2 * i + 1, 0.25f * line.GetComponent<LineRenderer>().GetPosition(i) + 0.75f * line.GetComponent<LineRenderer>().GetPosition(i + 1));
            }
            line = newLine;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

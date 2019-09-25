using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercice0 : MonoBehaviour
{

    public Material mat;
    public int nbCol, nbRow;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Vector3[] vertices = new Vector3[(nbCol+1) * (nbRow+1)];
        int[] triangles = new int[2 * 3 * nbCol * nbRow];

        for (int i = 0; i <= nbRow; i++)
        {
            for (int j = 0; j <= nbCol; j++)
            {
                vertices[i * (nbCol + 1) + j] = new Vector3(j, i, 0);
                Debug.Log((i * (nbCol + 1) + j) + " = " + vertices[i * (nbCol + 1) + j]);
            }
        }

        for (int i = 0; i < nbRow; i++)
        {
            for (int j = 0; j < nbCol; j++)
            {
                triangles[(i * 2 * nbCol + j * 2) * 3] = i * (nbCol + 1) + j;
                triangles[(i * 2 * nbCol + j * 2) * 3 + 1] = i * (nbCol + 1) + j + 1;
                triangles[(i * 2 * nbCol + j * 2) * 3 + 2] = (i + 1) * (nbCol + 1) + j + 1;

                triangles[(i * 2 * nbCol + j * 2 + 1) * 3] = (i + 1) * (nbCol + 1) + j + 1;
                triangles[(i * 2 * nbCol + j * 2 + 1) * 3 + 1] = (i + 1) * (nbCol + 1) + j;
                triangles[(i * 2 * nbCol + j * 2 + 1) * 3 + 2] = i * (nbCol + 1) + j;
            }
        }

        Mesh msh = new Mesh();

        msh.vertices = vertices;
        msh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = msh;
        gameObject.GetComponent<MeshRenderer>().material = mat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

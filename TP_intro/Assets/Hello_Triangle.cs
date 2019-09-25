using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello_Triangle : MonoBehaviour
{

    public Material mat;
    public int nbCol, nbRow;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Vector3[] vertices = new Vector3[2*3*nbCol*nbRow];
        int[] triangles = new int[2 * 3 * nbCol * nbRow];

        for(int i = 0; i < nbRow; i++)
        {
            for(int j = 0; j < nbCol; j++)
            {

                /*Vector3 A = new Vector3(j, i, 0);
                Vector3 B = new Vector3(j, i + 1, 0);
                Vector3 C = new Vector3(j + 1, i + 1, 0);
                Vector3 D = new Vector3(j + 1, i, 0);*/

                vertices[i * nbCol * 3 + j * 6] = new Vector3(j, i, 0);
                vertices[i * nbCol * 3 + j * 6 + 1] = new Vector3(j, i + 1, 0);
                vertices[i * nbCol * 3 + j * 6 + 2] = new Vector3(j + 1, i, 0);

                Debug.Log("i = " + (i * nbCol * 3 + j * 6) + " : " + vertices[i * nbCol * 3 + j * 6]);
                Debug.Log("i = " + (i * nbCol * 3 + j * 6 + 1) + " : " + vertices[i * nbCol * 3 + j * 6 + 1]);
                Debug.Log("i = " + (i * nbCol * 3 + j * 6 + 2) + " : " + vertices[i * nbCol * 3 + j * 6 + 2]);

                vertices[i * nbCol * 3 + j * 6 + 3] = new Vector3(j + 1, i + 1, 0);
                vertices[i * nbCol * 3 + j * 6 + 4] = new Vector3(j + 1, i, 0);
                vertices[i * nbCol * 3 + j * 6 + 5] = new Vector3(j, i + 1, 0);

                Debug.Log("i = " + (i * nbCol * 3 + j * 6 + 3) + " : " + vertices[i * nbCol * 3 + j * 6 + 3]);
                Debug.Log("i = " + (i * nbCol * 3 + j * 6 + 4) + " : " + vertices[i * nbCol * 3 + j * 6 + 4]);
                Debug.Log("i = " + (i * nbCol * 3 + j * 6 + 5) + " : " + vertices[i * nbCol * 3 + j * 6 + 5]);


                triangles[i * nbCol + j*6] = i * nbCol + j;
                triangles[i * nbCol + j*6 + 1] = i * nbCol + j + 1;
                triangles[i * nbCol + j*6 + 2] = i * nbCol + j + 2;

                triangles[i * nbCol + j*6 + 3] = i * nbCol + j + 3;
                triangles[i * nbCol + j*6 + 4] = i * nbCol + j + 2;
                triangles[i * nbCol + j*6 + 5] = i * nbCol + j + 1;
            }
        }

        for(int i = 0; i < 2 * 3 * nbCol * nbRow; i++)
        {
            Debug.Log("i = " + i + " : " + vertices[i]);
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

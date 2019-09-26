using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public Material mat;
    public int nbMeridiens, nbParalles, rayon;
    Vector3[] vertices;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        vertices = new Vector3[nbMeridiens * nbParalles];
        int[] triangles = new int[6 * nbMeridiens * nbParalles];

        for (int i = 0; i < nbMeridiens; i++)
        {
            float phi = Mathf.PI * ((float)i / (float)nbMeridiens);

            for (int j = 0; j < nbParalles; j++)
            {
                float teta = 2 * Mathf.PI * ((float)j / (float)nbParalles);

                float x = rayon * Mathf.Sin(phi) * Mathf.Cos(teta);
                float y = rayon * Mathf.Sin(phi) * Mathf.Sin(teta);
                float z = rayon * Mathf.Cos(phi);

                vertices[i * nbMeridiens + j] = new Vector3(x, y, z);
            }
        }

        int indTriangle = 0;
        for (int i = 0; i < nbParalles; i++)
        {
            for (int j = 0; j < nbMeridiens; j++)
            {
                Debug.Log("Triangle : " + (indTriangle * 2) + " = (" + (i * nbMeridiens + j) + "," + (i * nbMeridiens + (j + 1) % nbMeridiens) + "," + (((i + 1) % nbParalles) * nbMeridiens + j) + ")");
                triangles[indTriangle * 6] = i * nbMeridiens + j;
                triangles[indTriangle * 6 + 1] = i * nbMeridiens + (j + 1) % nbMeridiens;
                triangles[indTriangle * 6 + 2] = ((i + 1) % nbParalles) * nbMeridiens + j;

                Debug.Log("Triangle : " + ((indTriangle * 2) + 1) + " = (" + (((i + 1) % nbParalles) * nbMeridiens + j) + "," + (((i + 1) % nbParalles) * nbMeridiens + (j + 1) % nbMeridiens) + "," + (i * nbMeridiens + (j + 1) % nbMeridiens) + ")");
                triangles[indTriangle * 6  + 3] = ((i + 1) % nbParalles) * nbMeridiens + j;
                triangles[indTriangle * 6 + 4] = ((i + 1) % nbParalles) * nbMeridiens + (j + 1) % nbMeridiens; 
                triangles[indTriangle * 6 + 5] = i * nbMeridiens + (j + 1) % nbMeridiens; 

                indTriangle ++;
            }
        }

        /*for (int i = 0; i < nbMeridiens * (nbParalles); i++)
        {
            Debug.Log("Triangle : " + i*2 + " = (" + i + "," + ((i + 1) % (nbMeridiens * nbParalles))  + ","  + (i + nbMeridiens) + ")");
            triangles[i * 6] = i % (nbMeridiens * nbParalles);
            triangles[i * 6 + 1] = (i + 1) % (nbMeridiens * nbParalles);
            triangles[i * 6 + 2] = i  + nbMeridiens;

            Debug.Log("Triangle : " + (i*2+1) + " = (" + (i + nbMeridiens) + "," + ((i + 1) % (nbMeridiens * nbParalles) + nbMeridiens) + "," + ((i + 1) % (nbMeridiens * nbParalles)) + ")");
            triangles[i * 6 + 3] = (i + nbMeridiens) % (nbMeridiens * nbParalles);
            triangles[i * 6 + 4] = (i + 1 + nbMeridiens) % (nbMeridiens * nbParalles);
            triangles[i * 6 + 5] = (i + 1) % (nbMeridiens * nbParalles);
        }*/

        Mesh msh = new Mesh();

        msh.vertices = vertices;
        msh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = msh;
        gameObject.GetComponent<MeshRenderer>().material = mat;

    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }

}

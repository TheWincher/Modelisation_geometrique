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

        vertices = new Vector3[nbMeridiens * nbParalles + 2];
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

        vertices[nbMeridiens * nbParalles] = new Vector3(0, 0, rayon);
        vertices[nbMeridiens * nbParalles + 1] = new Vector3(0, 0, -rayon);

        int indTriangle = 0;
        for (int i = 1; i < nbParalles - 1; i++)
        {
            for (int j = 0; j < nbMeridiens; j++)
            {
                triangles[indTriangle] = i * nbMeridiens + j;
                triangles[indTriangle + 1] = ((i + 1) % nbParalles) * nbMeridiens + j;
                triangles[indTriangle + 2] = i * nbMeridiens + (j + 1) % nbMeridiens;
 
                triangles[indTriangle + 3] = ((i + 1) % nbParalles) * nbMeridiens + j;
                triangles[indTriangle + 4] = ((i + 1) % nbParalles) * nbMeridiens + (j + 1) % nbMeridiens; 
                triangles[indTriangle + 5] = i * nbMeridiens + (j + 1) % nbMeridiens; 

                indTriangle +=6;
            }
        }

        for(int i = 0; i < nbMeridiens; i++)
        {
            triangles[indTriangle] = i + nbMeridiens;
            triangles[indTriangle + 1] = (i + 1) % nbMeridiens + nbMeridiens;
            triangles[indTriangle + 2] = nbMeridiens * nbParalles;

            triangles[indTriangle + 3 * nbMeridiens] = i + nbMeridiens * (nbParalles - 1);
            triangles[indTriangle + 3 * nbMeridiens + 1] = nbMeridiens * nbParalles + 1;
            triangles[indTriangle + 3 * nbMeridiens  + 2] = (i + 1) % nbMeridiens + nbMeridiens * (nbParalles - 1);

            indTriangle += 3;

        }

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

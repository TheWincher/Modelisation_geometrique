using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercice1 : MonoBehaviour
{
    public Material mat;
    public int hauteur, rayon, nbFace;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Vector3[] vertices = new Vector3[nbFace * 2 + 2];
        int[] triangles = new int[3 * ((2 * nbFace) + (nbFace * 2))];
        Debug.Log(3 * ((2 * nbFace) + (nbFace * 2)));

        for(int i = 0; i < nbFace; i++)
        {
            float angle = 2 * Mathf.PI * (((float)i) / ((float)nbFace));
            float x = rayon * Mathf.Cos(angle);
            float y = rayon * Mathf.Sin(angle);
   
            vertices[i] = new Vector3(x, -hauteur / 2, y);
            vertices[i + nbFace] = new Vector3(x, hauteur / 2, y);
        }

        vertices[nbFace * 2] = new Vector3(0, -hauteur / 2, 0) ;
        vertices[nbFace * 2 + 1] = new Vector3(0, hauteur / 2, 0);

        for (int i = 0; i < nbFace; i++)
        {
            triangles[i * 6] = i % nbFace;
            triangles[i * 6 + 1] = (i + 1) % nbFace;
            triangles[i * 6 + 2] = (i + 1) % nbFace + nbFace; 

            triangles[i * 6 + 3] = (i + 1) % nbFace + nbFace;
            triangles[i * 6 + 4] = i % nbFace + nbFace;
            triangles[i * 6 + 5] = i % nbFace;
        }

        for (int i = 0; i < nbFace; i++)
        {
            triangles[i * 3 + (nbFace * 6)] = i % nbFace;
            triangles[i * 3 + (nbFace * 6) + 1] = (i + 1) % nbFace;
            triangles[i * 3 + (nbFace * 6) + 2] = nbFace * 2;
        }

        Debug.Log(nbFace * 3 + (nbFace * 6));
        Debug.Log(nbFace + (nbFace * 6));

        for (int i = 0; i < nbFace; i++)
        {
            triangles[(i % nbFace) * 3 + nbFace * 9] = (i % nbFace) + nbFace;
            triangles[(i % nbFace) * 3 + nbFace * 9 + 1] = (i + 1) % nbFace + nbFace;
            triangles[(i % nbFace) * 3 + nbFace * 9 + 2] = nbFace * 2 + 1;
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

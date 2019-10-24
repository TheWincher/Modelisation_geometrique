using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triceratops : MonoBehaviour
{

    string filePath = "Assets/triceratops.off";
    public Material mat;
    public Camera mainCamera;
    public int sizeCell;
    Vector3[] vertices;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        ReadWriteFileOFF.Read(filePath, ref vertices, ref triangles);

        Mesh msh = new Mesh();

        msh.vertices = vertices;
        msh.triangles = triangles;
        msh.RecalculateNormals();

        gameObject.GetComponent<MeshFilter>().mesh = msh;
        gameObject.GetComponent<MeshRenderer>().material = mat;

    }

    List<Vector4> createGrid(Vector3[] vertices, float minX, float minY, float minZ)
    {
        List<Vector4> grid = new List<Vector4>();

        return grid;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

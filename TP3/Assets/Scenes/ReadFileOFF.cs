using System;
using System.Globalization;
using System.IO;
using UnityEngine;

public class ReadWriteFileOFF
{
    public static void Read(String fileName, ref Vector3[] vertices, ref int[] triangles)
    {
        int nbSommet, nbTriangle, nbEdge;
        string s;

        StreamReader reader = new StreamReader(fileName);

        //Read type file (OFF)
        s = reader.ReadLine();

        s = reader.ReadLine();
        string[] sNumber = s.Split(' ');

        //Read number of apex
        nbSommet = int.Parse(sNumber[0]);

        //Init Apex array
        vertices = new Vector3[nbSommet];

        //Read the number of triangle
        nbTriangle = int.Parse(sNumber[1]);

        //Init array of triangle
        triangles = new int[nbTriangle * 3];

        //Read number of edge
        nbEdge = int.Parse(sNumber[2]);

        Vector3 maxVec = Vector3.zero;
        Vector3 vCentrage = Vector3.zero; 
        for (int i = 0; i < nbSommet; i++)
        {
            s = reader.ReadLine();
            string[] sApex = s.Split(' ');

            vertices[i] = new Vector3(float.Parse(sApex[0], CultureInfo.InvariantCulture), float.Parse(sApex[1], CultureInfo.InvariantCulture), float.Parse(sApex[2], CultureInfo.InvariantCulture));

            vCentrage += vertices[i];
            if (vertices[i].magnitude > maxVec.magnitude)
                maxVec = vertices[i];
        }

        vCentrage /= nbSommet;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] -= vCentrage;
            vertices[i] /= maxVec.magnitude;
        }

        for (int i = 0; i < nbTriangle * 3; i += 3)
        {
            s = reader.ReadLine();
            string[] sTriangle = s.Split(' ');

            triangles[i] = int.Parse(sTriangle[1]);
            triangles[i + 1] = int.Parse(sTriangle[2]);
            triangles[i + 2] = int.Parse(sTriangle[3]);
        }

        reader.Close();
    }

    public static void Write(string fileName, Vector3[] vertices, int[] triangles)
    {
        StreamWriter writer = new StreamWriter(fileName);

        //Write type file (OFF)
        writer.WriteLine("OFF");

        //Write number of apex, triangle and edge
        writer.WriteLine(vertices.Length + " " + (triangles.Length / 3)+ " " + 0);

        //Write all apex
        for (int i = 0; i < vertices.Length; i++)
            writer.WriteLine(vertices[i].x.ToString(new CultureInfo("en-US")) + " " + vertices[i].y.ToString(new CultureInfo("en-US")) + " " + vertices[i].z.ToString(new CultureInfo("en-US")));

        //Write all index of triangles
        for (int i = 0; i < triangles.Length; i += 3)
            writer.WriteLine("3 " + triangles[i] + " " + triangles[i + 1] + " " + triangles[i + 2]);

        //Close the writer
        writer.Close();
    }
}
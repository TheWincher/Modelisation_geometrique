using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereEnumSpatial : MonoBehaviour
{
    public GameObject cubePrefabs;
    public Vector3[] sphereCenter;
    public Vector3 scaleCube;
    public float[] rayon;

    private float width, height, depth;
    // Start is called before the first frame update
    void Start()
    {
        cubePrefabs.transform.localScale = scaleCube;
        float xMin = sphereCenter[0].x - rayon[0], xMax = sphereCenter[0].x + rayon[0], yMin = sphereCenter[0].y - rayon[0], yMax = sphereCenter[0].y + rayon[0], zMin = sphereCenter[0].z - rayon[0], zMax = sphereCenter[0].z + rayon[0];
        for (int i = 1; i < sphereCenter.Length; i++)
        {
            if (sphereCenter[i].x - rayon[i] < xMin)
                xMin = sphereCenter[i].x - rayon[i];

            if (sphereCenter[i].x + rayon[i] > xMax)
                xMax = sphereCenter[i].x + rayon[i];

            if (sphereCenter[i].y - rayon[i] < yMin)
                yMin = sphereCenter[i].y - rayon[i];

            if (sphereCenter[i].y + rayon[i] > yMax)
                yMax = sphereCenter[i].y + rayon[i];

            if (sphereCenter[i].z - rayon[i] < zMin)
                zMin = sphereCenter[i].z - rayon[i];

            if (sphereCenter[i].z + rayon[i] > zMax)
                zMax = sphereCenter[i].z + rayon[i];
        }

        Debug.Log(cubePrefabs.transform.localScale);
        for (float x = xMin ; x < xMax; x += cubePrefabs.transform.localScale.x)
        {
            for(float y = yMin; y <yMax; y += cubePrefabs.transform.localScale.y)
            {
                for (float z = zMin; z < zMax; z += cubePrefabs.transform.localScale.z)
                {
                    //bool isInside = normalSphere(new Vector3(x, y, z));
                    bool isInside = normalSphere(new Vector3(x, y, z));
                    if (isInside)
                        Instantiate(cubePrefabs, new Vector3(x, y, z), Quaternion.identity);
                }
            }
        }
    }

    private bool normalSphere(Vector3 pos)
    {
        for (int i = 0; i < sphereCenter.Length; i++)
        {
            float inSide = (pos.x - sphereCenter[i].x) * (pos.x - sphereCenter[i].x) + (pos.y - sphereCenter[i].y) * (pos.y - sphereCenter[i].y) + (pos.z - sphereCenter[i].z) * (pos.z - sphereCenter[i].z) - rayon[i] * rayon[i];
            if (inSide < 0)
                return true;
        }
        return false;
    }

    private bool intersecSphere(Vector3 pos)
    {
        int nbSphere = 0;
        for(int i = 0; i < sphereCenter.Length; i++)
        {
            float inSide = (pos.x - sphereCenter[i].x) * (pos.x - sphereCenter[i].x) + (pos.y - sphereCenter[i].y) * (pos.y - sphereCenter[i].y) + (pos.z - sphereCenter[i].z) * (pos.z - sphereCenter[i].z) - rayon[i] * rayon[i];
            if (inSide < 0)
                nbSphere++;
        }
        return nbSphere >= 2;
    }

    private bool unionSphere(Vector3 pos)
    {
        int nbSphere = 0;
        for (int i = 0; i < sphereCenter.Length; i++)
        {
            float inSide = (pos.x - sphereCenter[i].x) * (pos.x - sphereCenter[i].x) + (pos.y - sphereCenter[i].y) * (pos.y - sphereCenter[i].y) + (pos.z - sphereCenter[i].z) * (pos.z - sphereCenter[i].z) - rayon[i] * rayon[i];
            if (inSide < 0)
                nbSphere++;
        }
        return nbSphere >= 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

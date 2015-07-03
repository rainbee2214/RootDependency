using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshCreator : MonoBehaviour
{
    public Vector3 point = Vector3.up;
    public int numberOfPoints = 10;

    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    void Start()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "StarMesh";

        vertices = new Vector3[numberOfPoints + 1];
        triangles = new int[numberOfPoints * 3];
        float angle = -360f / numberOfPoints;
        for (int v = 1, t = 1; v < vertices.Length; v++, t += 3)
        {
            vertices[v] = Quaternion.Euler(0f, 0f, angle * (v - 1)) * point;
            triangles[t] = v;
            triangles[t + 1] = v + 1;
        }

        triangles[triangles.Length - 1] = 1;

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
   
}

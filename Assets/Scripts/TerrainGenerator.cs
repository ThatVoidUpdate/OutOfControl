using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter), typeof(MeshCollider))]
public class TerrainGenerator : MonoBehaviour
{
    public int xSize;
    public int zSize;

    public float XScale;
    public float ZScale;

    public float YScale;

    public float angle;

    private Vector3[] Vertices;
    private Mesh mesh;
    private MeshCollider collider;

    public void Awake()
    {
        GenerateMesh();
    }

    void GenerateMesh()
    {
        collider = GetComponent<MeshCollider>();
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.name = "Terrain";
        Vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                Vertices[i] = new Vector3(x * XScale, 0, z * ZScale) + (Vector3.up * Random.value * YScale) - Vector3.up * Mathf.Tan(angle * Mathf.Deg2Rad) * z * ZScale;

            }
        }
        mesh.vertices = Vertices;
        int[] triangles = new int[xSize * zSize * 6];
        for (int ti = 0, vi = 0, y = 0; y < zSize; y++, vi++)
        {
            for (int x = 0; x < xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;
            }
        }
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        collider.sharedMesh = mesh;

    }
}

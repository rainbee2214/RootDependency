using UnityEngine;
using System.Collections;

public class SolidMeshCreator : MonoBehaviour 
{
	public Material material;
	static Vector3[] vertices;
	static Vector2[] uv;
	static int[] triangles;

	public static Mesh Create()
	{
		Mesh mesh = new Mesh();
		mesh.Clear();
		vertices = new Vector3[] 
		{
			//Triangle based pyramid
			new Vector3(-0.5f, -0.5f, -0.5f), 
			new Vector3(0.5f, -0.5f, -0.5f),
			new Vector3(0f, -0.5f, 0.5f), 
			new Vector3(0f, 0.5f, 0f) 
			
			//Square based pyramid
			//			new Vector3(0f, 0f, 0f), 
			//			new Vector3(1f, 0f, 0f), 
			//			new Vector3(1f, 0f, 1f),
			//			new Vector3(0f, 0f, 1f), 
			//			new Vector3(0.5f, 1f, 0.5f), 
			
			//Cube
			//			new Vector3(0, 0, 0), 
			//			new Vector3(1, 0, 0), 
			//			new Vector3(1, 1, 0),
			//			new Vector3(0, 1, 0), 
			//			new Vector3(0, 0, -1), 
			//			new Vector3(1, 0, -1),
			//			new Vector3(1, 1, -1), 
			//			new Vector3(0, 1, -1)
		};
		
		triangles = new int[]{
			//Triangle based pyramid
			0,1,3,
			1,2,3,
			2,0,3,
			
			1,0,2
			
			//Square based pyramid
			//			4,1,0,
			//			4,0,3,
			//			4,3,2,
			//			4,2,1,
			//
			//			1,2,3,
			//			3,0,1
			
			// Trianges for the outside of the cube
			//			2,1,0,
			//			0,3,2,
			//
			//			5,4,0,
			//			0,1,5,
			//
			//			1,2,6,
			//			6,5,1,
			//			
			//			6,2,3,
			//			3,7,6,
			//
			//			4,5,7,
			//			5,6,7,
			//
			//			3,0,4,
			//			4,7,3
			
			// Trianges for the inside of the cube
			//			6,7,3,
			//			0,1,2,
			//			2,3,0,
			//			0,4,5,
			//			5,1,0,
			//			6,2,1,
			//			1,5,6,
			//			3,2,6,
			//			7,6,5,
			//			7,5,4,
			//			4,0,3,
			//			3,7,4,
			
		};
		
		uv = new Vector2[vertices.Length];
		int i = 0;
		while (i < uv.Length) {
			uv[i] = new Vector2(vertices[i].x, vertices[i].z);
			i++;
		}
		
		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.triangles = triangles;
		mesh.RecalculateNormals();
		return mesh;
	}

	void Start()
	{
		gameObject.AddComponent("MeshFilter");
		gameObject.AddComponent("MeshRenderer");
		transform.gameObject.renderer.material = material;
		//GetComponent<MeshFilter>().mesh
		Create();
	}

	void Update() 
	{
	}

}

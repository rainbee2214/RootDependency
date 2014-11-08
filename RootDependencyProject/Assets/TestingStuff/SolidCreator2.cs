using UnityEngine;

public static class SolidCreator2
{
	public static Mesh Create (float radius)
	{
		Vector3[] vertices =
		{
			Vector3.down, 
			Vector3.forward,
			Vector3.left,
			Vector3.back, 
			Vector3.right, 
			Vector3.up
		};
		
		int[] triangles =
		{
			0,1,2,
			0,2,3,
			0,3,4,
			0,4,1,
			
			5,2,1,
			5,3,2,
			5,4,3,
			5,1,4
		};
		
		Vector3[] normals = new Vector3[vertices.Length];
		Normalize(vertices, normals);
		
		Vector2[] uv = new Vector2[vertices.Length];
		CreateUV(vertices, uv);
		
		Vector4[] tangents = new Vector4[vertices.Length];
		CreateTangents(vertices, tangents);
		
		if (radius != 1f)
		{
			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] *= radius;
			}
		}
		
		Mesh mesh = new Mesh();
		mesh.name = "Octahedron";
		mesh.vertices = vertices;
		mesh.normals = normals;
		mesh.uv = uv;
		mesh.tangents = tangents;
		mesh.triangles = triangles;
		
		return mesh;
	}
	
	private static void Normalize (Vector3[] vertices, Vector3[] normals)
	{
		for (int i = 0; i < vertices.Length; i++)
		{
			normals[i] = vertices[i] = vertices[i].normalized; 
		}
	}
	
	public static void CreateUV (Vector3[] vertices, Vector2[] uv)
	{
		for (int i = 0; i < vertices.Length; i++)
		{
			Vector3 v = vertices[i];
			Vector2 textureCoordinates;
			textureCoordinates.x = Mathf.Atan2 (v.x, v.z) / (-2f * Mathf.PI);
			if (textureCoordinates.x < 0f)
			{
				textureCoordinates.x += 1f;
			}
			textureCoordinates.y = Mathf.Asin (v.y) / Mathf.PI + 0.5f;
			uv[i] = textureCoordinates;
		}
	}
	
	private static void CreateTangents (Vector3[] vertices, Vector4[] tangents)
	{
		for (int i = 0; i < vertices.Length; i++)
		{
			Vector3 v = vertices[i];
			v.y = 0f;
			v = v.normalized;
			Vector4 tangent;
			tangent.x = -v.z;
			tangent.y = 0f;
			tangent.z = v.x;
			tangent.w = -1f;
			tangents[i] = tangent;
		}
		
		tangents[vertices.Length - 4] = tangents[0] = new Vector3(-1f, 0, -1f).normalized;
		tangents[vertices.Length - 3] = tangents[1] = new Vector3(1f, 0, -1f).normalized;
		tangents[vertices.Length - 2] = tangents[2] = new Vector3(1f, 0, 1f).normalized;
		tangents[vertices.Length - 1] = tangents[3] = new Vector3(-1f, 0, 1f).normalized;
		for (int i = 0; i < 4; i++)
		{
			tangents[vertices.Length - 1 - i].w = tangents[i].w = -1f;
		}
	}
	
}

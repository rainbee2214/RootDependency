using UnityEngine;
using System.Collections;

public class Functions : MonoBehaviour 
{
	public enum FunctionOption {
		Linear,
		AbsoluteValue,
		Quadratic,
		Exponential,
		Logarithmic,
		Sine, 
		Cosecant, 
		Cosine, 
		Secant, 
		Tangent, 
		Cotangent, 
		ArcSine,
		ArcCosine, 
		ArcTangent
	}

	public FunctionOption function;

	private delegate float FunctionDelegate (float x);
	private static FunctionDelegate[] functionDelegates =
	{
		Linear,
		AbsoluteValue,
		Quadratic,
		Exponential,
		Logarithmic,
		Sine, 
		Cosecant, 
		Cosine, 
		Secant, 
		Tangent, 
		Cotangent,
		ArcSine,
		ArcCosine, 
		ArcTangent
	};

	[Range(100, 10000)]
	public int resolution = 100;
	private int currentResolution;

	public ParticleSystem.Particle[] points;

	void Start () 
	{
		CreatePoints();
	}

	private void CreatePoints()
	{
		currentResolution = resolution;
		points = new ParticleSystem.Particle[resolution * 2];
		float increment = 10f / (resolution);
		for (int i = 0; i < resolution; i += 2)
		{
			float x = i * increment;
			points[i].position = new Vector3(x, 0f, 0f);
			points[i].color = new Color(x, 0f, 0f);
			points[i].size = 0.05f;
			points[i + 1].position = new Vector3(-x, 0f, 0f);
			points[i + 1].color = new Color(x, 0f, 0f);
			points[i + 1].size = 0.05f;
		}
	}

	void Update () 
	{
		if (currentResolution != resolution || points == null) CreatePoints();

		FunctionDelegate f = functionDelegates[(int)function];
		for (int i = 0; i < resolution; i++) 
		{
			Vector3 point = points[i].position;
			point.y =  f(point.x);
			points[i].position = point;

			Color color = Color.black;
			color.g = point.y;
			points[i].color = color;
		}

		particleSystem.SetParticles(points, points.Length);
	}

	private static float Linear(float x)
	{
		return x;
	}

	private static float AbsoluteValue(float x)
	{
		if (x < 0) return -x;
		else return x;
	}

	private static float Quadratic(float x)
	{
		return x*x;
	}

	private static float Exponential(float x)
	{
		return Mathf.Exp (x);
	}
	
	private static float Logarithmic(float x)
	{
		return Mathf.Log(x);
	}

	private static float Sine(float x)
	{
		return Mathf.Sin(Mathf.PI * x + Time.timeSinceLevelLoad);
	}

	private static float Cosecant(float x)
	{
		return 1 / (Mathf.Sin(Mathf.PI * x + Time.timeSinceLevelLoad));
	}

	private static float Cosine(float x)
	{
		return Mathf.Cos(Mathf.PI * x + Time.timeSinceLevelLoad);
	}

	private static float Secant(float x)
	{
		return 1 / (Mathf.Cos(Mathf.PI * x + Time.timeSinceLevelLoad));
	}

	private static float Tangent(float x)
	{
		return Mathf.Tan(Mathf.PI * x + Time.timeSinceLevelLoad);
	}

	private static float Cotangent(float x)
	{
		return 1 / (Mathf.Tan(Mathf.PI * x + Time.timeSinceLevelLoad));
	}

	private static float ArcSine(float x)
	{
		return Mathf.Asin(Mathf.PI * x);
	}
	
	private static float ArcCosine(float x)
	{
		return Mathf.Acos(Mathf.PI * x);
	}
	
	private static float ArcTangent(float x)
	{
		return Mathf.Atan(Mathf.PI * x);
	}
}

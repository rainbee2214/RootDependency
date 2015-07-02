using UnityEngine;
using System.Collections;

public class Spiral : MonoBehaviour
{
    [Range(0f,100f)]        public float radius = 3f;
    [Range(0f, Mathf.PI*2)] public float theta = 0f;
    [Range(0f, 1f)]         public float delta = 0.1f;
    public bool reversed;
    
    Vector2 position;

    void Awake()
    {
        StartCoroutine("StartSpiral");
    }

    void GetPolar()
    {
        position.Set(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta));
        transform.position = position;
        theta = reversed ? theta < 0 ? Mathf.PI*2 : theta - delta : theta > Mathf.PI * 2 ? 0 : theta + delta;
    }

    IEnumerator StartSpiral()
    {
        while (true)
        {
            GetPolar();
            yield return null;
        }
    }
}

using UnityEngine;
using System.Collections;

public class PrimeGenerator : MonoBehaviour
{
    public int upperBound = 10;
    GameObject[] numbers;
    
    void Awake()
    {
        numbers = new GameObject[upperBound];
        GameObject numberPrefab = Resources.Load("Prefabs/Number", typeof(GameObject)) as GameObject;
        for (int i = 0; i < upperBound; i++)
        {
            numbers[i] = Instantiate(numberPrefab) as GameObject;
            numbers[i].name = ""+i;
            numbers[i].transform.parent = transform;
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}

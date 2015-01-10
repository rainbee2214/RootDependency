using UnityEngine;
using System.Collections;

public class PrimeGenerator : MonoBehaviour
{
    public int upperBoundNumbers = 10;
    GameObject[] numbers;

    int lowerBound = 0;
    int upperBound = 2;
    int count = 1;
    int numberOfElements;

    int direction = 1;

    static int negation = -1;

    void Awake()
    {
        numberOfElements = count * 2;
        numbers = new GameObject[upperBoundNumbers];
        GameObject numberPrefab = Resources.Load("Prefabs/Number", typeof(GameObject)) as GameObject;
        for (int i = 0; i < upperBoundNumbers; i++)
        {
            numbers[i] = Instantiate(numberPrefab) as GameObject;
            numbers[i].name = ""+i;
            numbers[i].transform.parent = transform;
        }

        //Place quads in position to create spiral
        GetMovement();
    }


    void GetMovement()
    {
        count = 1;
        direction = 1;
        numberOfElements = count * 2;
        lowerBound = 0;
        upperBound = 2;

        Vector2 position = Vector2.zero;
        Vector2 movement = Vector2.zero;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (i == upperBound)
            {
                lowerBound = upperBound;
                upperBound += numberOfElements;
                count++;
                numberOfElements = count * 2;
                direction *= negation;
            }
            if (InBetween(i, lowerBound, upperBound))
            {
                //For movement along x
                movement = Vector2.right * direction;

                //For movement along y;
                //movement = Vector.up * direction;
            }
            position += movement;
            numbers[i].transform.position = position;
        }
    }

    bool InBetween(int target, int lessThan, int greaterthan)
    {
        return (target >= lessThan && target < greaterthan);
    }
   
}

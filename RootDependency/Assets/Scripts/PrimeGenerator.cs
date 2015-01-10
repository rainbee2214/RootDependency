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

    int negation = -1;

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
        Vector2 position = Vector2.zero;
        int k = 0;
        foreach (GameObject number in numbers)
        {
            //Determine movement amount based on i
            position += GetMovement(count);
            number.transform.position = position;
            k++;
        }
    }

    Vector2 GetMovement(int i)
    {
        Debug.Log("Getting movement! " + i);
        Vector2 m = Vector2.right;

        if (i >= lowerBound && i < upperBound)
        {
            int halfBound = numberOfElements / 2;
            for (int k = 0; k < numberOfElements; k++)
            {
                //First half of elements move in x, second half, move in y
                if (k <= halfBound)
                {
                    m = Vector2.right * direction;
                }
                else
                {
                    m = Vector2.up * direction;
                }
            }
            //Find whether its positive or negative
            //Find out how many iterations we need

            count++;
        }
        else if (i == upperBound) Increment(i);

        return m;
    }

    void Increment(int i)
    {
        Debug.Log("Increment! " + i);
        //Increments lowerBound, upperBound
        lowerBound = upperBound;
        upperBound += count * 2;
        count++;
        numberOfElements = count * 2;
        direction = (count % 2 == 0) ? direction * negation : direction;
    }

   
}

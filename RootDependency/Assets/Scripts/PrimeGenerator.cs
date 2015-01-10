using UnityEngine;
using System.Collections;

public class PrimeGenerator : MonoBehaviour
{
    public Color[] colors;
    public int currentColor = 0;
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
        if (colors == null)
        {
            colors = new Color[1];
            colors[0] = Color.white;
        }
        numberOfElements = count * 2;
        numbers = new GameObject[upperBoundNumbers];
        GameObject numberPrefab = Resources.Load("Prefabs/Number", typeof(GameObject)) as GameObject;
        for (int i = 0; i < upperBoundNumbers; i++)
        {
            numbers[i] = Instantiate(numberPrefab) as GameObject;
            numbers[i].name = ""+(i)+":"+(i+2);
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
        int middle = lowerBound + ((upperBound - lowerBound) / 2);
        for (int i = 0; i < numbers.Length; i++)
        {
            //if (i==10)
            //{
            //    Debug.Log("------------------------------------------------------");
            //}
            //if (i == 0)
            //{
            //    movement = Vector2.right;
            //    position += movement;
            //    numbers[i].transform.position = position;
            //    numbers[i].renderer.material.color = colors[currentColor+1];
            //}
            //else if (i==1)
            //{
            //    movement = Vector2.up;
            //    position += movement;
            //    numbers[i].transform.position = position;
            //    count++;
            //}
            //else
            {
                middle = lowerBound + ((upperBound - lowerBound) / 2);
                if (i == upperBound)
                {
                    int temp = numberOfElements;
                    lowerBound = upperBound;
                    count++;
                    upperBound = upperBound + (count*2);
                    numberOfElements += 2;
                    direction *= -1;
                    middle = lowerBound + ((upperBound - lowerBound) / 2);
                }
                if (InBetween(i, lowerBound, upperBound))
                {
                    if (i >= middle) movement = Vector2.up * direction;
                    else movement = Vector2.right * direction;
                }

                position += movement;
                numbers[i].transform.position = position;

                if (i % 2 == 0) numbers[i].renderer.material.color = colors[currentColor+1];
                else numbers[i].renderer.material.color = colors[currentColor];

            }
            Debug.Log("i: "+i+" Count: "+count+" Direction: "+direction+" LowerBound: "+lowerBound+" UpperBound: "+upperBound+" NumberOfElements: "+numberOfElements+" Middle: "+middle+"");
        }
    }

    bool InBetween(int target, int lessThan, int greaterthan)
    {
        return (target >= lessThan && target < greaterthan);
    }
   
}

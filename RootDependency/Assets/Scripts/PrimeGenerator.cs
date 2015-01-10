﻿using UnityEngine;
using System.Collections;
using System;

public class PrimeGenerator : MonoBehaviour
{
    public Color[] colors;
    public int currentColor = 0;
    [Range(10, 10000)]
    public int upperBoundNumbers = 10;
    GameObject[] numbers;

    int lowerBound = 0;
    int upperBound = 2;
    int count = 1;

    int direction = 1;

    void Awake()
    {
        if (colors == null)
        {
            colors = new Color[1];
            colors[0] = Color.white;
        }
        numbers = new GameObject[upperBoundNumbers];
        GameObject numberPrefab = Resources.Load("Prefabs/Number", typeof(GameObject)) as GameObject;
        for (int i = 0; i < upperBoundNumbers; i++)
        {
            numbers[i] = Instantiate(numberPrefab) as GameObject;
            numbers[i].name = ""+(i)+":"+(i+2);
            numbers[i].transform.parent = transform;
        }

        //Place quads in position to create spiral
        GetSpiral();
    }


    void GetSpiral()
    {
        count = 1;
        direction = 1;
        lowerBound = 0;
        upperBound = 2;

        Vector2 position = Vector2.zero;
        Vector2 movement = Vector2.zero;
        int middle = lowerBound + ((upperBound - lowerBound) / 2);
        for (int i = 0; i < numbers.Length; i++)
        {
           
            middle = lowerBound + ((upperBound - lowerBound) / 2);
            if (i == upperBound)
            {
                lowerBound = upperBound;
                count++;
                upperBound = upperBound + (count*2);
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


            //if (i % 2 == 0) numbers[i].renderer.material.color = colors[currentColor+1];
            //else numbers[i].renderer.material.color = colors[currentColor];

            numbers[i].renderer.material.color = colors[currentColor];
            //if it's a prime, turn it black
            bool isPrime = true;
            for (int k = 2; k < Mathf.Sqrt(i+2); k++)
            {
                if (i % k == 0)
                {
                    isPrime = false;
                }
            }

            if(isPrime) numbers[i].renderer.material.color = colors[currentColor+1];
        }
    }

    bool InBetween(int target, int lessThan, int greaterthan)
    {
        return (target >= lessThan && target < greaterthan);
    }
   
}

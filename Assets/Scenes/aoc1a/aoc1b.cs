using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoc1b : MonoBehaviour
{
    public int deeperCount = 0;
    // Start is called before the first frame update
    void Start()
    {
    string[] reader = System.IO.File.ReadAllLines( "Assets/Scenes/aoc1a/input.txt" );

    int lastSum = int.Parse(reader[0])+int.Parse(reader[1])+int.Parse(reader[2]);
    int newSum = 0;

    for ( int i = 3; i < reader.Length; i++ )
        {
            newSum = int.Parse(reader[i])+int.Parse(reader[i-1])+int.Parse(reader[i-2]);
            Debug.Log("The last sum was: "+ lastSum + " The new sum is: " + newSum + "(at pos "+ i +")");
            if (newSum>lastSum) 
            { 
                deeperCount ++;
                Debug.Log("Deeper!");
            }
            lastSum = newSum;
        }
        Debug.Log("There are "+ deeperCount.ToString() + " measurements deeper than the previous one");
    } 


    // Update is called once per frame
    void Update()
    {
        
    }
}

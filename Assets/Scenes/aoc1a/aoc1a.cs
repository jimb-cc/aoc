using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoc1a : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    string[] reader = System.IO.File.ReadAllLines( "Assets/Scenes/aoc1a/input.txt" );
    for ( int i = 0; i < reader.Length; i++ )
    {
        Debug.Log( "Primary key is " + i + ". The data is " + reader[i]  + "\n");
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoc1a : MonoBehaviour
{
    public int deeperCount = 0;
    public GameObject Cell;

    // Start is called before the first frame update
    void Start()
    {

    


    string[] reader = System.IO.File.ReadAllLines( "Assets/Scenes/aoc1a/input.txt" );
        for ( int i = 0; i < reader.Length; i++ )
        {
            if (i>0){
                Debug.Log( "index is " + i + ". The data is " + reader[i]  + " the previous point was " + reader[i-1] + "\n");

                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(1.1f*i, (int.Parse(reader[i])/10)*-1, 0);
                cube.GetComponent<MeshRenderer>().material.color = Color.yellow;
                //is this value greater than the previous value?
                if (int.Parse(reader[i])>int.Parse(reader[i-1]))
                {
                    deeperCount++;
                    Debug.Log("Deeper!\n");
                    cube.GetComponent<MeshRenderer>().material.color = Color.blue;
                }
            }
        }
        Debug.Log("There are "+ deeperCount.ToString() + " measurements deeper than the previous one");
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
*/
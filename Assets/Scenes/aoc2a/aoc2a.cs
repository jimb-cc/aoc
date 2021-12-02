using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoc2a : MonoBehaviour
{

    public int fwdCount = 0;
    public int depthCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        string[] reader = System.IO.File.ReadAllLines( "Assets/Scenes/aoc2a/input.txt" );
        for ( int i = 0; i < reader.Length; i++ )
        {
            string[] subs = reader[i].Split(' ');
            //Debug.Log(subs[0]);
            //Debug.Log(subs[1]);

              
            switch (subs[0])  
            {  
            case "forward":  
                fwdCount += int.Parse(subs[1]);
                Debug.Log("we're going forward by " + subs[1] + " for a total of " + fwdCount);  
            break;  
            case "up":
                depthCount -= int.Parse(subs[1]);  
                Debug.Log("we're going up by " + subs[1] + " for a total depth of " + depthCount);
            break;  
            case "down": 
                depthCount += int.Parse(subs[1]); 
                Debug.Log("we're going down by " + subs[1] + " for a total of " + depthCount);
            break;  
            default:  
                Debug.Log("No idea what we're doing!");  
            break;  
            }

        }
        Debug.Log("depthCount*fwdCount = "+ depthCount*fwdCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

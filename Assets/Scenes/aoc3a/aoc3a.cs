using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoc3a : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] reader = System.IO.File.ReadAllLines( "Assets/Scenes/aoc3a/input.txt" );
        
        int[,] bits = new int[reader.Length, reader[0].Length];
        Debug.Log("array is "+ reader.Length + " by " + reader[0].Length);
        for ( int i = 0; i < reader.Length; i++ )
        {
            //Debug.Log("-------------");

            //Debug.Log(reader[i]);

            for (int index = 0; index < reader[i].Length; index++)
            {
                //Debug.Log(reader[i][index]); // Display it
                bits[i,index] = int.Parse(reader[i][index].ToString()); // Read next character in string
                //Debug.Log("bits["+i+"] ["+ index +"] is "+ bits[i,index].ToString()); // Display it
            }
        }
        
        //find the gamma
        int[] gamma = new int[reader[0].Length];

        for ( int coll = 0; coll < reader[0].Length; coll++ )
        {
            int ones = 0;
            int zeros = 0;
            
            for (int row = 0; row < reader.Length; row++ )
            {

              if (bits[row,coll]==1)
              {
                  //Debug.Log("Found a One at "+coll+","+row);
                  ones++;
              }  else
              {
                  //Debug.Log("Found a Zero at "+coll+","+row);
                  zeros++;
              }
            }
            Debug.Log("Column["+coll+"] Ones:" +ones.ToString()+ " Zeros:"+zeros.ToString());
            
            if (ones>zeros)
            {
                gamma[coll] = 1;
            } else
            {
                gamma[coll] = 0;
            }
        }
        
        // gamma is an array of 12 ints. 
        Debug.Log("gamma:"+string.Join("", gamma));

        string gammaStr = string.Join("", gamma);
        int fromBase = 2;
        int toBase = 10;

        string result = Convert.ToString(Convert.ToInt32(gammaStr, fromBase), toBase);
        int gammaDec = int.Parse(result);
        Debug.Log("gammaDec:"+gammaDec.ToString());


        //find Epsilon
        int[] epsilon = new int[reader[0].Length];

        for ( int coll = 0; coll < reader[0].Length; coll++ )
        {
            if(gamma[coll]==1) epsilon[coll] = 0; else epsilon[coll] = 1;
        }
        string epsilonStr = string.Join("", epsilon);
        Debug.Log("gamma:"+gammaStr+" epsilon:"+epsilonStr);

        string eresult = Convert.ToString(Convert.ToInt32(epsilonStr, fromBase), toBase);
        int epsilonDec = int.Parse(eresult);
        Debug.Log("epsilonDec:"+epsilonDec.ToString());


        //power of sub is gamma*epsilon
        Debug.Log("sub Power:"+(gammaDec*epsilonDec).ToString());



    }

    // Update is called once per frame
    void Update()
    {   
         AppHelper.Quit();
    }
}

 public static class AppHelper
 {
     #if UNITY_WEBPLAYER
     public static string webplayerQuitURL = "http://google.com";
     #endif
     public static void Quit()
     {
         #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
         #elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
         #else
         Application.Quit();
         #endif
     }
 }










/*
        var count = new Dictionary<int, int>();
        foreach (int value in theArray) 
        {
            if (count.ContainsKey(value)) 
            {
                count[value]++;
            } else {
                count.Add(value, 1);
            }
        }
        int mostCommonValue = 0;
        int highestCount = 0;
        foreach (KeyValuePair<int, int> pair in count) 
        {
            if (pair.Value > highestCount) 
            {
                mostCommonValue = pair.Key;
                highestCount = pair.Value;
            }
        }
*/
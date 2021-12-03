using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoc3b : MonoBehaviour
{
    List<string> listOfBits;
    List<string> listOfeBits;

    int o2 = 0;
    int co2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        // read input data
        string[] reader = System.IO.File.ReadAllLines( "Assets/Scenes/aoc3a/input.txt" );
        // dump input into list
        listOfBits = new List<string>(reader);

        for (int position=0; position < reader[0].Length; position++ )
        {
            int mostCommon = findMostCommon(listOfBits, position);
            Debug.Log("most common:" +mostCommon);
            o2 = removeFromList(listOfBits, position, mostCommon);
        }

        listOfeBits = new List<string>(reader);

        for (int position=0; position < reader[0].Length; position++ )
        {
            int leastCommon = findLeastCommon(listOfeBits, position);
            Debug.Log("least common:" +leastCommon);
            co2 = removeFromList(listOfeBits, position, leastCommon);
        }

        Debug.Log("~~~~~~~>>> o2:"+o2+" co2:"+co2);


    }


    int removeFromList(List<string> listOfBits, int position, int mostCommon)
    {
            listOfBits.RemoveAll(row => 
            {
                if (row[position].ToString().Equals(mostCommon.ToString()))
                {
                    //Debug.Log("false - keeping");
                    return false;
                }
                else
                {
                    //Debug.Log("true - removing");
                    return true;                    
                }
                
            });
        int value = 0;
        Debug.Log("Num Items in list:" + listOfBits.Count);
        foreach (var item in listOfBits) Debug.Log(item.ToString());
        Debug.Log("+++++++++++++");
        if(listOfBits.Count!=0)
        {
            if (listOfBits.Count == 1)
            {
                value = convertBase2to10(listOfBits[0]);
                Debug.Log("just one left: " +listOfBits[0]);
                Debug.Log("################################### in dec:"+value);
                Debug.Log("+++++++++++++");
                
                
            }
        }
        return value;
    }


    int convertBase2to10(string value)
    {
        int fromBase = 2;
        int toBase = 10;

        string result = Convert.ToString(Convert.ToInt32(value, fromBase), toBase);
        return int.Parse(result);
    }


    // pass in a list, and a position and it will return the most common value in for that position
    int findMostCommon(List<string> listOfBits, int position)
    {
        Debug.Log("-------------");       
        int ones=0;

        for (int i = 0; i<listOfBits.Count; i++)
        {
            int result = String.Compare(listOfBits[i][position].ToString(),"1");
            if (result == 0) ones++;
        }

        Debug.Log("ones:"+ ones + " zeros:" +(listOfBits.Count - ones)+ " count:" +listOfBits.Count);

        int mostCommon;
        if (ones > (listOfBits.Count - ones)) mostCommon = 1; 
        else if (ones == (listOfBits.Count - ones)) mostCommon = 1;
        else mostCommon = 0;
        return mostCommon;
    }


    int findLeastCommon(List<string> listOfBits, int position)
    {
        Debug.Log("-------------");       
        int ones=0;

        for (int i = 0; i<listOfBits.Count; i++)
        {
            int result = String.Compare(listOfBits[i][position].ToString(),"1");
            if (result == 0) ones++;
        }

        Debug.Log("ones:"+ ones + " zeros:" +(listOfBits.Count - ones)+ " count:" +listOfBits.Count);

        int leastCommon;
        if (ones > (listOfBits.Count - ones)) leastCommon = 0; 
        else if (ones == (listOfBits.Count - ones)) leastCommon = 0;
        else leastCommon = 1;
        return leastCommon;
    }













    // Update is called once per frame
    void Update()
    {   
         AppHelper.Quit();
    }
}



// 3878091
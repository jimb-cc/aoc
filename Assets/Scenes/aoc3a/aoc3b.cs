using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoc3b : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] reader = System.IO.File.ReadAllLines( "Assets/Scenes/aoc3a/input.txt" );
        string oxy ="";
        int oxyDec = 0;
        string co2 ="";
        int co2Dec =0;
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

       /* for ( int coll = 0; coll < reader[0].Length; coll++ )
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

            } else if (ones==zeros)
            {
                gamma[coll] = 1;

            } else 
            {
                gamma[coll] = 0;

            }
        }
*/
        ////////////////////////////////////////////////////////////////////////////////////
        // should we recalc the count of ones and zeros every time we remove from the list?
        ////////////////////////////////////////////////////////////////////////////////////
        
        // gamma is an array of 12 ints, the most common bit in each column.
        //Debug.Log("gamma:"+string.Join("", gamma));

        //create a list with all the rows in.

        List<string> listOfBits = new List<string>();

        // populate the list with the original data

        for (int row = 0; row < reader.Length; row++ )
        {
            listOfBits.Add(reader[row]);
        }

        // find the most common bits for the reamaining items in the list.

        for ( int coll = 0; coll < reader[0].Length; coll++ )
        {
            int ones = 0;
            int zeros = 0;
            
            for (int row = 0; row < listOfBits.Count; row++ )
            {
                int result = String.Compare(listOfBits[row][coll].ToString(),"1");
                Debug.Log("result: "+result);
                /*
                if (listOfBits[row][coll].Equals("1"))
                {
                    //Debug.Log("Found a One at "+coll+","+row);
                    ones++;
                }  else
                {
                    //Debug.Log("Found a Zero at "+coll+","+row);
                    zeros++;
                }*/
                }
                
            Debug.Log("Column["+coll+"] Ones:" +ones.ToString()+ " Zeros:"+zeros.ToString());
            
            if (ones>zeros)
            {
                gamma[coll] = 1;

            } else if (ones==zeros)
            {
                gamma[coll] = 1;

            } else 
            {
                gamma[coll] = 0;

            }
        }

        // most common bit in postition 0 is: gamma[0]
        Debug.Log("Most common bit in position 0 is "+ gamma[0]);
        Debug.Log("there are "+ listOfBits.Count + " entries in the list");


        //remove all the rows that don't match this gamma
        for ( int coll = 0; coll < reader[0].Length; coll++ )
        {

            listOfBits.RemoveAll(row => 
            {
                Debug.Log("{"+coll+"} row:" + row + "row[" +coll+"]:"+ row[coll]+ " gamma:" +gamma[coll].ToString());
                int result = String.Compare(row[coll].ToString(),gamma[coll].ToString());
                if (result==0)
                {
                    Debug.Log("match - keeping "+ result.ToString());
                    return false;
                }
                else
                {
                    Debug.Log("no match - removing "+ result.ToString());
                    return true;                    
                }
                
            });
            Debug.Log("++++++++++++++");
            Debug.Log("there are "+ listOfBits.Count + " entries in the list");
                    for (int listItem = 0; listItem < listOfBits.Count; listItem++)
                    {
                        Debug.Log("listitem["+listItem+"] "+listOfBits[listItem]);
                    }
            Debug.Log("-------------");
            
            if (listOfBits.Count == 1)
            {
                
                oxy = listOfBits[0].ToString();

                int fromBase = 2;
                int toBase = 10;

                string result = Convert.ToString(Convert.ToInt32(oxy, fromBase), toBase);
                oxyDec = int.Parse(result);


                Debug.Log("just one left: " +oxy+ " -> oxyDec = " +oxyDec.ToString());


                
            }
        }

//find Epsilon
        int[] epsilon = new int[reader[0].Length];
// create epsilon by inverting gamma
/*        for ( int coll = 0; coll < reader[0].Length; coll++ )
        {
            if(gamma[coll]==1) epsilon[coll] = 0; else epsilon[coll] = 1;
        }
        
*/  
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
            //Debug.Log("Column["+coll+"] Ones:" +ones.ToString()+ " Zeros:"+zeros.ToString());
            
            if (ones>zeros)
            {
                epsilon[coll] = 0;
            } else
            {
                epsilon[coll] = 1;
            }
        }
        string epsilonStr = string.Join("", epsilon);





        // Epsilon is an array of 12 chars, the least common bit in each column.
        Debug.Log("epsilon:"+string.Join("", epsilonStr));

        //create a list with all the rows in.

        List<string> listOfeBits = new List<string>();

        // populate the list with the original data

        for (int row = 0; row < reader.Length; row++ )
        {
            listOfeBits.Add(reader[row]);
        }



        // least common bit in postition 0 is: epsilon[0]
        Debug.Log("Most common bit in position 0 is "+ epsilon[0]);
        Debug.Log("there are "+ listOfeBits.Count + " entries in the list");

        //remove all the rows that don't match this gamma
        for ( int coll = 0; coll < reader[0].Length; coll++ )
        {

            listOfeBits.RemoveAll(row => 
            {
                
                int result = String.Compare(row[coll].ToString(),epsilon[coll].ToString());
                if (result==0)
                {
                    
                    return false;
                }
                else
                {
                    
                    return true;                    
                }
                
            });

            Debug.Log("there are "+ listOfeBits.Count + " epislon entries in the list");
            if (listOfeBits.Count == 1)
            {
                
                co2 = listOfeBits[0].ToString();

                int fromBase = 2;
                int toBase = 10;

                string result = Convert.ToString(Convert.ToInt32(co2, fromBase), toBase);
                co2Dec = int.Parse(result);


                Debug.Log("just one co2 left: " +co2+ " -> co2Dec = " +co2Dec.ToString());


                
            }

        Debug.Log("Life support rating:" + (oxyDec * co2Dec).ToString());

    }

    // Update is called once per frame
    void Update()
    {   
         AppHelper.Quit();
    }
}
}


// 3878091
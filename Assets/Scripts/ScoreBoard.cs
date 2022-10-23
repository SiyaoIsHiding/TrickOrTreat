using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
<<<<<<< Updated upstream
    // Start is called before the first frame update
    void Start()
    {
        
=======
    static public int candyCounter;
    static public int happyKidsCounter;

    // Start is called before the first frame update
    void Start()
    {
        candyCounter = 100;
        happyKidsCounter = 0;
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        
    }
<<<<<<< Updated upstream
=======

    public static int GetCandyCounter()
    {
        return candyCounter;
    }
    public static void DecreaseCandyCounter(int candyNum)
    {
        candyCounter -= candyNum;
    }
>>>>>>> Stashed changes
}

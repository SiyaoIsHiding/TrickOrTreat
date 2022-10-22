using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class KidsController : MonoBehaviour
{
    public GameObject[] AllKidsPool;
    static public Kid[] WhoAreComing()
    {
        // return an array of kids. You can access the ShownUp and NumCandiesHolding of each kid.
        Kid[] kids = new Kid[] { new Kid() };
        Random rdm = new Random();
        float i = rdm.Next(1);
        if (i < 0.5)
        {
            kids[0].ShownUp = true;
        }

        return kids;
    }

    static public void Spray()
    {
        
    }

    void Start()
    {
        Instantiate(AllKidsPool[0], this.transform);
    }
  
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class KidsController : MonoBehaviour
{
    public GameObject[] AllKidsPool;
    public GameObject[] KidsAlive;
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
        instantiateKids(chooseKidsComing());
    }

    void Update()
    {

    }

    private GameObject[] chooseKidsComing()
    {
        // Implement later
        return new GameObject[] { AllKidsPool[0] };
    }

    private void instantiateKids(GameObject[] kidsToSpawn)
    {
        foreach (var kid in kidsToSpawn)
        {
            Instantiate(kid, this.transform);
        }

        KidsAlive = kidsToSpawn;
    }
}

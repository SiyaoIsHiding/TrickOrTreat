using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KidStore
{
    public static Kid[] allKids;
    public static List<Kid> newKids;
    public static List<Kid> oldKids;
    private static float newKidProb = Singleton.Instance.NewKidProb;
    private static float multipleCandyProb = Singleton.Instance.MultiCandyProb;
    private static int maxCandy = Singleton.Instance.MaxCandy;

    static KidStore()
    {
        allKids = new Kid[Singleton.Instance.NumCharacters];
        newKids = new List<Kid>();
        oldKids = new List<Kid>();
        for (int i = 0; i < allKids.Length; i++)
        {
            allKids[i] = new Kid(i);
            newKids.Add(allKids[i]);
        }
    }
    public static int[] ChooseKidsComing()
    {
        int newKidInd = -1;
        float i;
        if (oldKids.Count > 0)
        {
            i = UnityEngine.Random.Range(0f, 1f);
            if (i > newKidProb)
            {
                // old kid
                int j = UnityEngine.Random.Range(0, oldKids.Count);
                newKidInd = oldKids[j].id;
            }
            else if (newKids.Count > 0)
            {
                // new kid
                int j = UnityEngine.Random.Range(0, newKids.Count);
                newKidInd = newKids[j].id;
            }
        }
        // no old kid
        else if (newKids.Count > 0)
        {
            // new kid
            int j = UnityEngine.Random.Range(0, newKids.Count);
            newKidInd = newKids[j].id;
        }
        else
        {
            throw new Exception("No Kids are coming. Game ends.");
            // TODO: Notify Skylar Game Ends
        }
        
        // Choose how many candies they are gonna take

        Kid kid = allKids[newKidInd];
        i = UnityEngine.Random.Range(0.0f, 1.0f);
        if (i > multipleCandyProb)
        {
            // single candy
            kid.NumCandyHolding = 1;
        }
        else
        {
            int num = UnityEngine.Random.Range(2,maxCandy+1);
            kid.NumCandyHolding = num;
        }
        Debug.Log(kid);
        
        return new int[] { newKidInd };
    }

    public static void KidReturn(int kidIndex)
    {
        Kid kid = allKids[kidIndex];
        if (!kid.ShownUp)
        {
            newKids.Remove(kid);
            oldKids.Add(kid);
            kid.ShownUp = true;
        }
    }

    public static void Spray(int kidIndex)
    {
        Kid kid = allKids[kidIndex];
        kid.Sprayed = true;
        if (kid.ShownUp)
        {
            oldKids.Remove(kid);
        }
        else
        {
            newKids.Remove(kid);
        }
        
    }
    
}
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
        int j;
        if (oldKids.Count == 0 && newKids.Count == 0)
        {
            Debug.Log("No Kids are coming. Game ends.");
            GameObject scoreBoard  = GameObject.Find("Scoreboard");
            scoreBoard.GetComponent<ScoreBoard>().gameOver.Gameover();
            return new []{0};
            // TODO: Notify Skylar Game Ends
        }else if (oldKids.Count == 0)
        {
            // new kids only
            j = UnityEngine.Random.Range(0, newKids.Count);
            newKidInd = newKids[j].id;
        }else if (newKids.Count == 0)
        {
            // old kid only
            j = UnityEngine.Random.Range(0, oldKids.Count);
            newKidInd = oldKids[j].id;
        }
        else
        {
            // both old kids and new kids existing
            i = UnityEngine.Random.Range(0f, 1f);
            if (i > newKidProb)
            {
                // old kid
                j = UnityEngine.Random.Range(0, oldKids.Count);
                newKidInd = oldKids[j].id;
            }
            else
            {
                // new kid
                j = UnityEngine.Random.Range(0, newKids.Count);
                newKidInd = newKids[j].id;
            }
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
            Debug.Log("Remove old kid index: " + kidIndex);
            
        }
        else
        {
            newKids.Remove(kid);
            Debug.Log("Remove new kid index: " + kidIndex);
            kid.ShownUp = true;
        }
        
    }
    
}
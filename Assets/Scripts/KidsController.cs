using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class KidsController : MonoBehaviour
{
    
    private static KidsController instance;
    [FormerlySerializedAs("_kidPrefab")] public GameObject kidPrefab;
    
    public Sprite[] AllSprites;
    public List<int> KidsAliveIndex = new List<int>();

    public List<Kid> NewKids = KidStore.newKids;
    public List<Kid> OldKids = KidStore.oldKids;


    static public Kid[] WhoAreComing()
    {
        // return an array of kids. You can access the ShownUp and NumCandiesHolding of each kid.
        Kid[] kids = new Kid[] { new Kid(0) };
        Random rdm = new Random();
        float i = rdm.Next(1);
        if (i < 0.5)
        {
            kids[0].ShownUp = true;
        }

        return kids;
    }

    public int candyChanged()
    {
        // called when a player sprays
        Kid[] kidsComing = WhoAreComing();
        bool succeed = false;
        foreach (Kid kid in kidsComing)
        {
            if (kid.ShownUp)
            {
                succeed = true;
                break;
            }

            if (kid.NumCandyHolding > 1)
            {
                succeed = true;
            }
        }

        if (succeed)
        {
            return 0;
        }
        else
        {
            return -5;
        }
    }

    static public void Spray()
    {
        
    }

    static public void KidInvisible(int kidId)
    {
        instance.KidsAliveIndex.Remove(kidId);
        // TODO: check whether all kidsGO invisible
        KidStore.KidReturn(kidId);
        instance.sendNewKids();
    }

    private void sendNewKids()
    {
        
        
        int[] newKidsIndex = KidStore.ChooseKidsComing(); // assume only 1
        int thisKidIndex = newKidsIndex[0];
        GameObject thisKidGO = Instantiate(kidPrefab, this.transform);
        thisKidGO.GetComponent<KidMovement>().associatedKid = KidStore.allKids[thisKidIndex];
        KidsAliveIndex.Add(thisKidIndex);
        KidsChangeSprites(thisKidGO, thisKidIndex);
        Debug.Log("Newkids: "+string.Join(",", NewKids));
        Debug.Log("Oldkids: "+string.Join(",", OldKids));
    }

    void Start()
    {
        instance = this;
        sendNewKids();
    }

    void Update()
    {

    }
    

    private void KidsChangeSprites(GameObject kidGO, int kidIndex)
    {
        kidGO.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = AllSprites[kidIndex];
    }
    
}

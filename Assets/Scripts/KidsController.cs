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
        // will return only one now
        Kid kid = KidStore.allKids[instance.KidsAliveIndex[0]];
        return new Kid[] {kid};
    }


    static public void Spray()
    {
        GameObject.Find("Scoreboard").GetComponent<ScoreBoard>().KidHasLeft();
        // Only one now
        Kid kid = KidStore.allKids[instance.KidsAliveIndex[0]];
        kid.Sprayed = true;
        KidStore.Spray(kid.id);
    }

    static public void KidInvisible(int kidId)
    {
        GameObject.Find("Scoreboard").GetComponent<ScoreBoard>().KidHasLeft();
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

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
    public Sprite[] AllBlueSprites;
    public List<int> KidsAliveIndex = new List<int>();

    public List<Kid> NewKids = KidStore.newKids;
    public List<Kid> OldKids = KidStore.oldKids;
    private GameObject thisKidGO;


    static public Kid[] WhoAreComing()
    {
        // will return only one now
        Kid kid = KidStore.allKids[instance.KidsAliveIndex[0]];
        return new Kid[] {kid};
    }


    static public void Spray()
    {

        // Only one now
        ScoreBoard.UpdateScore(true);
        Kid kid = KidStore.allKids[instance.KidsAliveIndex[0]];
        kid.Sprayed = true;
        instance.thisKidGO.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite =
            instance.AllBlueSprites[instance.KidsAliveIndex[0]];
        KidStore.Spray(kid.id);
        instance.thisKidGO.GetComponent<KidMovement>().state.Sprayed();
    }

    static public void KidInvisible(int kidId)
    {
        ScoreBoard.UpdateScore(false);
        instance.KidsAliveIndex.Remove(kidId);
        KidStore.KidReturn(kidId);
        instance.sendNewKids();
    }

    private void sendNewKids()
    {
        
        
        int[] newKidsIndex = KidStore.ChooseKidsComing(); // assume only 1
        int thisKidIndex = newKidsIndex[0];
        thisKidGO = Instantiate(kidPrefab, this.transform);
        thisKidGO.GetComponent<KidMovement>().associatedKid = KidStore.allKids[thisKidIndex];
        KidsAliveIndex.Add(thisKidIndex);
        KidsChangeSprites(thisKidGO, thisKidIndex);
        if(ScoreBoard.Instance)
        {ScoreBoard.NewKidsComing();}
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

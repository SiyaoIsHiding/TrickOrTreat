using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class KidsController : MonoBehaviour
{
    
    private static KidsController instance;
    private static readonly int MaxGroupSize = Singleton.Instance.MaxGroupSize;
    [FormerlySerializedAs("_kidPrefab")] public GameObject kidPrefab;

    public Kid[] AllKids;
    public Sprite[] AllSprites;
    public List<GameObject> KidsAlive = new List<GameObject>();

    
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

    static public void Spray()
    {
        
    }

    static public void KidInvisible(GameObject kidGO)
    {
        instance.KidsAlive.Remove(kidGO);
        // TODO: check whether all kidsGO invisible
        instance.sendNewKids();
    }

    private void sendNewKids()
    {
        GameObject newKid = Instantiate(kidPrefab, this.transform);
        KidsAlive.Add(newKid);
        KidsChangeSprites(newKid, ChooseKidsComing()[0]);
    }

    void Start()
    {
        instance = this;
        
        sendNewKids();
    }

    void Update()
    {

    }

    private int[] ChooseKidsComing()
    {
        // Implement later
        int newKidInd = UnityEngine.Random.Range(0, 38);
        return new int[] { newKidInd };
    }
    

    private void KidsChangeSprites(GameObject kidGO, int kidIndex)
    {
        kidGO.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = AllSprites[kidIndex];
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class KidsController
{
    static public Kid[] WhoAreComing()
    {
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
}

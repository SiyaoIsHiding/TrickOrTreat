using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = System.Random;

public class KidsController
{

    static Kid[] whoAreComing()
    {
        Kid[] kids = new Kid[] { new Kid() };
        Random rnd = new Random();
        float i = rnd.Next(1);
        if (i < 0.5)
        {
            kids[0].shownUp = true;
        }
        return kids;
    }
}

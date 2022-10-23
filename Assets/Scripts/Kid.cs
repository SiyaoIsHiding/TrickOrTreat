using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid
{
    public int id;
    public bool ShownUp;
    public bool Sprayed;
    public int NumCandyHolding;

    public Kid(int _id)
    {
        id = _id;
        ShownUp = false;
        Sprayed = false;
        NumCandyHolding = 0;
    }

    public override string ToString()
    {
        return $"id: {id}; Shownup: {ShownUp}; Sprayed: {Sprayed}; Candy: {NumCandyHolding}";
    }
}

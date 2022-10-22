using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : BaseState
{
    public Escape(GameObject _kid, Rigidbody2D _rb) : base(_kid, _rb)
    {
        currState = STATE.ESCAPE;
    }

    public override void Enter()
    {
        rb.velocity = Singleton.Instance.EscapingSpeed;
        base.Enter();
    }
}
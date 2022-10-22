using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leave : BaseState
{
    public Leave(GameObject _kid, Rigidbody2D _rb) : base(_kid, _rb)
    {
        currState = STATE.LEAVE;
        
    }

    public override void Enter()
    {
        rb.velocity = Singleton.Instance.LeavingSpeed;
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leave : BaseState
{
    private float timeInterval;
    public Leave(GameObject _kid, Rigidbody2D _rb) : base(_kid, _rb)
    {
        currState = STATE.LEAVE;
        
    }

    public override void Enter()
    {
        timeInterval = 0f;
        rb.velocity = Singleton.Instance.LeavingSpeed;
        base.Enter();
    }

    public override void Update()
    {
        timeInterval += Time.deltaTime;
        if (timeInterval >= Singleton.Instance.timeLeaving)
        {
            nextState = new Escape(kid, rb);
            stage = EVENT.EXIT;
        }
    }
}

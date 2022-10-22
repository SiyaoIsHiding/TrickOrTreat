using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCandy : BaseState
{
    private float timeInterval;
    public TakeCandy(GameObject _kid, Rigidbody2D _rb) : base(_kid, _rb)
    {
        currState = STATE.TAKECANDY;
    }

    public override void Enter()
    {
        timeInterval = 0f;
        rb.velocity = Vector2.zero;
        base.Enter();
    }

    public override void Update()
    {
        timeInterval += Time.deltaTime;
        if (timeInterval >= Singleton.Instance.timeTakingCandy)
        {
            nextState = new Leave(kid, rb);
            stage = EVENT.EXIT;
        }
    }
}
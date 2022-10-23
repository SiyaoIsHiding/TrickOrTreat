using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TakeCandy : BaseState
{
    private float timeInterval;
    private float[] timeIntervalShake;
    private int[] shakeDirections;
    public TakeCandy(GameObject _kid, Rigidbody2D _rb) : base(_kid, _rb)
    {
        currState = STATE.TAKECANDY;
        // TODO: Set 1 or More
        timeIntervalShake = Singleton.Instance.TimeIntervalShakeTakingMore;
        shakeDirections = Singleton.Instance.ShakeDirectionsTakingMore;
    }

    public override void Enter()
    {
        timeInterval = 0f;
        rb.velocity = Vector2.zero;
        kid.transform.rotation = Quaternion.identity;
        base.Enter();
    }

    private void shakingHandler()
    {
        int step = -1;
        for (int i = 0; i < timeIntervalShake.Length; i++)
        {
            if (timeInterval >= timeIntervalShake[i])
            {
                step = i;
            }
        }

        if (step == -1) return;
        switch (shakeDirections[step])
        {
            case 1:
                kid.transform.rotation = Singleton.Instance.TurnRight;
                break;
            case 0:
                kid.transform.rotation = Quaternion.identity;
                break;
            case -1:
                kid.transform.rotation = Singleton.Instance.TurnLeft;
                break;
        }
        

    }
    
    public override void Update()
    {
        timeInterval += Time.deltaTime;
        shakingHandler();
        // to exit
        if (timeInterval >= Singleton.Instance.TimeTakingCandy)
        {
            nextState = new Leave(kid, rb);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        kid.transform.rotation = Quaternion.identity;
        
        base.Exit();
    }
}
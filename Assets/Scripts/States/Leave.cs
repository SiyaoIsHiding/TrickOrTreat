using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leave : BaseState
{
    private float timeInterval;
    private float timeIntervalShake;
    private bool turnRight;
    public Leave(GameObject _kid, Rigidbody2D _rb) : base(_kid, _rb)
    {
        currState = STATE.LEAVE;
        
    }

    public override void Enter()
    {
        timeInterval = 0f;
        timeIntervalShake = 0f;
        turnRight = false;
        kid.transform.rotation = Singleton.Instance.TurnLeft;
        rb.velocity = Singleton.Instance.LeavingSpeed;
        base.Enter();
    }

    public override void Update()
    {
        timeInterval += Time.deltaTime;
        timeIntervalShake += Time.deltaTime;
        if (turnRight && timeIntervalShake >= Singleton.Instance.TimeToShakeLeaving)
        {
            turnRight = false;
            kid.transform.rotation = Singleton.Instance.TurnLeft;
            timeIntervalShake = 0;
        }
        else if (!turnRight && timeIntervalShake >= Singleton.Instance.TimeToShakeLeaving)
        {
            turnRight = true;
            kid.transform.rotation = Singleton.Instance.TurnRight;
            timeIntervalShake = 0;
        }
        
        
        if (timeInterval >= Singleton.Instance.TimeLeaving)
        {
            nextState = new Escape(kid, rb);
            stage = EVENT.EXIT;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Approach : BaseState
{
    private bool turnRight;
    private float timeIntervalShake;
    public Approach(GameObject _kid, Rigidbody2D rb) : base(_kid, rb)
    {
        currState = STATE.APPROACH;
    }

    public override void Enter()
    {
        rb.velocity = Singleton.Instance.ApproachingSpeed;
        kid.transform.rotation = Quaternion.identity;
        timeIntervalShake = 0;
        turnRight = false;
        base.Enter();
    }

    public override void Update()
    {
        timeIntervalShake += Time.deltaTime;
        if (turnRight && timeIntervalShake >= Singleton.Instance.timeToShakeAppraoching)
        {
            turnRight = false;
            kid.transform.rotation = Singleton.Instance.turnLeft;
            timeIntervalShake = 0;
        }
        else if (!turnRight && timeIntervalShake >= Singleton.Instance.timeToShakeAppraoching)
        {
            turnRight = true;
            kid.transform.rotation = Singleton.Instance.turnRight;
            timeIntervalShake = 0;
        }
        
        RaycastHit2D hit = Physics2D.Raycast(stopPos, Vector2.up);
        // Debug.DrawRay(stopPos, Vector3.up, Color.red);
        if (hit)
        {
            nextState = new TakeCandy(kid, rb);
            stage = EVENT.EXIT;
        }
            
    }

    public override void Exit()
    {
        kid.transform.rotation = Quaternion.identity;
        base.Exit();
    }
}

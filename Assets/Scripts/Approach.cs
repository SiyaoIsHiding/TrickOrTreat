using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Approach : BaseState
{
    public Approach(GameObject _kid, Rigidbody2D rb) : base(_kid, rb)
    {
        currState = STATE.APPROACH;
    }

    public override void Enter()
    {
        rb.velocity = Singleton.Instance.ApproachingSpeed;
        base.Enter();
    }

    public override void Update()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(stopPos, Vector2.up);
        Debug.DrawRay(stopPos, Vector3.up, Color.red);
        if (hit)
        {
            Debug.Log("Hit");
            nextState = new Leave(kid, rb);
            stage = EVENT.EXIT;
        }
            
    }
    
    
}

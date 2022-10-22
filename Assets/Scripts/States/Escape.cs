using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : BaseState
{
    private Renderer rd;
    private float timeIntervalShake;
    private bool turnRight;
    public Escape(GameObject _kid, Rigidbody2D _rb) : base(_kid, _rb)
    {
        currState = STATE.ESCAPE;
        rd = _kid.GetComponentInChildren<Renderer>();
    }

    public override void Enter()
    {
        timeIntervalShake = 0f;
        turnRight = false;
        kid.transform.rotation = Singleton.Instance.turnLeft;
        rb.velocity = Singleton.Instance.EscapingSpeed;
        base.Enter();
    }

    public override void Update()
    {
        if (turnRight && timeIntervalShake >= Singleton.Instance.timeToShakeEscaping)
        {
            turnRight = false;
            kid.transform.rotation = Singleton.Instance.turnLeft;
            timeIntervalShake = 0;
        }
        else if (!turnRight && timeIntervalShake >= Singleton.Instance.timeToShakeEscaping)
        {
            turnRight = true;
            kid.transform.rotation = Singleton.Instance.turnRight;
            timeIntervalShake = 0;
        }
        if (!rd.isVisible)
        {
            Object.Destroy(kid);
        }
        base.Update();
    }
}
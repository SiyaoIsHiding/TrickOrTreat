using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseState
{
    
    public enum STATE
    {
        APPROACH,
        LEAVE
    }

    public enum EVENT
    {
        ENTER,
        UPDATE,
        EXIT
    }

    // Parameters
    public static readonly Vector2 stopPos = new Vector2(3.0f, -5.0f);
    
    protected STATE currState;
    protected EVENT stage;
    protected GameObject kid;
    protected BaseState nextState;
    protected Rigidbody2D rb;

    public BaseState(GameObject _kid, Rigidbody2D _rb)
    {
        kid = _kid;
        stage = EVENT.ENTER;
        rb = _rb;
    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE;}
    public virtual void Exit(){stage = EVENT.EXIT;}

    public BaseState Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }

        return this;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : BaseState
{
    private Renderer rd;
    public Escape(GameObject _kid, Rigidbody2D _rb, Kid _associatedKid) : base(_kid, _rb, _associatedKid)
    {
        currState = STATE.ESCAPE;
        rd = _kid.GetComponentInChildren<Renderer>();
    }

    public override void Enter()
    {
        rb.velocity = Singleton.Instance.EscapingSpeed;
        kid.transform.rotation = Singleton.Instance.TurnRight;
        base.Enter();
    }

    public override void Update()
    {
        if (!rd.isVisible)
        {
            KidsController.KidInvisible(associatedKid.id);
            Object.Destroy(kid);
        }
        base.Update();
    }
}
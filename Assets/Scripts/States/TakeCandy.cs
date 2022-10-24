using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Video;

public class TakeCandy : BaseState
{
    private float timeInterval;
    private float[] timeIntervalShake;
    private int[] shakeDirections;
    private bool audioPlayed = false;
    public TakeCandy(GameObject _kid, Rigidbody2D _rb, Kid _associatedKid) : base(_kid, _rb, _associatedKid)
    {
        currState = STATE.TAKECANDY;
        // TODO: Set 1 or More
        if (associatedKid.NumCandyHolding == 1)
        {
            timeIntervalShake = Singleton.Instance.TimeIntervalShakeTaking1;
            shakeDirections = Singleton.Instance.ShakeDirectionsTaking1;
        }
        else
        {
            timeIntervalShake = Singleton.Instance.TimeIntervalShakeTakingMore;
            shakeDirections = Singleton.Instance.ShakeDirectionsTakingMore;
        }
    }

    public void Sprayed()
    {
        nextState = new Escape(kid, rb, associatedKid);
        stage = EVENT.EXIT;
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
                if (!audioPlayed)
                {
                    audioPlayed = true;
                    if (associatedKid.NumCandyHolding == 1)
                    {
                        kid.transform.GetChild(1).GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        kid.transform.GetChild(2).GetComponent<AudioSource>().Play();
                    }
                    
                }
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
            nextState = new Leave(kid, rb, associatedKid);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        kid.transform.rotation = Quaternion.identity;
        
        base.Exit();
    }
}
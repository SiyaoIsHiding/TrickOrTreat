using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KidMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public BaseState state;
    public Kid associatedKid = new Kid(-1);
    [SerializeField] private String stateName;
    public GameObject gameObject;
    public Rigidbody2D rb;
    void Start()
    {
        state = new Approach(gameObject, rb, associatedKid);  // generate a -1 kid first and then set kid id later.
    }
    
    // Update is called once per frame
    void Update()
    {
        stateName = state.ToString();
        state = state.Process();
    }
}

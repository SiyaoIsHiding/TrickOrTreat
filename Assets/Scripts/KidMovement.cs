using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KidMovement : MonoBehaviour
{
    // Start is called before the first frame update
    BaseState state;
    [SerializeField] private String stateName;
    public GameObject gameObject;
    public Rigidbody2D rb;
    void Start()
    {
        state = new Approach(gameObject, rb);
    }
    
    // Update is called once per frame
    void Update()
    {
        stateName = state.ToString();
        state = state.Process();
    }
}

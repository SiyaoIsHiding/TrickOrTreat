using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject sprayEffect;
    public Animator animator;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SprayChild());
            KidsController.Spray();
        }
    }

    IEnumerator SprayChild()
    {
        animator.SetBool("spraying", true);
        sprayEffect.SetActive(true);


        yield return new WaitForSeconds(1);

        animator.SetBool("spraying", false);
        sprayEffect.SetActive(false);
    }
}
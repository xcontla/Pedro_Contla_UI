using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    private Animator playerAnimator;

    private CapsuleCollider capsuleCollider;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();

        capsuleCollider = GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        playerAnimator.SetFloat("Speed", Input.GetAxis("Vertical") );
        playerAnimator.SetFloat("Direction", Input.GetAxis("Horizontal")  );

        if (Input.GetKeyDown(KeyCode.Q))
            playerAnimator.SetTrigger("Turn");

            
    }

}

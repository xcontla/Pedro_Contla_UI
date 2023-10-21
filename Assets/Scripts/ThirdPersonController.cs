using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    private Animator playerAnimator;

    private CapsuleCollider capsuleCollider;
    public GameObject gameHud;

    void Start()
    {
        gameHud.SetActive(true);
        playerAnimator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        gameHud.SetActive(false);
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

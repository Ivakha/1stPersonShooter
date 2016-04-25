using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    PlayerMovement playerMovement;
    Animator animator;

	void Start () {
        animator = GetComponentInChildren<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
	}
	
	void Update () {
        bool walking = playerMovement.GetForwardSpeed() != 0f || playerMovement.GetSideSpeed() != 0f;
        animator.SetBool("IsWalking", walking);
	}
}

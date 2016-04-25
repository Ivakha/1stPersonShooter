using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed = 5f;
    float forwardSpeed = 0;
    float sideSpeed = 0;
    CharacterController characterController;

	void Start () 
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
            Debug.Log("'FirstPersonController' is missing 'CharacterController' component");
	}
	
	void Update () 
    {
        forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);
        speed = transform.rotation * speed;
        characterController.SimpleMove(speed);
	}

    public float GetForwardSpeed()
    {
        return forwardSpeed;
    }

    public float GetSideSpeed()
    {
        return sideSpeed;
    }
}

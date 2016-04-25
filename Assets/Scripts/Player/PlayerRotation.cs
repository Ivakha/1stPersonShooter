using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour {

    public float mouseSensivity = 5f;
    public float upDownRotateRange = 60f;

    float verticalRotation = 0;

	void Start () {
	
	}
	
	void Update () {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensivity;
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRotateRange, upDownRotateRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
	}
}

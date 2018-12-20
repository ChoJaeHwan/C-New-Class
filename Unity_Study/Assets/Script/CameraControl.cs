using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public float sensitivity = 700.0f;
    float rotationX;
    float rotationY;

    void Update()
    {
        float mouseMoveValueX = Input.GetAxis("Mouse X");
        float mouseMoveValueY = Input.GetAxis("Mouse Y");

        rotationY += mouseMoveValueX * sensitivity * Time.deltaTime;
        rotationX += mouseMoveValueY * sensitivity * Time.deltaTime;

        rotationX %= 360; rotationY %= 360;

        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0.0f);
    }
}

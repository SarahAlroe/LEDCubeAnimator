using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Vector3 origo;
    public float rotSpeed;

    private Vector3 currentMousePosition;
    private Vector3 deltaMousePosition;
    private Vector3 lastMousePosition;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            currentMousePosition = Input.mousePosition;
            deltaMousePosition = currentMousePosition - lastMousePosition;
            lastMousePosition = currentMousePosition;
            transform.RotateAround(origo, Vector3.up, rotSpeed * deltaMousePosition.x);
            transform.RotateAround(origo, transform.right, -rotSpeed * deltaMousePosition.y);
        }else if (Input.GetMouseButton(2))
        {
            currentMousePosition = Input.mousePosition;
            deltaMousePosition = currentMousePosition - lastMousePosition;
            lastMousePosition = currentMousePosition;
            transform.position += transform.forward * rotSpeed*deltaMousePosition.y;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                hit.transform.GetComponent<LED>().switchActive();
            }
        }
    }
}

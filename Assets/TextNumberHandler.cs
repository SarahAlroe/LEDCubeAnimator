using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextNumberHandler : MonoBehaviour {

    public void setNumber(float number)
    {
        GetComponent<Text>().text = number.ToString();
           }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }
}

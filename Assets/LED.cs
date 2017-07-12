using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LED : MonoBehaviour {
    public bool isActive;

    public void switchActive()
    {
        if (isActive) {
            deactivate();
        }else
        {
            activate();
        }
    }

    public void setActive(bool active)
    {
        if (active)
        {
            activate();
        }else
        {
            deactivate();
        }
    }

    public void activate()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
//        GetComponent<Material>().SetColor(Shader.PropertyToID("LedMaterial"), Color.red);
        isActive = true;
    }
    public void deactivate()
    {
        GetComponent<MeshRenderer>().material.color= Color.white;
//        GetComponent<Material>().SetColor(Shader.PropertyToID("LedMaterial"), Color.white);
        isActive = false;
    }
   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

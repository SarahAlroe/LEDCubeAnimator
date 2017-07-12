using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImportExportEditorBehaviour : MonoBehaviour {

    public LEDCube cube;

    int moveDistance = 800;

    bool isImporting = false;

    bool isShowing = true;

	// Use this for initialization
	void Start () {
        transform.Translate(transform.up * moveDistance);
        isShowing = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showImport()
    {
        isImporting = true;
        if (!isShowing) { 
            transform.Translate(transform.up * -moveDistance);
            isShowing=!isShowing;
        }
        GetComponent<InputField>().text = "";
    }

    public void showExport()
    {
        isImporting = false;
        if (!isShowing)
        {
            transform.Translate(transform.up * -moveDistance);
            isShowing = !isShowing;
        }
        GetComponent<InputField>().text = cube.exportData();
    }

    public void hideEditor()
    {
        if (isShowing)
        {
            transform.Translate(transform.up * moveDistance);
            isShowing = !isShowing;
        }
        if (isImporting)
        {
            cube.loadData(GetComponent<InputField>().text);
        }

    }
}

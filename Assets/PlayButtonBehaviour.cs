using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonBehaviour : MonoBehaviour {

    public Text playText;
    public SliderBehaviour slider;

	// Use this for initialization
	void Start () {
        playText.text = "Play";
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp("Jump"))
        {
            playButtonClicked();
        }
        if (Input.GetButtonUp("Right")){
            slider.nextFrame();
        }
        if (Input.GetButtonUp("Left")){
            slider.prevFrame();
        }
    }

    public void playButtonClicked()
    {

        slider.isPlaying = !slider.isPlaying;

        if (slider.isPlaying)
        {
            playText.text = "Pause";
        }
        else
        {
            playText.text = "Play";
        }
    }

}

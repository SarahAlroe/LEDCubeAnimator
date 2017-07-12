using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour {
    Slider slider;
    public Text currentFrame;
    public Text frameCount;
    public LEDCube ledCube;

    public bool isPlaying = false;
    public float playInterval;
    float currentTime;

    public void updateValue()
    { currentFrame.text = slider.value.ToString();
        ledCube.changeFrame((int)slider.value-1);
    }

    public void increaseFrameCount()
    {
        slider.maxValue += 1;
        updateFrameCount();
    }
    public void setFrameCount(int count)
    {
        slider.maxValue = count;
        updateFrameCount();
    }

    public void decreaseFrameCount()
    {
        if (slider.maxValue > 1)
        {
            slider.maxValue -= 1;
            updateFrameCount();
        }
    }

    void updateFrameCount()
    {
        frameCount.text = slider.maxValue.ToString();
        ledCube.updateFrameCount((int)slider.maxValue);
    }

    public void nextFrame() {
        if (slider.value == slider.maxValue)
        {
            slider.value = slider.minValue;
        }else
        {
            slider.value += 1;
        }
        updateValue();
    }

    public void prevFrame()
    {
        if (slider.value == slider.minValue)
        {
            slider.value = slider.maxValue;
        }
        else
        {
            slider.value -= 1;
        }
        updateValue();
    }

    // Use this for initialization
    void Start () {
        currentTime = playInterval;
        slider = GetComponent<Slider>();
        updateValue();
        updateFrameCount();
	}

	
	// Update is called once per frame
	void Update () {
        if (isPlaying)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = playInterval;
                if (slider.value == slider.maxValue)
                {
                    slider.value = 0;
                    updateValue();
                }
                else
                {
                    slider.value += 1;
                    updateValue();
                }

            }
        }
    }

}

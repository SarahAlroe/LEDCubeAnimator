using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;


public class LEDCube : MonoBehaviour {
    public int sideLength = 64;
    public LED[] ledList;
    public SliderBehaviour slider;
    
    int currentFrame = 0;
    int frameRange = 0;
    List<bool[]> stateList = new List<bool[]>();

    public void changeFrame(int newFrame)
    {
        updateFrameCount(frameRange);
        for (int i=0; i<ledList.Length; i++)
        {
            stateList[currentFrame][i] = ledList[i].isActive;
            ledList[i].setActive(stateList[newFrame][i]);
        }
        currentFrame = newFrame;
    }

    public void reloadFrame()
    {
        for (int i = 0; i < ledList.Length; i++)
        {
            ledList[i].setActive(stateList[currentFrame][i]);
        }
    }

    public void updateFrameCount(int frameCount)
    {
        while (frameRange < frameCount)
        {
            stateList.Add(new bool[sideLength]);
            frameRange += 1;
        }
        while (frameRange > frameCount)
        {
            stateList.RemoveAt(frameRange - 1);
            frameRange -= 1;
        }
    }

    // Use this for initialization
    void Start () {
        
        sideLength = ledList.Length;
        updateFrameCount(1);
	}

    // Update is called once per frame
    void Update()
    {
    }

    public void loadData(string data)
    {
        List<bool[]> newStateList = new List<bool[]>();
        newStateList.Add(new bool[sideLength]);
        print(data);
        string cleanString = Regex.Replace(data, @"\D", "");
        print(cleanString);
        int i = 0;
        int j = 0;
        foreach (char c in cleanString)
        {
            if (i == sideLength) {
                i = 0;
                j++;
                newStateList.Add(new bool[sideLength]);
            }
            if (c==49){
                newStateList[j][i] = true;
            }
            else { newStateList[j][i] = false; }
            i++;
        }
        slider.setFrameCount(j);
        slider.updateValue();
        stateList = newStateList;
        print(stateList);
        reloadFrame();
    }

    public string exportData()
    {
        string outString = string.Empty;
        int i = 0;
        
        foreach(bool[] frame in stateList)
        {
            foreach(bool led in frame)
            {
                if (i == 0)
                {
                    outString += "B";
                }
                if (led == true)
                {
                    outString += "1";
                }else
                {
                    outString += "0";
                }
                if (i == 7)
                {
                    outString += ", ";
                    i = 0;
                }else
                {
                    i++;
                }
                
            }
        }
        return outString;
    }
		
}

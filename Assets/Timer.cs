using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerUI1;
    [SerializeField] Text timerUI2;
    [SerializeField] float timeRemaining1 = 10;
    [SerializeField] float timeRemaining2 = 10;
    bool timerIsActive1;
    bool timerIsActive2;
    bool hasBeenStarted1;
    bool hasBeenStarted2;

void Start() 
    {
    timerIsActive1 = true;
    timerIsActive2 = true;
    hasBeenStarted1 = false;
    hasBeenStarted2 = false;
    }

    void Update()
    {        
        if (timerIsActive1 && hasBeenStarted1)
            {
            if (timeRemaining1 > 0)
            {
            timeRemaining1 -= Time.deltaTime;
            DisplayTime(timeRemaining1, 1);
            }
            else
            {
            Debug.Log("TimeOut : " + timeRemaining1);
            timeRemaining1 = 0;
            timerIsActive1 = false;
            }
        }
        else
        {
            if (timeRemaining1 < 0)
            {
                timeRemaining1 = 0;
            }
            DisplayTime(timeRemaining1, 1);
        }
        
        if (timerIsActive2 && hasBeenStarted2)
            {
            if (timeRemaining2 > 0)
            {
            timeRemaining2 -= Time.deltaTime;
            DisplayTime(timeRemaining2, 2);
            }
            else
            {
            Debug.Log("TimeOut : " + timeRemaining2);
            timeRemaining2 = 0;
            timerIsActive2 = false;
            }
        }
        else
        {
            if (timeRemaining2 < 0)
            {
                timeRemaining2 = 0;
            }
            DisplayTime(timeRemaining2, 2);
        }
    }
    void DisplayTime(float displayedTime, int position)
    {
        //displayedTime+=1;
        float minutes = Mathf.FloorToInt(displayedTime / 60);
        float seconds = Mathf.FloorToInt(displayedTime % 60);
        float milliSeconds = (displayedTime % 1) * 1000;

        if(position == 1)
        {
            timerUI1.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
        }
        else if (position == 2)
        {
            timerUI2.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
        }
    }
    public void ButtonPush1()
    {
        hasBeenStarted1 = !hasBeenStarted1;
        hasBeenStarted2 = false;
    }
        public void ButtonPush2()
    {
        hasBeenStarted2 = !hasBeenStarted2;
        hasBeenStarted1 = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    [SerializeField] Text dayText;
    [SerializeField] float dayLength;
    float elapsedTimeToday = 0;
    int currentDay = 0;

    // ///////////////////////////////////////////


	void Start () {
		
	}
	
	void Update () {

        elapsedTimeToday += Time.deltaTime;
        if(elapsedTimeToday > dayLength)  { NewDay(); }
	}

    void NewDay()
    {
        elapsedTimeToday = 0;
        currentDay++;
        dayText.text = "Day " + currentDay;
    }
}

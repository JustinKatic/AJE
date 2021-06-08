using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardHeartDaily : MonoBehaviour
{

    DateTime dateLastHeartGiven;

    public IntVariable hearts;

    private void Start()
    {
        //get saved value of dateLastHeartGiven from player prefs
        string dateLastHeartGivenString = PlayerPrefs.GetString("dateLastHeartGiven", "");

        //if there was a saved value
        if (!dateLastHeartGivenString.Equals(""))
        {
            dateLastHeartGiven = DateTime.Parse(dateLastHeartGivenString);
            DateTime dateNow = DateTime.Now;

            if (dateNow > dateLastHeartGiven)
            {
                TimeSpan timeSpan = dateNow - dateLastHeartGiven;

                Debug.Log(timeSpan.TotalDays);

                if (timeSpan.TotalDays >= 1)
                {
                    if (hearts.Value == 0)
                        hearts.Value += 1;
                    //set a new 
                    dateLastHeartGiven = DateTime.Now;
                    PlayerPrefs.SetString("dateLastHeartGiven", dateLastHeartGiven.ToString());
                }
            }
        }
        else
        {
            dateLastHeartGiven = DateTime.Now;
            PlayerPrefs.SetString("dateLastHeartGiven", dateLastHeartGiven.ToString());
        }
    }
}

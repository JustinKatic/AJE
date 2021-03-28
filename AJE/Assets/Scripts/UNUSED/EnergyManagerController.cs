using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EnergyManagerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textEnergy;

    [SerializeField] TextMeshProUGUI textTimer;

    private bool restoring = false;


    [SerializeField] private int maxEnergy;

    private int totalEnergy = 0;

    private DateTime nextEnergyTime;

    private DateTime lastAddedTime;

    [SerializeField] int restoreDuration = 10;


    private void Start()
    {

        Load();
        StartCoroutine(RestoreRoutine());
    }

    public void UseEnergyMethod(int energyToLose)
    {
        if (totalEnergy == 0)
            return;

        totalEnergy-= energyToLose;
        UpdateEnergy();

        if (!restoring)
        {
            if (totalEnergy + 1 == maxEnergy)
            {
                //if energy is full just now
                nextEnergyTime = AddDuration(DateTime.Now, restoreDuration);
            }

                StartCoroutine(RestoreRoutine());
        }
    }

    private IEnumerator RestoreRoutine()
    {
        UpdateTimer();
        UpdateEnergy();
        restoring = true;

        while (totalEnergy < maxEnergy)
        {
            DateTime currentTime = DateTime.Now;
            DateTime counter = nextEnergyTime;
            bool isAdding = false;

            while (currentTime > counter)
            {
                if (totalEnergy < maxEnergy)
                {
                    isAdding = true;
                    totalEnergy++;
                    DateTime timeToAdd = lastAddedTime > counter ? lastAddedTime : counter;
                    counter = AddDuration(timeToAdd, restoreDuration);
                }
                else
                    break;
            }
            if (isAdding)
            {
                lastAddedTime = DateTime.Now;
                nextEnergyTime = counter;
            }
            UpdateTimer();
            UpdateEnergy();
            Save();
            yield return null;
        }
        restoring = false;
    }

    private void UpdateTimer()
    {
        if (totalEnergy >= maxEnergy)
        {
            textTimer.text = "full";
            return;
        }

        TimeSpan t = nextEnergyTime - DateTime.Now;
        string value = string.Format("{1:D2}:{2:D2}", (int)t.TotalHours, t.Minutes, t.Seconds);
        textTimer.text = value;
    }
    private void UpdateEnergy()
    {
        textEnergy.text = totalEnergy.ToString();
    }

    private DateTime AddDuration(DateTime time, int duration)
    {
        return time.AddSeconds(duration);
        //return time.AddMinutes(duration);
    }

    private void Load()
    {
        totalEnergy = PlayerPrefs.GetInt("totalEnergy");
        nextEnergyTime = StringToDate(PlayerPrefs.GetString("nextEnergyTime"));
        lastAddedTime = StringToDate(PlayerPrefs.GetString("lastAddedTime"));
    }


    public void Save()
    {
        PlayerPrefs.SetInt("totalEnergy", totalEnergy);
        PlayerPrefs.SetString("nextEnergyTime", nextEnergyTime.ToString());
        PlayerPrefs.SetString("LastAddedTime", lastAddedTime.ToString());
    }

    private DateTime StringToDate(string date)
    {
        if (string.IsNullOrEmpty(date))
            return DateTime.Now;

        return DateTime.Parse(date);
    }



}

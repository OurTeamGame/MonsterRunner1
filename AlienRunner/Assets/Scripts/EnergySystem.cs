using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnergySystem : MonoBehaviour
{
    public GameObject EnergyCountLable, TimerLable;
    public int EnergyCount, MaxEnergyCount;
    public int Day, Hour, Min, Sec;
    public int PastTime;//زمانی که از اخرین سر زدن بازیکن به منو گذشته
    public int AddEnergyCoolDown;//مدت زمانی برای اضافه شدن یک توپ باید منظر ماند
    public int ReminingTime;
    public float EnergyTimer;//تایمری که زمان اضافه شدن توپ را نشان می دهد
    // Start is called before the first frame update
    void Start()
    {
        EnergyTimer = PlayerPrefs.GetInt("EnergyTimer", 0);
        Debug.Log(EnergyTimer);
        if (EnergyTimer > AddEnergyCoolDown || EnergyTimer <= 0)
        {
            Debug.Log("Set");
            EnergyTimer = AddEnergyCoolDown;
        }
        GetAndSetDate();
       
    }

    // Update is called once per frame
    void Update()
    {
        EnergyCount = PlayerPrefs.GetInt("EnergyCount", 10);
        //اگر تعداد توپ از حداکثر کمتر بود تایمر کار کند
        if (EnergyCount < MaxEnergyCount)
        {
            EnergyTimer -= Time.deltaTime;
            if (PlayerPrefs.GetInt("Language", 0) == 0)
                TimerLable.GetComponent<Text>().text = TimeShow((int)EnergyTimer);
            /*else
                TimerLable.GetComponent<Text>().text = Fa.faConvert(TimeShow((int)EnergyTimer));*/
            

        }
        else
        {
            EnergyTimer = AddEnergyCoolDown;
            if (PlayerPrefs.GetInt("Language", 0) == 0)
                TimerLable.GetComponent<Text>().text = "max";
           /* else
               TimerLable.GetComponent<Text>().text = Fa.faConvert("حداکثر"); */
        }
        //-------------------------------------------------------
        
        if(EnergyTimer <= 0)
        {
            EnergyTimer = AddEnergyCoolDown;
            EnergyCount++;
            PlayerPrefs.SetInt("EnergyCount", EnergyCount);

        }
        //-------------------------------------------------------
        //تنظیم زبان
        if (PlayerPrefs.GetInt("Language", 0) == 0)
            EnergyCountLable.GetComponent<Text>().text = "" + EnergyCount;
        /*else
            EnergyCountLable.GetComponent<Text>().text = " X " + Fa.faConvert(EnergyCount+"");*/

        
        ReminingTime = (int)((MaxEnergyCount - EnergyCount) * AddEnergyCoolDown + EnergyTimer);
        PlayerPrefs.SetInt("EnergyTimer", (int)EnergyTimer);

       
    }
    string TimeShow(int TimeInSecend) 
    {
        int min, Sec;
        min = TimeInSecend / 60;
        Sec = TimeInSecend - (min * 60);

        if (min > 9 && Sec > 9)
            return min + ":" + Sec;
        if (min < 10 && Sec > 9)
            return "0" + min + ":" + Sec;
        if (min > 9 && Sec < 10)
            return min + ":" + "0" + Sec;
        if (min < 10 && Sec < 10)
            return "0" + min + ":" + "0" + Sec;
        return null;
    }
      void GetAndSetDate() 
    {
        Day = System.DateTime.Now.Day;
        Hour = System.DateTime.Now.Hour;
        Min = System.DateTime.Now.Minute;
        Sec = System.DateTime.Now.Second;

        //زمانی که از اخرین خروج کاربر گذشته حساب می کنیم
        PastTime = ((Day - PlayerPrefs.GetInt("Day", (int)System.DateTime.Now.Day)) * 86400 + (Hour - PlayerPrefs.GetInt("Hour", (int)System.DateTime.Now.Hour)) * 3600 + (Min - PlayerPrefs.GetInt("Min", (int)System.DateTime.Now.Minute)) * 60 + (Sec - PlayerPrefs.GetInt("Sec", (int)System.DateTime.Now.Second)));

          //اگر زمان گذشته از زمان مورد نباز برای پر شدن توپ ها بیشتر بود توپ را حداگتر کن
        if (PastTime > PlayerPrefs.GetInt("EnergyTimer", 0) + (MaxEnergyCount - PlayerPrefs.GetInt("EnergyCount", 10)) * AddEnergyCoolDown)
            EnergyCount = MaxEnergyCount;
        
        else
        {//تعداد تو پ را با توجه به ان افزایش می دهیم
            EnergyCount = PlayerPrefs.GetInt("EnergyCount", 10);
            EnergyCount = EnergyCount + (PastTime / AddEnergyCoolDown);
            EnergyTimer -= PastTime % AddEnergyCoolDown;


           if (EnergyTimer < 0)
            {
                EnergyCount++;
                EnergyTimer = AddEnergyCoolDown + EnergyTimer;
            }

           
        }
        PlayerPrefs.SetInt("EnergyCount", EnergyCount);

       PlayerPrefs.SetInt("Day", Day);
       PlayerPrefs.SetInt("Hour", Hour);
       PlayerPrefs.SetInt("Min", Min);
       PlayerPrefs.SetInt("Sec", Sec);
    }
    public void SaveTime(){
        Day = (int)System.DateTime.Now.Day;
        Hour = (int)System.DateTime.Now.Hour;
        Min = (int)System.DateTime.Now.Minute;
        Sec = (int)System.DateTime.Now.Second;
        PlayerPrefs.SetInt("Day", Day);
        PlayerPrefs.SetInt("Hour", Hour);
        PlayerPrefs.SetInt("Min", Min);
        PlayerPrefs.SetInt("Sec", Sec);
    }
    
}

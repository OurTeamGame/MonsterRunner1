using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class SetingManager : MonoBehaviour
{
    public GameObject SettingPanel,SettingButton,CloseButton;
    public GameObject RiseQualitty, DecriseQualitty;
    public GameObject QualityLevelName;
    string[] Names;
    int Qualitty = 2;
    
    public GameObject RiseResolotion, DecriseResolotion;
    public GameObject ResolotionName;
    int[] Wight = {800,1280,1920,2160,2560,2960};
    int[] Hight = {480,720,1080,1080,1440,1440};
    int Resolotion = 3;

    public GameObject Risevolume, Decrisevolume;
    public GameObject volume;
    float MusicLevel=0.4f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        Names = QualitySettings.names;
        //لود تنظیمات کاربر
        Qualitty =   PlayerPrefs.GetInt("Game_Qualitty", 2);
        Resolotion = PlayerPrefs.GetInt("Screen_Resolotion", 3);
        MusicLevel = PlayerPrefs.GetFloat("MusicLevel", 0.7f);

    }

    // Update is called once per frame
    void Update()
    {
        //یک لیست بازگشتی که بازدن دکمه کیفیت را بالا پایین می کند
        if (Qualitty > 5)
            Qualitty = 0;
        if (Qualitty < 0)
            Qualitty = 5;

        QualityLevelName.GetComponent<Text>().text = Names[Qualitty];
        QualitySettings.SetQualityLevel(Qualitty, true);
        //------------------------------------------------------------
        //با تغییر متغییر زیر رزولوشن صفحه هم تغییر می کند
        if (Resolotion > 5)
            Resolotion = 0;
        if (Resolotion < 0)
            Resolotion = 5;
        Screen.SetResolution(Wight[Resolotion], Hight[Resolotion], true);
        ResolotionName.GetComponent<Text>().text = Wight[Resolotion]+"X"+Hight[Resolotion];
        //------------------------------------------------------------
        if (MusicLevel > 1)
            MusicLevel = 1;
        if (MusicLevel < 0)
            MusicLevel = 0;
        AudioListener.volume = MusicLevel;
        volume.GetComponent<Text>().text = (int)(MusicLevel * 100) + "%";
        //------------------------------------------------------------
        //ذخیره تنظیمات کاربر
        PlayerPrefs.SetInt("Game_Qualitty", Qualitty);
        PlayerPrefs.SetInt("Screen_Resolotion", Resolotion);
        PlayerPrefs.SetFloat("MusicLevel", MusicLevel);
        //------------------------------------------------------------
        //بستن صفحه با زدن دکمه بک
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SettingPanel.activeSelf)
            {
                SettingPanel.SetActive(false);
            }
            else
            {
                Application.Quit();
            }
        }
        //------------------------------------------------------------
    }
    public void RiseQuality()
    {
        Qualitty++;
       
    }
    public void DecriseQuality()
    {
        Qualitty--;
    }
    public void RiseResoltion()
    {
        Resolotion++;
      

    }
    public void DecriseResoltion()
    {
        Resolotion--;
       
    }
    public void AddVolum()
    {
        MusicLevel += 0.1f;


    }
    public void DecriseVolum()
    {
        MusicLevel -= 0.1f;

    } 
    public void Close()
    {
        SettingPanel.SetActive(false);
    }
    public void ShowSetting()
    {
        SettingPanel.SetActive(true);
    }
}

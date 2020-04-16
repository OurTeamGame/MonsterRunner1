using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsSystem : MonoBehaviour
{
    string SceneName;
    int SelectedLevel;
    int LastUnlockedLevel;
    public Sprite Activelvl, UnActivelvl;
    public GameObject[] AllLevels;
    // Start is called before the first frame update
    void Start()
    {
        AllLevels = GameObject.FindGameObjectsWithTag("LevelBtn");
        LastUnlockedLevel = PlayerPrefs.GetInt("LastUnlock", 0);

        //تنظیم تصویر لول های فعال و غیر فعال
        for (int i = 0; i < AllLevels.Length; i++)
        { 
            if (i <= LastUnlockedLevel)
                AllLevels[i].GetComponent<Image>().sprite = Activelvl;
            else
                AllLevels[i].GetComponent<Image>().sprite = UnActivelvl;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLevel(GameObject selectedLevel)
    {

        //پیدا کردن شماره ولول انتخاب شده
        for (int i = 0; i < AllLevels.Length; i++)
            if (selectedLevel == AllLevels[i])
            {
                SelectedLevel = i;
                Debug.Log(SelectedLevel);
                break;
            }


        if (LastUnlockedLevel >= SelectedLevel)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Marslvl1");
        }

        PlayerPrefs.SetInt("Currentlvl", SelectedLevel);

    }
}

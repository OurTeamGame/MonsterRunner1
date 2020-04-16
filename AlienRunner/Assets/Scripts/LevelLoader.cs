using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject[] AllLevels = new GameObject[5];
    int Currentlvl;

    // Start is called before the first frame update
    void Start()
    {
        Currentlvl = PlayerPrefs.GetInt("Currentlvl", 0);
        //اگر لول وجود داشت همه لول ها را غیر از لول انتخاب شدخ غیر فعال کن        
        if (Currentlvl < AllLevels.Length)
              AllLevels[Currentlvl].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadNextLevel()
    {
        Currentlvl++;
        PlayerPrefs.SetInt("Currentlvl", Currentlvl);
        Time.timeScale = 1f;
        //لود دوباره همین صحنه
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float StartY, DeadY;
    public GameObject GameOverPanel, BestLable, NewRecordLable,player;
    public bool IsImmoral;
    // Start is called before the first frame update
    void Start()
    {
        StartY = transform.position.y; 
    }

    // Update is called once per frame
    void Update()
    {
        //اگر بازیکن به اندازه خاصی سقوط کند بمیرد
        if (StartY - transform.position.y > DeadY)
            Death();
    }

    void OnTriggerEnter2D(Collider2D Hit)
    {

       //اگر کارکتر به تله ای بخورد بمیرد
        if (Hit.gameObject.CompareTag("Trap") && !IsImmoral)
            Death();

    }
    public void Death() 
    {
        GameOverPanel.SetActive(true);
        //اگز کاربر رکوردش را زده بود رکود جدید ثبت شود 
        if (PlayerPrefs.GetInt("BestScore", 0) < GetComponent<UIManager>().Score)
        {
            PlayerPrefs.SetInt("BestScore", GetComponent<UIManager>().Score);
            NewRecordLable.SetActive(true);
        }
        BestLable.GetComponent<Text>().text = "Best: " + PlayerPrefs.GetInt("BestScore", 0);
        player.GetComponent<Animator>().SetInteger("State", 2);
        player.GetComponent<UIManager>().enabled = false;
        player.GetComponent<PlayerControler>().enabled = false;
    }
    public void resetScene() 
    {
      
        SceneManager.LoadScene("SampleScene");
        GameOverPanel.SetActive(false);
    }
}

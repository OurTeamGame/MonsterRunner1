﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float StartY, DeadY;
    public GameObject GameOverPanel, BestLable, NewRecordLable,player, NoEnergy;
       public bool IsImmoral,IsDead;
       int EnergyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartY = transform.position.y;
        EnergyCount = PlayerPrefs.GetInt("EnergyCount", 5);
    }

    // Update is called once per frame
    void Update()
    {
       ///اگر بازیکن به اندازه خاصی سقوط کند بمیرد
        //if (StartY - transform.position.y > DeadY)
           // Death();



    }

    void OnTriggerEnter2D(Collider2D Hit)
    {

        //اگر کارکتر در گودال بیفتد بمیرد
        if (Hit.gameObject.CompareTag("gap"))
        {
            player.GetComponent<Rigidbody2D>().simulated =false;
            Death();
        }
        //اگر کارکتر به تله ای بخورد بمیرد
        if (Hit.gameObject.CompareTag("Trap") && !IsImmoral)
            Death();
        if (Hit.gameObject.CompareTag("Trap")&& IsImmoral)
        {
            Hit.gameObject.GetComponent<Animator>().SetInteger("State", 2);
            Destroy(Hit.gameObject, 0.75f);
        }

    }
    public void Death() 
    {
        if (!IsDead)
        {
            GameOverPanel.SetActive(true);
            //اگز کاربر رکوردش را زده بود رکود جدید ثبت شود 
            if (PlayerPrefs.GetInt("BestScore", 0) < GetComponent<UIManager>().Score)
            {
                PlayerPrefs.SetInt("BestScore", GetComponent<UIManager>().Score);
                NewRecordLable.SetActive(true);
            }
            BestLable.GetComponent<Text>().text = "Best: " + PlayerPrefs.GetInt("BestScore", 0);


            //از بین بردن حرکت بازیکن
            player.GetComponent<Animator>().SetInteger("State", 2);
            player.GetComponent<Animator>().speed = 1;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            player.GetComponent<UIManager>().enabled = false;
            player.GetComponent<PlayerControler>().enabled = false;


            IsDead = true;
        }
    }
    public void resetScene() 
    {

        //کم کردن از تعداد جان های بازیکن و ذخیره انها اگ جانی باقی مانده بود
        if (EnergyCount > 0)
        {
            EnergyCount--;
            PlayerPrefs.SetInt("EnergyCount", EnergyCount);
            Time.timeScale = 1f;
            //لود دوباره همین صحنه
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameOverPanel.SetActive(false);
        }
        else
        {
            EnergyCount = 0;
            NoEnergy.SetActive(true);
        }
      
        
    }
}

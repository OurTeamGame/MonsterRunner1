using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float StartY, DeadY;
    public GameObject GameOverPanel, BestLable, NewRecordLable,player;
       public bool IsImmoral,IsDead;
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
        if (Hit.gameObject.CompareTag("Trap")&& IsImmoral)
        {
            Hit.gameObject.GetComponent<Animator>().SetInteger("State", 2);
            Destroy(Hit.gameObject, 0.75f);
        }

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
        player.GetComponent<Animator>().speed = 1;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        player.GetComponent<UIManager>().enabled = false;
        player.GetComponent<PlayerControler>().enabled = false;


        IsDead = true;
    }
    public void resetScene() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
        GameOverPanel.SetActive(false);
    }
}

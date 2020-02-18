using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCoin : MonoBehaviour
{
    public GameObject powerup;
    public float PowerUpTimer;
    public int Rand = -1;
     public float EffectTimer, tempspeed;
    GameObject Player;
    public GameObject Player2;
    public bool IsTimeout = true;//ایا زمان افکت تمام شده است؟
    //public AudioClip[] PowerupSounds = new AudioClip[2];
    //AudioSource audio;
    void Start()
    {

        //audio = Sphere.GetComponent<AudioSource>();
    }
    void Update()
    {

        //اگر ایتم گرفته شد تایمر شروع کند
        if (!IsTimeout)
            EffectTimer += Time.deltaTime;

        //وقتی تایمر تمام شد غیر فعال شود
        if (EffectTimer > PowerUpTimer)
        {
            RemoveEffect();
            IsTimeout = true;
            EffectTimer = 0f;

        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("RandomCoin") && Rand == -1)
        {
            Debug.Log("RandomCoin");
            //audio.clip = PowerupSounds[0];
            //audio.Play();    
            SetEffect();
            Destroy(other.gameObject);


        }

    }
    //تنظیم تاثیر سکه
    void SetEffect()
    {

        powerup.SetActive(true);
        Rand = Random.Range(0, 6);
        switch (Rand)
        {
            //سرعت بیشتر
            case 0:
                {

                    powerup.GetComponent<Text>().text = "SpeedUp";
                }
                break;
            //پرش زیاد
            case 1:
                {
                   
                    powerup.GetComponent<Text>().text = "SuperJump";
                }
                break;
            //حالت روح
            case 2:
                {
                 
                    powerup.GetComponent<Text>().text = "Immorality";
                }
                break;

            //یخزدن
            case 3:
                {
                   
                    powerup.GetComponent<Text>().text = "Freeze";
                }
                break;
            //ناتوانی در پرش
            case 4:
                {
              
                    powerup.GetComponent<Text>().text = "NoJump";
                }
                break;
            //مرگ
            case 5:
                {
                 
                    powerup.GetComponent<Text>().text = "Death!";
                }
                break;


        }
    }
    //خنثی کردن تاثیر سکه
    void RemoveEffect()
    {
        powerup.SetActive(false);
        Debug.Log(Rand + "Disble");

        switch (Rand)
        {
            //سرعت بیشتر
            case 0:
                this.GetComponent<PlayerControler>().Tempspeed = GetComponent<PlayerControler>().Tempspeed / 1.5f;
                this.GetComponent<PlayerControler>().speed = GetComponent<PlayerControler>().speed / 1.5f;
                break;
            //پرش زیاد
            case 1:
                this.GetComponent<PlayerControler>().JumpForce = GetComponent<PlayerControler>().JumpForce / 1.3f;
                break;
            //حالت روح
            case 2:
                this.GetComponent<GameOver>().IsImmoral = false;
                break;

            case 3:
                {
                    Player2.GetComponent<PlayerControler>().enabled = true;
                    Player2.GetComponent<Rigidbody2D>().simulated = true;
                    Player2.GetComponent<Animator>().speed = 1;
                }
                break;

            case 4:
                Player2.GetComponent<PlayerControler>().JumpForce = 700f;
                break;

        }
        Rand = -1;
    }

    public void ActiveEffect()
    {
        tempspeed = this.GetComponent<PlayerControler>().Tempspeed;
        if (IsTimeout && Rand != -1)
        {
            switch (Rand)
            {
                //سرعت بیشتر
                case 0:
                    {
                        this.GetComponent<PlayerControler>().Tempspeed = GetComponent<PlayerControler>().Tempspeed * 1.5f;
                        this.GetComponent<PlayerControler>().speed = GetComponent<PlayerControler>().speed * 1.5f;
                    }
                    break;
                //پرش زیاد
                case 1:
                    this.GetComponent<PlayerControler>().JumpForce = GetComponent<PlayerControler>().JumpForce * 1.3f;


                    break;
                //حالت روح
                case 2:
                    this.GetComponent<GameOver>().IsImmoral = true;

                    break;

                //یخزدن
                case 3:
                    {
                        Player2.GetComponent<PlayerControler>().enabled = false;
                        Player2.GetComponent<Rigidbody2D>().simulated = false;
                        Player2.GetComponent<Animator>().speed = 0;
                    }
                    break;
                //ناتوانی در پرش
                case 4:
                    Player2.GetComponent<PlayerControler>().JumpForce = 0;
                    break;
                //مرگ
                case 5:
                    Player2.GetComponent<GameOver>().Death();
                    break;

            }
                IsTimeout = false;
        }

    }
}

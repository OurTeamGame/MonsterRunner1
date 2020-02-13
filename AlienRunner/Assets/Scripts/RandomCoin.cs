using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCoin : MonoBehaviour
{
    public GameObject powerup;
    public float PowerUpTimer;
    public int Rand;
    float EffectTimer,tempspeed;
    GameObject Player;
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

        if (other.gameObject.CompareTag("RandomCoin") && IsTimeout)
        {
            Debug.Log("RandomCoin");
            //audio.clip = PowerupSounds[0];
            //audio.Play();
            AcitveEffect();
            IsTimeout = false;
            Destroy(other.gameObject);


        }
      
    }
    //تنظیم تاثیر سکه
    void AcitveEffect()
    {
        powerup.SetActive(true);
        Rand = Random.Range(0,6);
        tempspeed = this.GetComponent<PlayerControler>().TempMaxspeed;
        switch (Rand) 
        {
                //سرعت بیشتر
            case 0:
                {
                    this.GetComponent<PlayerControler>().TempMaxspeed = GetComponent<PlayerControler>().TempMaxspeed * 1.5f;
                    powerup.GetComponent<Text>().text = "SpeedUp";
                }
                break;
                //پرش زیاد
            case 1:
                {
                    this.GetComponent<PlayerControler>().JumpForce = GetComponent<PlayerControler>().JumpForce * 1.3f;
                    powerup.GetComponent<Text>().text = "SuperJump";
                }
                break;
                //حالت روح
            case 2:
                {
                    this.GetComponent<GameOver>().IsImmoral = true;
                    powerup.GetComponent<Text>().text = "Immorality";
                }
                break;

            //یخزدن
            case 3:
                {
                    this.GetComponent<PlayerControler>().TempMaxspeed = 0;
                    powerup.GetComponent<Text>().text = "Freeze";
                }
                break;
            //ناتوانی در پرش
            case 4:
                {
                    this.GetComponent<PlayerControler>().JumpForce = 0;
                    powerup.GetComponent<Text>().text = "NoJump";
                }
                break;
            //مرگ
            case 5:
                {
                    this.GetComponent<GameOver>().Death();
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
                this.GetComponent<PlayerControler>().TempMaxspeed = GetComponent<PlayerControler>().TempMaxspeed / 1.5f;
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
                this.GetComponent<PlayerControler>().TempMaxspeed = tempspeed;
                break;
           
            case 4:
                this.GetComponent<PlayerControler>().JumpForce = 700f;
                break;

        }
    }
}

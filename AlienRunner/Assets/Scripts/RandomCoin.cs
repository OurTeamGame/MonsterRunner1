using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCoin : MonoBehaviour
{
    public GameObject TimerCircle;
    public float EffectTime;//زمان فعال بودن افکت
    public float PowerUpLifeTime;//مدت زمان که اگر از افکت استفاده نشود از بین می رود
    public int Rand = -1;
    public GameObject PowerUpImage;//عکس افکت
    public Sprite[] Images = new Sprite [6];
    public float EffectTimer, PowerupLifeTimer, tempspeed;
    GameObject Player;
    public GameObject Player2;
    public bool IsTaken = false, IsActiveted=false;//ایا زمان افکت تمام شده است؟
    //public AudioClip[] PowerupSounds = new AudioClip[2];
    //AudioSource audio;
    void Start()
    {

        //audio = Sphere.GetComponent<AudioSource>();
    }
    void Update()
    {
        //اگر قدرت فعال شد تایمر شروع کند
        if (IsTaken)
        {
            PowerupLifeTimer += Time.deltaTime;
            TimerCircle.GetComponent<Image>().fillAmount = 1 - (PowerupLifeTimer / PowerUpLifeTime);
        }

        //اگر قدرت فعال شد تایمر شروع کند
        if (IsActiveted)
        {
            EffectTimer += Time.deltaTime;
            TimerCircle.GetComponent<Image>().fillAmount = 1 - (EffectTimer / EffectTime);
        }

        //وقتی تایمر تمام شد غیر فعال شود
        if (EffectTimer > EffectTime || PowerupLifeTimer > PowerUpLifeTime)
        {
            
            RemoveEffect();
          

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
        IsTaken = true;
        Rand = Random.Range(0, 6);
        PowerUpImage.SetActive(true);
        PowerUpImage.GetComponent<Image>().sprite = Images[Rand];
        //SpeedUp = 0,SuperJump = 1,Immorality=2,Freeze=3,No jump = 4;Death = 5;
       
    }
    //خنثی کردن تاثیر سکه
    void RemoveEffect()
    {
        TimerCircle.GetComponent<Image>().fillAmount = 0;
        PowerUpImage.SetActive(false);
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
        IsTaken = false;
        IsActiveted = false;
        EffectTimer = 0f;
        PowerupLifeTimer = 0f;
    }

    public void ActiveEffect()
    {
        tempspeed = this.GetComponent<PlayerControler>().Tempspeed;
        if (IsTaken && Rand != -1)
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
                IsActiveted = true;
                IsTaken = false;
        }

    }
}

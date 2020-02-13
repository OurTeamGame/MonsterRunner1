using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    public int State_Run = 0, State_Jump = 1, State_Death = 2;//وضعیت های کاراکتر
    public int CurrentState;//وضعیتی که در ان قرارا دارد
    Animator Player_Animator;
	public float Speed,JumpForce,Maxspeed,SpeedControlStr;
	public float TempMaxspeed,TempSpeed;
	public bool Grounded;
	Rigidbody2D Rd2D;
	// Update is called once per frame
	void Start()
	{
        Player_Animator = this.GetComponent<Animator>();
		Rd2D = this.GetComponent<Rigidbody2D> ();
		TempMaxspeed = Maxspeed;
		TempSpeed = Speed;
	}
	void Update () 
	{
        //تنظیم متعییر انمیتور
        Player_Animator.SetInteger("State", CurrentState);
		Rd2D.velocity = new Vector2 (Maxspeed, Rd2D.velocity.y);
		Jump ();
		SpeedContorl ();
	}

    void OnTriggerEnter2D(Collider2D Hit)
    {
        Debug.Log(Hit.gameObject.tag);
        if (Hit.gameObject.CompareTag("Ground"))
        {
            CurrentState = State_Run;
            Grounded = true;
        }
        if (Hit.gameObject.CompareTag("Wall"))
            Flap();
    }
	void SpeedContorl()
	{
		if (Input.GetKey (KeyCode.D)) 
		{
			Maxspeed = TempMaxspeed * ((SpeedControlStr + 100) / 100);
            Player_Animator.speed = (SpeedControlStr + 100) / 100;


		}
		
		if (Input.GetKey (KeyCode.A)) 
		{
			Maxspeed = TempMaxspeed * ((-SpeedControlStr + 100) / 100);
            Player_Animator.speed = (-SpeedControlStr + 100) / 100;
		}
		
		if (Input.GetKeyUp (KeyCode.D)) 
		{
			Maxspeed = TempMaxspeed;
		
		}
		if (Input.GetKeyUp (KeyCode.A)) 
		{
			Maxspeed = TempMaxspeed;

		}

		
	}
	void Jump()
	{	if (Input.GetKey (KeyCode.Space) && Grounded)
		{
			Rd2D.AddForce (Vector2.up * JumpForce);
            CurrentState = State_Jump;
            Grounded = false;
			
		}
	}
    //این تابع جهت حرکت دشمن را با منفی کردن سرعت و چرخاندن ان به اندازه 180درجه ان را برمی گرداند
    void Flap()
    {
        TempMaxspeed = -TempMaxspeed;
        Maxspeed = -Maxspeed;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }


}

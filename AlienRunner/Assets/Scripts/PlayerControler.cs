using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    public int State_Run = 0, State_Jump = 1, State_Death = 2;//وضعیت های کاراکتر
    public int CurrentState;//وضعیتی که در ان قرارا دارد
    Animator Player_Animator;
	public float JumpForce,speed,SpeedControlStr;
	public float Tempspeed,TempJumpForce;

    public bool Grounded;
	Rigidbody2D Rd2D;
	// Update is called once per frame
	void Start()
	{
        Player_Animator = this.GetComponent<Animator>();
		Rd2D = this.GetComponent<Rigidbody2D> ();
		Tempspeed = speed;
        TempJumpForce = JumpForce;

    }
	void Update () 
	{
        //تنظیم متعییر انمیتور
        Player_Animator.SetInteger("State", CurrentState);
		Rd2D.velocity = new Vector2 (speed, Rd2D.velocity.y);
		Jump (JumpForce);
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

        if (Hit.gameObject.CompareTag("JumpBooster"))
        {
            Rd2D.AddForce(Vector2.up * JumpForce * 2);
            CurrentState = State_Jump;
            Grounded = false;
        }
        
    }
	void SpeedContorl()
	{
		if (Input.GetKey (KeyCode.D)) 
		{
			speed = Tempspeed * ((SpeedControlStr + 100) / 100);
            Player_Animator.speed = (SpeedControlStr + 100) / 100;


		}
		
		if (Input.GetKey (KeyCode.A)) 
		{
			speed = Tempspeed * ((-SpeedControlStr + 100) / 100);
            Player_Animator.speed = (-SpeedControlStr + 100) / 100;
		}
		
		if (Input.GetKeyUp (KeyCode.D)) 
		{
			speed = Tempspeed;
		
		}
		if (Input.GetKeyUp (KeyCode.A)) 
		{
			speed = Tempspeed;

		}

		
	}
	void Jump(float jumpForce)
	{	if (Input.GetKey (KeyCode.Space) && Grounded)
		{
			Rd2D.AddForce (Vector2.up * jumpForce);
            CurrentState = State_Jump;
            Grounded = false;
			
		}
	}
    //این تابع جهت حرکت دشمن را با منفی کردن سرعت و چرخاندن ان به اندازه 180درجه ان را برمی گرداند
    void Flap()
    {
        Tempspeed = -Tempspeed;
        speed = -speed;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }


}

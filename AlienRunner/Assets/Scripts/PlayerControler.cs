using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

	public float Speed,JumpForce,Maxspeed,SpeedControlStr;
	float TempMaxspeed,TempSpeed;
	public bool Grounded;
	Rigidbody2D Rd2D;
	// Update is called once per frame
	void Start()
	{
		Rd2D = this.GetComponent<Rigidbody2D> ();
		TempMaxspeed = Maxspeed;
		TempSpeed = Speed;
	}
	void Update () 
	{
		Rd2D.velocity = new Vector2 (Maxspeed, Rd2D.velocity.y);
		Jump ();
		SpeedContorl ();
	}

    void OnTriggerEnter2D(Collider2D Hit)
    {
        Debug.Log(Hit.gameObject.tag);
        if (Hit.gameObject.CompareTag("Ground"))
            Grounded = true;
        if (Hit.gameObject.CompareTag("Wall"))
        {
            TempMaxspeed = -TempMaxspeed;
            Maxspeed = -Maxspeed;
        }
    }
	void SpeedContorl()
	{
		if (Input.GetKey (KeyCode.D)) 
		{
			Maxspeed = TempMaxspeed * ((SpeedControlStr + 100) / 100);
			this.GetComponent<MeshRenderer> ().material.color = Color.yellow;
		}
		
		if (Input.GetKey (KeyCode.A)) 
		{
			Maxspeed = TempMaxspeed * ((-SpeedControlStr + 100) / 100);
			this.GetComponent<MeshRenderer> ().material.color = Color.blue;
		}
		
		if (Input.GetKeyUp (KeyCode.D)) 
		{
			Maxspeed = TempMaxspeed;
			this.GetComponent<MeshRenderer> ().material.color = Color.black;
		}
		if (Input.GetKeyUp (KeyCode.A)) 
		{
			Maxspeed = TempMaxspeed;
			this.GetComponent<MeshRenderer> ().material.color = Color.black;
		}

		
	}
	void Jump()
	{	if (Input.GetKey (KeyCode.Space) && Grounded)
		{
			Rd2D.AddForce (Vector2.up * JumpForce);
            Grounded = false;
			
		}
	}


}

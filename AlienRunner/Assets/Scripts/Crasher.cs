using UnityEngine;
using System.Collections;

public class Crasher : MonoBehaviour 
{

	public char line; 
	public float Rmax, Rmin, MoveSpeed, RestTime;
	float Timer , temp1;
	void Awake()
	{
		temp1 = MoveSpeed;

	}	
	 //یکی از مولفه های ایکس  یا ایگرگ یا زد را می گیرد تا حهت رفت برگشت شی را مشخص کند و
	//شی حرکت می کند و هر گاه که به ماکسیمم یا مینیمم رنجش برسد وارد شرط می شود و
	//سرعت تا پایان زمان استراحت صفر می شود و بعد در جهت مخالف شروع به حرکت می کند/
	void FixedUpdate () 
	{  	
			ActiveCrasher ();
	}


	void ActiveCrasher()
	{
		// شی انتخاب شده به سمت های چپ و راست حرکت رفت و برگشتی می کند
		if (line == 'X') 
		{

            transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
			if (transform.position.x >= Rmax || transform.position.x <= Rmin) 
			{
				MoveSpeed = 0;
				Timer += Time.deltaTime;
				if (Timer >= RestTime) 
				{
					Timer = 0;
					temp1 = -temp1;
					MoveSpeed = temp1;
				}
			}
		}
		// شی انتخاب شده به سمت های بالا و پایین حرکت رفت و برگشتی می کند
		if (line == 'Y')
        {
            
            transform.position -= Vector3.up * MoveSpeed * Time.deltaTime;
			if (transform.position.y >= Rmax || transform.position.y <= Rmin) 
			{
                Debug.Log(transform.position.y + ">=" + Rmax + "||" + transform.position.y + "<=" + Rmin);
				MoveSpeed = 0;
				Timer += Time.deltaTime;
				if (Timer >= RestTime) 
				{
					Timer = 0;
					temp1 = -temp1;
					MoveSpeed = temp1;
                    
				}
			}
		}
		// شی انتخاب شده به سمت های جلو و عقب حرکت رفت و برگشتی می کند
		if (line == 'Z')
		{
			transform.position += Vector3.forward * MoveSpeed* Time.deltaTime;
			if (transform.position.z >= Rmax || transform.position.z <= Rmin) 
			{
				MoveSpeed = 0;
				Timer += Time.deltaTime;
				if (Timer >= RestTime) 
				{
					Timer = 0;
					temp1 = -temp1;
					MoveSpeed = temp1;
				}


			}

		}
	}
		
}


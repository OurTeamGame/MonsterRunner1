using UnityEngine;
using System.Collections;

public class Crasher : MonoBehaviour 
{
 
	public float Rang, MoveSpeed, RestTime;
	public float Timer , temp1;
    public float TempX,TempY,TempZ;
    public bool X, Y, Z;
	void Start()
	{
		temp1 = MoveSpeed;
        TempX = transform.position.x;
        TempY = transform.position.y;
        TempZ = transform.position.z;
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
		if (X) 
		{

            transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
            if (transform.position.x >= TempX + Rang || transform.position.x <= TempX + -Rang) 
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
		if (Y)
        {
            
            transform.position -= Vector3.up * MoveSpeed * Time.deltaTime;
            Debug.Log(transform.position.y >= TempY + Rang || transform.position.y <= TempY - Rang);

            if (transform.position.y >= TempY + Rang || transform.position.y <= TempY - Rang) 
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
		// شی انتخاب شده به سمت های جلو و عقب حرکت رفت و برگشتی می کند
		if (Z)
		{
			transform.position += Vector3.forward * MoveSpeed* Time.deltaTime;
            if (transform.position.z >= TempZ + Rang || transform.position.z <= TempZ + -Rang) 
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


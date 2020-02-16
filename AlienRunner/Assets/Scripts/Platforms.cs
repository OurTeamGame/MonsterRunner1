using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : Crasher
{  
    public GameObject target; 
    public bool Destroyable, Sensetive;
    public float DestroyTime, SensetiveTime;
    GameObject Player;
    bool IsStick;//ایا بازیکن روی پلتفرم چسبیده است یا نه   
    float Timer1, Time2;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        temp1 = MoveSpeed;
        TempX = transform.position.x;
        TempY = transform.position.y;
        TempZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(temp1);
        if (Destroyable)
            Timer1 += Time.deltaTime;
        if (Timer1 > DestroyTime)
            Destroy(target);

        if (IsStick) 
        {
            //Player.transform.position = transform.position+ new Vector3(0,2,0);

        }

        if (Input.GetKey(KeyCode.Space))
        {
            IsStick = false;

        }

    }
    void OnTriggerEnter2D(Collider2D Hit)
    {
        if (Hit.gameObject.CompareTag("Player"))
        {
            IsStick = true;
       
        }

    }
}

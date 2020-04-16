using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemControl : MonoBehaviour
{
    GameObject Player;
    public int State_Idle= 0, State_Atk = 1;//وضعیت های کاراکتر
    public int CurrentState = 0;//وضعیتی که در ان قرارا دارد
    public float DistanseX,DistanseY,speed;
    Animator Golem_Animator;
    public bool IsSeen = false;//ایا بازیکن دیده شده است
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Golem_Animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(transform.position.x - Player.transform.position.x) < DistanseX && Mathf.Abs(transform.position.y - Player.transform.position.y) < DistanseY)
            IsSeen = true;

        if (IsSeen)
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
            if (Mathf.Abs(speed / 10) > 1) 
            Golem_Animator.speed = Mathf.Abs(speed / 10);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemControl : MonoBehaviour
{
    GameObject Player;
    public int State_Idle= 0, State_Atk = 1;//وضعیت های کاراکتر
    public int CurrentState = 0;//وضعیتی که در ان قرارا دارد
    public float Distanse;
    Animator Golem_Animator;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Golem_Animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x - Player.transform.position.x < Distanse)
            CurrentState = State_Atk;

        else
            CurrentState = State_Idle;


        Golem_Animator.SetInteger("State", CurrentState);
    }
}

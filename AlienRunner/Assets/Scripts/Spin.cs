using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
    public GameObject Target;
    public float Speed;
    public bool DirX, DirY, DirZ;
	// Use this for initialization
	void Start () {
        int Rand = Random.Range(0, 2);
        if (Rand == 0)
           Speed = Speed;
        else
           Speed = -Speed;
	
	}
	
	// Update is called once per frame
	void Update () {
        if(DirX)
	        Target.GetComponent<Transform>().Rotate(Speed * Time.deltaTime,0f,0f);
        if (DirY)
            Target.GetComponent<Transform>().Rotate(0f, Speed * Time.deltaTime, 0f);
        if (DirZ)
            Target.GetComponent<Transform>().Rotate( 0f, 0f,Speed * Time.deltaTime);
	}
}

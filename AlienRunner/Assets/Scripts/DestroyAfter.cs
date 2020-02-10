using UnityEngine;
using System.Collections;

public class DestroyAfter : MonoBehaviour {
	public GameObject target;
    public float distanse;

    GameObject Player;
	float Timer ;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (target.transform.position.x < Player.transform.position.x - distanse)
			Destroy (target);
	
	}
}

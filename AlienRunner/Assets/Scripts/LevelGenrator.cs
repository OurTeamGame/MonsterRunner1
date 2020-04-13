using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenrator : MonoBehaviour
{
    public GameObject flag;
    public GameObject Parentlevel;//لولی که پرچم در ان است
    public GameObject[] Levels = new GameObject [6];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D Hit)
    {
      
        Debug.Log(Hit.gameObject.tag);
        if (Hit.gameObject.CompareTag("Player"))
        {
            GameObject newlevel = Parentlevel;
            
            while(newlevel == Parentlevel)
                newlevel = Levels[Random.Range(0, 6)];

            Instantiate(newlevel, transform.position + new Vector3(1f, -0.5f, 0f), Quaternion.identity);
            Destroy(flag);
            Destroy(Parentlevel, 2f);

        }



    }
}

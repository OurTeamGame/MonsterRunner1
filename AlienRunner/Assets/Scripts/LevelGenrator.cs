using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenrator : MonoBehaviour
{
    public GameObject flag;
    public GameObject[] Levels = new GameObject [5];
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
            Destroy(flag);
            Instantiate(Levels[Random.Range(0, 5)], transform.position + new Vector3(1f, -0.5f, 0f), Quaternion.identity);
           
        }



    }
}

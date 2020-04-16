using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenrator : MonoBehaviour
{
    public GameObject flag, LevelComplite;
    public GameObject Parentlevel;//لولی که پرچم در ان است
    public GameObject[] Levels = new GameObject [7];
    GameObject player;
    public bool Level;//تبدیل پرچم به حالت مرحله ای
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
            if (!Level)
            {
                GameObject newlevel = Parentlevel;

                while (newlevel == Parentlevel)
                    newlevel = Levels[Random.Range(0, 7)];

                Instantiate(newlevel, transform.position + new Vector3(1f, -0.5f, 0f), Quaternion.identity);
                Destroy(flag);
                Destroy(Parentlevel, 1f);
            }
            else
            { 
                LevelComplite.SetActive(true);
                player.GetComponent<Animator>().speed = 0;
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                player.GetComponent<Rigidbody2D>().simulated = false;
                player.GetComponent<UIManager>().enabled = false;
                player.GetComponent<PlayerControler>().enabled = false;
                player.GetComponent<GameOver>().enabled = false;
                Destroy(flag);

                //اگر لول که تمام شده اخرین ولول باز شده بود لول بعدی باز شود
                if (PlayerPrefs.GetInt("Currentlvl", 0) == PlayerPrefs.GetInt("LastUnlock", 0))
                    PlayerPrefs.SetInt("LastUnlock", PlayerPrefs.GetInt("LastUnlock", 0) + 1);

                Debug.Log("Currentlul:" + PlayerPrefs.GetInt("Currentlvl", 0) + "LastUnlocked:" + PlayerPrefs.GetInt("LastUnlock", 0));

            }
        }
        

    }


 }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOnBackPressed : MonoBehaviour
{
    public GameObject Panel, Hideable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Panel.activeSelf)
        {
            Panel.SetActive(false);
            Hideable.SetActive(true);
        }
            
    }
}

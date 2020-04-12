using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GotoScenes : MonoBehaviour {
    public string SceneName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ChanceScene() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneName);
    }
}

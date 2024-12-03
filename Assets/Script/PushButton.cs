using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PushButton : MonoBehaviour
{
    public string retryScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void OnRetryButton()
    {
        if(!string.IsNullOrEmpty(Health.lastScene)){
            Time.timeScale = 1;
            SceneManager.LoadScene(Health.lastScene, LoadSceneMode.Single);

            Collider[] colliders = FindObjectsOfType<Collider>();
            foreach(var collider in colliders){
                collider.enabled = true;
            }
            Physics.SyncTransforms();

            }
    }

    public void OnReturnButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScreen");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

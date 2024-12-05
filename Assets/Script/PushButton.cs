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

    public void StartGame(){//When press button on main screen
        Time.timeScale = 1;
        SceneManager.LoadScene("NarrativeScene");
    }

    public void OnRetryButton() //When press button on retry button
    {
        if(!string.IsNullOrEmpty(Health.lastScene)){ //Checks health to reset it
            Time.timeScale = 1;//Resets the time
            SceneManager.LoadScene(Health.lastScene, LoadSceneMode.Single);//Fully reloads everything in scene

            Collider[] colliders = FindObjectsOfType<Collider>();//For colliders set them to true (enemies re-enabled)
            foreach(var collider in colliders){
                collider.enabled = true;
            }
            Physics.SyncTransforms();
            }
    }

    public void OnReturnButton() //Main menu button
    {
        Time.timeScale = 1; //Reset time
        SceneManager.LoadScene("TitleScreen"); //Back to title screen

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

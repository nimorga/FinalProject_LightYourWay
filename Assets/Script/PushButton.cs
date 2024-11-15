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
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void OnRetryButton()
    {
        if(!string.IsNullOrEmpty(Health.lastScene)){
            SceneManager.LoadScene(Health.lastScene, LoadSceneMode.Single);
            }
    }

    public void OnReturnButton()
    {
        SceneManager.LoadScene("TitleScreen");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PushButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnRetryButton()
    {
        SceneManager.LoadScene("Level1");

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

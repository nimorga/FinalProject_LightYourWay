using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NarrativeHandler : MonoBehaviour
{
    public List<GameObject> gameObjects; //List of GameObjects
    public List<Text> textLines; //List of text
    public float fadeDuration = 1f; 
    public float delayBetweenObjects = 1f; 

    private void Start()
    {
        DisableGameObjectsAndText(); //Disable all GameObjects and text on start
        StartCoroutine(FadeInGameObjectsAndText());
    }

    private void Update()
    {
        //Start game if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Level1"); 
        }
    }

    private void DisableGameObjectsAndText(){
        //Disable all GameObjects and set text invisible
        foreach (var obj in gameObjects){
            obj.SetActive(false);
        }
        foreach (var text in textLines){
            Color color = text.color;
            color.a = 0f; // 0 = invisible
            text.color = color;
        }
    }

    private IEnumerator FadeInGameObjectsAndText()
    {
        for (int i = 0; i < gameObjects.Count; i++) //Each GameObject in the list
        {
            //Enable both to true
            gameObjects[i].SetActive(true);
            textLines[i].gameObject.SetActive(true);

            //Fade in text and display gameobject
            Color textColor = textLines[i].color;
            textColor.a = 0f;
            textLines[i].color = textColor;

            float timeElapsed = 0f;
            while (timeElapsed < fadeDuration) //Make sure the time lines up
            {
                timeElapsed += Time.deltaTime;
                float alphaValue = Mathf.Clamp01(timeElapsed / fadeDuration);

                textColor.a = alphaValue;
                textLines[i].color = textColor;

                yield return null;
            }

            yield return new WaitForSeconds(delayBetweenObjects); //Delay between GameObjects
        }
    }
}


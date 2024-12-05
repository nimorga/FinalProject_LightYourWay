using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Include for using legacy Text component
using UnityEngine.SceneManagement;

public class NarrativeHandler : MonoBehaviour
{
    public List<SpriteRenderer> sprites; //Sprite list :P
    public List<Text> textLines; //List of of text
    public float fadeDuration = 1f; 
    public float delayBetweenSprites = 1f; 

    private void Start()
    {
        DisableSpritesAndText(); //All pics and text disable on start
        StartCoroutine(FadeInSpritesAndText());
    }

    private void Update()
    {
        //If spacebar pressed start game
        if (Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene("Level1"); 
        }
    }

    private void DisableSpritesAndText()
    {
        //Invisible sprites using sprite render
        foreach (var spriteRenderer in sprites){
            spriteRenderer.enabled = false;
        }
        foreach (var text in textLines){
            Color color = text.color;
            color.a = 0f; //0 = invisible
            text.color = color;
        }
    }

    private IEnumerator FadeInSpritesAndText()
    {
        for (int i = 0; i < sprites.Count; i++) //For each sprite in list
        {
            //Enable sprite and text before display
            sprites[i].enabled = true;
            textLines[i].gameObject.SetActive(true);

            //Fade them in
            Color spriteColor = sprites[i].color;
            spriteColor.a = 0f;
            sprites[i].color = spriteColor;
            Color textColor = textLines[i].color;
            textColor.a = 0f;
            textLines[i].color = textColor;

            float timeElapsed = 0f;
            while (timeElapsed < fadeDuration) //make sure they excute on time
            {
                timeElapsed += Time.deltaTime;
                float alphaValue = Mathf.Clamp01(timeElapsed / fadeDuration);

                spriteColor.a = alphaValue;
                sprites[i].color = spriteColor;
                textColor.a = alphaValue;
                textLines[i].color = textColor;
                yield return null;
            }
            yield return new WaitForSeconds(delayBetweenSprites);//Delay sprite by 1 sec
        }
    }
}


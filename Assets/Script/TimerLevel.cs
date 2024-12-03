using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerLevel : MonoBehaviour
{
    public Text surviveText;
    public Slider timerBar;
    private float displayTime = 5f; // Display directions
    private float countDownTime = 60f; // Survive for a min
    private bool isFadingText = false;

    // Start is called before the first frame update
    void Start()
    {
        countDownTime = 60f;
        // To show text and fadeout text
        surviveText.gameObject.SetActive(true);
        surviveText.canvasRenderer.SetAlpha(1.0f);

        if(timerBar != null){
            timerBar.maxValue = countDownTime;
            timerBar.value = countDownTime;
        }

        StartCoroutine(FadeOutText());
    }

    // Update is called once per frame
    void Update()
    {
        countDownTime -= Time.deltaTime;

        //Update the bar on screen 
        if(timerBar != null){
            timerBar.value = countDownTime;
        }

        if (countDownTime <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    private IEnumerator FadeOutText()
    {
        yield return new WaitForSeconds(displayTime);

        float fadeDuration = 1f;
        float fadeSpeed = 1.0f / fadeDuration;
        float progress = 0;

        while (progress < 1.0f)
        {
            surviveText.canvasRenderer.SetAlpha(1.0f - progress);
            progress += fadeSpeed * Time.deltaTime;
            yield return null;
        }

        surviveText.gameObject.SetActive(false);
    }
}

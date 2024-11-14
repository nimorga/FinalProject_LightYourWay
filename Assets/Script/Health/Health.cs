using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}

    [Header ("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    private void Awake() 
    {
        currentHealth = startingHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage) 
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // player hurt
            StartCoroutine(Invunerability());
        }
        else
        {
            // player dead
            StartCoroutine(Invunerability()); // this will be replaced by a game over screen most likely
            SceneManager.LoadScene("GameOver");
        }
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        //Invunerable duration
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}

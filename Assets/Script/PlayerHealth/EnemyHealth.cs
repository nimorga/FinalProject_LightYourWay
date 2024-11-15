using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    public float durationWHileRed;
    public Color damageColor = Color.red;
    private Color originalColor;
    private SpriteRenderer[] spriteRenderers;

    void Start()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        if (spriteRenderers.Length > 0)
        {
            originalColor = spriteRenderers[0].color;
        }
        else
        {
            Debug.LogError("No SpriteRenderer components found on this GameObject or its children.");
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (spriteRenderers.Length > 0)
        {
            StartCoroutine(ChangeColor());
        }

        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private IEnumerator ChangeColor()
    {
        foreach (var renderer in spriteRenderers)
        {
            renderer.color = damageColor;
        }

        yield return new WaitForSeconds(durationWHileRed);

        foreach (var renderer in spriteRenderers)
        {
            renderer.color = originalColor;
        }
    }
}

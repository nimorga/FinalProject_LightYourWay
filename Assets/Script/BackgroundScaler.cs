using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        //Get screen size
        float screenHeight = Camera.main.orthographicSize * 2.0f;
        float screenWidth = screenHeight / Screen.height * Screen.width;

        //Get sprite size
        Vector2 spriteSize = sr.sprite.bounds.size;
        
        //Scale sprite to fit the screen size
        transform.localScale = new Vector3(screenWidth / spriteSize.x, screenHeight / spriteSize.y, 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollower : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    public float restrictX;//Used to restrict the camera from going past this point left
    public float endLevelX = 90f;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        //X postion based on player
        float targetX = player.position.x + offset.x;
        targetX = Mathf.Max(targetX, restrictX);
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        
        if (player.position.x >= endLevelX){
            SceneManager.LoadScene("Level2");
        }
    }

}

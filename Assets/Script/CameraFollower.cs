using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollower : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    public float restrictX;//Used to restrict the camera from going past this point left
    public float endLevelX = 90f;//End point represented by castle green arch

    bool AllEnemiesDestroyed(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");//Get a num of how many enemies
        return enemies.Length -1 == 0;//Return true or false (-1 bc it is counting extra enemy)
    }

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
        //Debug.Log("Player X Position: " + player.position.x);
        
        if (player.position.x >= endLevelX && AllEnemiesDestroyed()){ //At end of level and all of enemies destoryed
                //Debug.Log("All enemies destroyed,Level 2");
                SceneManager.LoadScene("Level2");
        }
    }

}

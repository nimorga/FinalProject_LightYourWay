using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOffScreen : MonoBehaviour
{

    private Collider projectileCollider;
    void Start()
    {
        //Collider of Magic prefab
        projectileCollider = GetComponent<Collider>();
    }

    void OnBecameInvisible()
    {
        //Disable the prefab if not null if exit the screen
        if (projectileCollider != null)
        {
            projectileCollider.enabled = false;
        }

        gameObject.SetActive(false); //Deactivate the gameobject
    }
}

using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GameObject playerGameObject;
    [SerializeField] GameObject AnimationObject;

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CollisionEnd());
    }
    IEnumerator CollisionEnd()
    { 
        

playerGameObject.GetComponent<PlayerController>().enabled = false;
        AnimationObject.GetComponent<Animator>().Play("Knockback");
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(0);


    }
}



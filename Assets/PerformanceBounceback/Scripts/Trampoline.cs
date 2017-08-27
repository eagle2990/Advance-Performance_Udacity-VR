using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public ParticleSystem pSystem;
    public GameManager scoreScript;

    // Use this for initialization
    //void Start()
    //{
    //    if (scoreScript == null)
    //        scoreScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    //    if (pSystem == null)
    //        pSystem = GetComponentInChildren<ParticleSystem>();
    //}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Throwable"))
        {
            scoreScript.score++;
            pSystem.Play();
        }

    }
}

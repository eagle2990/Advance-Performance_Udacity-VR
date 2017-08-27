using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Throwable"))
        {
            GameObject other = collision.gameObject;
            other.SetActive(false);
            other.GetComponent<Rigidbody>().Sleep();
        }
    }
}
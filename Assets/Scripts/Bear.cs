using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
   


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Rock"))
        {
            gameObject.GetComponent<BearMovement>().speed = 0;
            GameManager.Instance.GameOver();
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.GetComponent<BearMovement>().speed = 0;
            GameManager.Instance.GameOver();
        }
    }
    int i = 0;
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("Chick"))
        {
            Debug.Log(i++);
            GameManager.Instance.chickenValue++;
            GameManager.Instance.chickSound.Play();
            Destroy(other.gameObject);
        }
        
        if(other.gameObject.CompareTag("pot"))
        {
            GameManager.Instance.potSound.Play();
            GameManager.Instance.pot = true;
            GameManager.Instance.time = 0;
            Debug.Log("pot");
            GameManager.Instance.SetTriggerRocks();
            GameManager.Instance.SetPotAnimationOnBear();
            Destroy(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    bool canMove;

    private GameObject activeBear;
    void Start()
    {
        activeBear = GameManager.Instance.activeBear;
    }

    // Update is called once per frame
    void Update()
    {
        GetDistance();
        Movement();
        
    }

    public void Movement()
    {
        if(canMove)
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void GetDistance()
    {
        if(Vector3.Distance(this.gameObject.transform.position, activeBear.transform.position) <= 150)
        {
            Debug.Log("Enemy active");
            canMove = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMovement : MonoBehaviour
{
   
    public float speed;

    Touch touch;

    void Start()
    {
        StartCoroutine(IncreaseSpeed());
    }

   
    void Update()
    {
       transform.Translate(Vector3.forward * GameManager.Instance.bearSpeed * Time.deltaTime);
        //float horizontal = Input.GetAxis("Horizontal");
        float horizontal = GameManager.Instance.joystick.Horizontal;

        /*Vector3 mousePos = GameManager.Instance.mainCam.ScreenToViewportPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + mousePos.z);*/

       /* if(Input.touchCount>0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                //transform.position = new Vector3(touch.deltaPosition.x * speed, transform.position.y, transform.position.x);
                transform.Translate(touch.deltaPosition.x * speed * Time.deltaTime, 0, 0);
            }


        }*/

        transform.Translate(horizontal * speed * Time.deltaTime, 0,0 );
      
    }

    public IEnumerator IncreaseSpeed()
    {
        while(true)
        {
            yield return new WaitForSeconds(3f);
            GameManager.Instance.IncreaseSpeed(3);
        }
       
    }

    
}

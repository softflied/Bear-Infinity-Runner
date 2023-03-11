using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private float PlatformValue;
    private GameObject PlatformObject;
    private GameObject CopyPlatformObject;
    GameObject copyPlatform;
    void Start()
    {
        PlatformValue = GameManager.Instance.platfromValue;
        PlatformObject = gameObject.transform.parent.gameObject;
        CopyPlatformObject = GameManager.Instance.platforms[Random.Range(0,GameManager.Instance.platforms.Length)];
    }

    void Update()
    {
       
    }

   

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Bear"))
        {
            
            copyPlatform = Instantiate(CopyPlatformObject, new Vector3(PlatformObject.transform.position.x 
                - PlatformValue, PlatformObject.transform.position.y, PlatformObject.transform.position.z), Quaternion.identity);

        /*    Destroy(GameManager.Instance.copyPlatforms[GameManager.Instance.platformIndex]);
            GameManager.Instance.copyPlatforms.Add(copyPlatform);
            GameManager.Instance.platformIndex++;*/

          //  PlatformObject.transform.position = new Vector3(PlatformObject.transform.position.x - PlatformValue, PlatformObject.transform.position.y, PlatformObject.transform.position.z);
        }

    }

    



}

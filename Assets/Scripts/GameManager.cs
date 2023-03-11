using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public GameObject[] platforms;
    public GameObject activePlatform;
    public GameObject gameOverPanel;
    public GameObject NormalbearBody,whiteBearBody,BlackBearBody,activeBearBody;
    public int activePlatformIndex;
    public Camera mainCam;

    private Animator controller;

    public BearMovement bear;

    public float bearSpeed;
    public bool isDead;
    public TextMeshProUGUI chickenValueText;
    public int chickenValue;
    public Joystick joystick;

    public GameObject touchAnim;
    public TextMeshProUGUI counterText;
    public int counter;
    public float platfromValue;


    public List<GameObject> copyPlatforms;
    public int platformIndex;


    public AdManager adManager;

    public int activeBearIndex;
    public GameObject normalBear, whiteBear, blackBear;

    [HideInInspector] public GameObject activeBear;


    [Header("SOUND")]
    public AudioSource backgroundSound;
    public AudioSource chickSound;
    public AudioSource gameOverSound;
    public AudioSource potSound;

    

    private void Awake()
    {


       
        backgroundSound.Play();
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        CreateBear();
        touchAnim.SetActive(true);
        for (int i = 0; i < platforms.Length; i++)
        {
            copyPlatforms.Add(platforms[i]);
        }

        platformIndex = 0;
        gameOverPanel.SetActive(false);
        chickenValue = 0;
        activePlatformIndex = 0;
        SetActivePlatform(0);
        StartCoroutine(LoadingGame());

       
    }

    void Update()
    {
        chickenValueText.text = chickenValue.ToString();

        if(bearSpeed<=10)
        {
            controller.SetBool("isWalk", true);
        }
        else
            controller.SetBool("isWalk", false);
    }

    public void CreateBear()
    {

        activeBearIndex = MenuManager.Instance.activeIndex;
        if (activeBearIndex == 0)
        {
            normalBear.SetActive(true);
            controller = normalBear.GetComponent<Animator>();
            activeBearBody = NormalbearBody;
            activeBear = normalBear;
        }

        if (activeBearIndex == 1)
        {
            whiteBear.SetActive(true);
            controller = whiteBear.GetComponent<Animator>();
            activeBearBody = whiteBearBody;
            activeBear = whiteBear;
        }

        if (activeBearIndex == 2)
        {
            blackBear.SetActive(true);
            controller = blackBear.GetComponent<Animator>();
            activeBearBody = BlackBearBody;
            activeBear = blackBear;
        }

    }

 

    public void SetActivePlatform(int index)
    {
        activePlatform = platforms[index];
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("ChickenValue", PlayerPrefs.GetInt("ChickenValue") + chickenValue); // butlarý kaydetme iþlemi


        backgroundSound.Pause();
        gameOverSound.Play();
        StartCoroutine(SetTrueGameOverPanel());
        Debug.Log("KAYBETTÝNÝZ");
        controller.SetBool("isDead", true);
        isDead = true;
        bearSpeed = 0;
        bear.speed = 0;

        
    }

    public void IncreaseSpeed(float speed)
    {
        if(bearSpeed<=30 && !isDead)
        bearSpeed += speed;
    }


  
    public IEnumerator LoadingGame()
    {
      //  bear.speed = 0;
        for (int i = 3; i >= 0; i--)
        {
            counterText.text = i.ToString();
            if (i == 0)
                counterText.text = "GO!";
            yield return new WaitForSeconds(1f);  
        }
        bear.speed = 15;
        counterText.gameObject.SetActive(false);
        touchAnim.SetActive(false);
        

    } 

    public void GoMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ReStart()
    {
        adManager.LoadInerstitialAd();
       
        SceneManager.LoadScene("Game");
    }

    public IEnumerator SetTrueGameOverPanel()
    {
        yield return new WaitForSeconds(1.5f);
        gameOverPanel.SetActive(true);
    }




    GameObject[] pots;
    public void SetTriggerRocks()
    {
        pots = GameObject.FindGameObjectsWithTag("Rock");

        foreach (var item in pots)
        {
            if(item.GetComponent<MeshCollider>()!=null)
            item.GetComponent<MeshCollider>().isTrigger = true;
        } 
        
      
    
    
    }

    bool Enabled = false;
   public bool pot= true;
    public void SetPotAnimationOnBear()
    {
        StartCoroutine(Anim());
        StartCoroutine (PotTime());
    }

    public IEnumerator Anim()
    {
        while(pot)
        {
            Enabled = !Enabled;
            yield return new WaitForSeconds(0.1f);
            activeBearBody.GetComponent<SkinnedMeshRenderer>().enabled = Enabled;
        }
        activeBearBody.GetComponent<SkinnedMeshRenderer>().enabled = true;

    }

   public int time=0;
    
    public IEnumerator PotTime()
    {
        while(pot)
        {
            yield return new WaitForSeconds(1);
            time++;
            if (time >= 5)
            {
                pot = false;
                time = 0;

                foreach (var item in pots)
                {
                    if(item !=null)
                        if (item.GetComponent<MeshCollider>() != null)
                            item.GetComponent<MeshCollider>().isTrigger = false;
                }
               
            }
        }
       
           
        
      
    }



}

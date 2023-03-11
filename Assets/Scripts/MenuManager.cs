using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }
    public Animator controller;
    public TextMeshProUGUI loadingText;
    public TextMeshProUGUI chickenValue;


    public GameObject normalBear, whiteBear, blackBear;
    public GameObject activeBear;
    public GameObject whiteBearRedPanel, blackBearRedPanel;
    public GameObject whiteBearPanel,blackBearPanel;
    public int activeIndex;

    public AudioSource bearSound;

    

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        if (!PlayerPrefs.HasKey("ChickenValue"))
            PlayerPrefs.SetInt("ChickenValue", 0);

        SetBears();
    }

    private void Start()
    {
       controller = activeBear.GetComponent<Animator>();
        chickenValue.text = PlayerPrefs.GetInt("ChickenValue").ToString();
    }
    public void OpenGame()
    {
        bearSound.Play();
        StartCoroutine(Loading());
    }

    public IEnumerator Loading()
    {
        controller.SetBool("isBuff", true);
        loadingText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Game");
    }

    public void SetBears()
    {

        if (PlayerPrefs.GetInt("ChickenValue") >= 5000 && PlayerPrefs.GetInt("ChickenValue") < 10000)
        {
            whiteBearRedPanel.SetActive(false);
            whiteBearPanel.SetActive(true);
            activeIndex = 1;
            activeBear = whiteBear;
           // controller = whiteBear.GetComponent<Animator>();
        }

        else if (PlayerPrefs.GetInt("ChickenValue") >= 10000)
        {
            blackBearRedPanel.SetActive(false);
            blackBearPanel.SetActive(true);
            whiteBearPanel.SetActive(true);
            whiteBearRedPanel.SetActive(false);

            activeIndex = 2;
            activeBear = blackBear;
           // controller = blackBear.GetComponent<Animator>();
        }
        else
        {
            activeBear = normalBear;
            activeIndex = 0;
           // controller = normalBear.GetComponent<Animator>();
        }
            
           
            
    }

  
}

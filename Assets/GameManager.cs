using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Audio;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //[SerializeField] GameObject inGameUI;

      [SerializeField] GameObject gameOverUI;
      [SerializeField] GameObject PauseUI; ///para pausar y quitar
      [SerializeField] GameObject WinUI;
      [SerializeField] GameObject inGameUI;
      [SerializeField] TextMeshProUGUI coinText;



      EventSystem eventSystem;


bool restart;

  bool gameOver; 
  bool isPaused;

bool finish= false;
  
    void Awake()
    {
        instance = this;
        
    }

   
    void Start()
    {

        eventSystem = EventSystem.current;

                inGameUI.SetActive(true);

        gameOverUI.SetActive(false);
        PauseUI.SetActive(false);
        WinUI.SetActive(false);

        gameOver = false;
       
    }

    
    void Update()
    {
       if(Input.GetButtonDown("Pause") || Input.GetKeyDown(KeyCode.Space) &&!gameOver)
       {
          if(isPaused)
          {
            ResumeGame();
          }
          else
          {
            PauseGame();
          }
       }


       if(Input.GetKeyDown(KeyCode.Space) && restart)

          RestartGame();
             


       
        if(Input.GetKeyDown(KeyCode.Space) && finish)
           {
                LoadNextLevel();

           }

           

       




    
    }




 public void PauseGame()
  {
    Time.timeScale = 0;
    isPaused = true;

    PauseUI.SetActive(true);
  }

 public  void ResumeGame()
  {
    Time.timeScale = 1;
    isPaused = false;

    PauseUI.SetActive(false);

  }

  public void Win()
    {
        finish = true;
        WinUI.SetActive(true);
    }



  public void LoadNextLevel()
  {
    // if(SceneManager.GetActiveScene().name == "Game")
    //   SceneManager.LoadScene("LVL2");
    // else if(SceneManager.GetActiveScene().name == "LVL2")
    //   SceneManager.LoadScene("LVL3");
    Time.timeScale = 1;

    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }



  public void Credits()
  {
    SceneManager.LoadScene("Credits");
  }


   public void GameOver()
   {
        gameOverUI.SetActive(true);
        gameOver = true;
           restart = true;

   }

  

    public void RestartGame()
    {

      SceneManager.LoadScene("Game");
    }


   public void Restart()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);

   }

   public void BacktoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }


  public void CoinGrabbed(GameObject coin, int coinNum)
    {
     
        coin.GetComponent<CoinBehaviour>().OnGrabbed();

      
        coinText.text = coinNum.ToString();

        
        
    }




}

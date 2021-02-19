using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;
    

    #endregion

    public Dictionary<GameObject,BuffReceiver> receiverContainer;
    private bool isPaused = false;

    [SerializeField] private GameObject interface_;
    [SerializeField] private GameObject pauseMenu; 
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private Animator animator;

    void Awake() 
    {
        Instance = this;    

        receiverContainer = new Dictionary<GameObject, BuffReceiver>();

        animator.SetTrigger("Loading");
    }


    void Update() 
    {
       if(Input.GetKeyDown(KeyCode.Escape) && Player.Instance != null)
       {
           Pause();
       }   
       if(Player.Instance == null)
       {
           interface_.SetActive(false);
           gameOverMenu.SetActive(true);
       }
    }

    public void Pause()
    {
       if(isPaused)
       {
           Time.timeScale = 1;
           isPaused = false;
           interface_.SetActive(true);
           pauseMenu.SetActive(false);
       }
       else
       {
           Time.timeScale = 0;
           isPaused = true;
           interface_.SetActive(false);
           pauseMenu.SetActive(true);
       }
        
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

      public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}

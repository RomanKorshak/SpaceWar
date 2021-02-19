using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   
   [SerializeField] private Animator animator;
   [SerializeField] private GameObject image;

    public void Play()
    {
        StartCoroutine(LoadScene());
        
    }

    public void Quit()
    {
        Application.Quit();
    }

  

    IEnumerator LoadScene()
    {
        image.SetActive(true);
        yield return new WaitForSeconds(5f);
        animator.SetTrigger("Loading");
        SceneManager.LoadScene(1);
        yield break;
    }

}

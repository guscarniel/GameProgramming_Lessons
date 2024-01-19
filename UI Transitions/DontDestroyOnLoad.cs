using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject fadeCanvas;

    void Start()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(fadeCanvas);
    }

    //load the specified scene below
    private void OnEnable()
    {    
        SceneManager.sceneLoaded += LevelToBeLoaded;
    }

    //here goes trigger, timer, etc
    void LevelToBeLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Nova cena carregada!");
        //FadeLevel();
        //SceneManager.LoadScene(2);
    }

    //active animator trigger
    public void FadeLevel()
    {
        animator.SetTrigger("FadeLevel");
        //Invoke(levelName, 3f);
    }

}

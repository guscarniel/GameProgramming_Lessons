using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SceneFadeManager : MonoBehaviour
{
    //this is a singleton, a globally accessible class
    public static SceneFadeManager instance;

    [SerializeField] private Image fadeOutImage;
    [Range(0.1f, 10f), SerializeField] private float fadeOutSpeed = 5f;
    [Range(0.1f, 10f), SerializeField] private float fadeInSpeed = 5f;

    [SerializeField] private Color fadeOutStartColor;

    //to check if the fade is happening
    public bool isFadingOut { get; private set; }
    public bool isFadingIn { get; private set; }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        //alpha starts as transparent
        fadeOutStartColor.a = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadingOut)
        {
            if (fadeOutImage.color.a < 1f)
            {
                fadeOutStartColor.a += Time.deltaTime * fadeOutSpeed;
                fadeOutImage.color = fadeOutStartColor;
            }
            else
            {
                isFadingOut = false;
            }
        }

        if (isFadingIn)
        {
            if (fadeOutImage.color.a > 0f)
            {
                fadeOutStartColor.a += Time.deltaTime * fadeInSpeed;
                fadeOutImage.color = fadeOutStartColor;
            }
            else
            {
                isFadingIn = false;
            }
        }
    }

    public void StartFadeOut()
    {
        fadeOutImage.color = fadeOutStartColor;
        isFadingOut = true;
    }

    public void StartFadeIn()
    {
        //making sure the fade in only gets called when alpha is totally opaque
        if (fadeOutImage.color.a >= 1f)
        {
            fadeOutImage.color = fadeOutStartColor;
            isFadingIn = true;
        }

    }

}

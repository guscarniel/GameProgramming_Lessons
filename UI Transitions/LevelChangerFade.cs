using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChangerFade : MonoBehaviour
{
    public Animator animator;
    
    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }
}

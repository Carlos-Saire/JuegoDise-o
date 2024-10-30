using UnityEngine;
using System;
using System.Data;
public class AjusteController : MonoBehaviour
{
    static public AjusteController instance;

    [SerializeField] private Animator animator;

    private void Awake()
    {
        if(instance == null && instance != this)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OpenAjustes()
    {
        animator.SetTrigger("Open");

    }
    public void CloseAjustes()
    {
        animator.SetTrigger("Close");
    }
}

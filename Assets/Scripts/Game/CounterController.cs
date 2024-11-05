using UnityEngine;
using TMPro;
using System;
public class CounterController : MonoBehaviour
{
    private float time=20;
    static public event Action eventGameOver;
    private TMP_Text text;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void ActiveEventGameOver()
    {
        print("Se llamo al evento");
        eventGameOver?.Invoke();
    }
    private void Update()
    {
        time -= Time.deltaTime;
        text.text = "" + (int)time;
        if (time<=0)
        {
            print("Termino el timepo");
            ActiveEventGameOver();
        }
    }
}

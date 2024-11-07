using UnityEngine;
using TMPro;
using System;
public class CounterController : MonoBehaviour
{
    [SerializeField]private float time=20;
    static public event Action<float> eventGameOver;
    private TMP_Text text;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }
    private void ActiveEventGameOver()
    {
        eventGameOver?.Invoke(time);
    }
    private void Update()
    {
        time -= Time.deltaTime;
        text.text = "" + (int)time;
        ActiveEventGameOver();
    }
}

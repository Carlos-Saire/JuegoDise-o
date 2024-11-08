using UnityEngine;
using TMPro;
using System;

public class CounterController : MonoBehaviour
{
    [SerializeField] private float time = 20;
    public static event Action<float> eventGameOver;
    private TMP_Text text;
    private bool gameOverTriggered = false;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        time -= Time.deltaTime;
        text.text = ((int)time).ToString();

        eventGameOver?.Invoke(time);

        if (time <= 0 && !gameOverTriggered)
        {
            gameOverTriggered = true;
            time = 0; 
        }
    }
    private void IncrementTime(float time)
    {
        this.time += time;
    }
    private void OnEnable()
    {
        PlayerController.eventTime += IncrementTime;
    }

    private void OnDisable()
    {
        PlayerController.eventTime -= IncrementTime;
    }
}

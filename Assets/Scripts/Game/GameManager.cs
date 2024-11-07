using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PositionTable PositionTable;
    [SerializeField] private AudioSource audioSource;
    private void GameOver(float time)
    {
        if (time <= 10)
        {
            audioSource.pitch = 2.0f;
        }
    }
    private void OnEnable()
    {
        CounterController.eventGameOver += GameOver;
    }
    private void OnDisable()
    {
        CounterController.eventGameOver -= GameOver;

    }
}

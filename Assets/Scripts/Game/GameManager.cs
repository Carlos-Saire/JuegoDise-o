using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PositionTable PositionTable;
    private void GameOver()
    {
        PositionTable.AddNewScore(5);
        SceneManager.LoadScene("Win");
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

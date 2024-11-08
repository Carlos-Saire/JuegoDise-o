using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PositionTable PositionTable;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator animator;
    private float point;
    [SerializeField] private bool booltime;
    private bool gameOverTriggered = false;  

    private void GameOver(float time)
    {
        if (gameOverTriggered) return;

        booltime = time <= 10;

        if (time <= 0)
        {
            gameOverTriggered = true;  
            PositionTable.AddNewScore(point);  
            SceneManager.LoadScene("Win");    
        }
    }

    private void Start()
    {
        TImeGame(1);
        booltime = false;
    }

    private void Update()
    {
        audioSource.pitch += booltime ? 0.2f * Time.deltaTime : -0.2f * Time.deltaTime;
        audioSource.pitch = math.clamp(audioSource.pitch, 1, 2);
    }

    private void IncrementPoint(float point)
    {
        this.point += point;
    }

    private void OnEnable()
    {
        CounterController.eventGameOver += GameOver;
        FrutasController.eventPoint += IncrementPoint;
    }

    private void OnDisable()
    {
        CounterController.eventGameOver -= GameOver;
        FrutasController.eventPoint -= IncrementPoint;
        gameOverTriggered = false; 
    }

    public void OpenAjustes()
    {
        animator.SetTrigger("Open");
        TImeGame(0);
    }

    public void CloseAjustes()
    {
        animator.SetTrigger("Close");
        TImeGame(1);
    }

    public void OpenOpciones()
    {
        AjusteController.instance.OpenAjustes();
    }

    public void VolverAlmenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void TImeGame(float time)
    {
        Time.timeScale = time;
    }
}

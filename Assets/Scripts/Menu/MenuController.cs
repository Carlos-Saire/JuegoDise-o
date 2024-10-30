using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] private Button Jugar;
    [SerializeField] private Button Cerrar;
    private void Awake()
    {
        Jugar.onClick.AddListener(OnclickJugar);
        Cerrar.onClick.AddListener(OnclickCerar);
    }
    private void OnclickJugar()
    {
        SceneManager.LoadScene("Game");
    }
    private void OnclickCerar()
    {
        Debug.Log("Saliste");
        Application.Quit();
    }

}

using UnityEngine;
using TMPro;

public class PointController : MonoBehaviour
{
    private TMP_Text text;
    private float point;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }
    private void Start()
    {
        PrintPoint(0);
    }
    private void PrintPoint(float point)
    {
        this.point += point;
        text.text ="Point: "+ this.point;
    }
    private void OnEnable()
    {
        FrutasController.eventPoint += PrintPoint;
    }
    private void OnDisable()
    {
        FrutasController.eventPoint -= PrintPoint;
    }
}

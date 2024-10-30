using UnityEngine;
using UnityEngine.UI;
using System;
public class ButtonPoint : MonoBehaviour
{
    public static event Action<float> eventpoint;
    private Button mybutton;
    [SerializeField] private float point;

    bool confirms;
    private void Awake()
    {
        mybutton = GetComponent<Button>();
        mybutton.onClick.AddListener(ActiveEventPoint);
    }
    private void ActiveEventPoint()
    {
        eventpoint?.Invoke(point);
    }
}

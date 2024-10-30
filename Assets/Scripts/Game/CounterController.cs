using UnityEngine;
using TMPro;
public class CounterController : MonoBehaviour
{
    private TMP_Text tMP_Text;
    [SerializeField] private float Point;
    private void MostarPuntos()
    {
        tMP_Text.text = "" + Point;
    }
}

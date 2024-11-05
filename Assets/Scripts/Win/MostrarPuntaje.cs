using TMPro;
using UnityEngine;
public class MostrarPuntaje : MonoBehaviour
{
    [SerializeField] private TMP_Text[] textos;
    [SerializeField] private PositionTable positionTable;
    private void Start()
    {
        int numberOfScores = Mathf.Min(textos.Length, positionTable.highScores.Count);

        for (int i = 0; i < numberOfScores; i++)
        {
            textos[i].text = (i + 1) + " : " + positionTable.highScores[i];
        }
        for (int i = numberOfScores; i < textos.Length; i++)
        {
            textos[i].text = (i + 1) + " :";
        }
    }
}
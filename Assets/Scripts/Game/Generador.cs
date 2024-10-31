using UnityEngine;
using System.Collections;
public class Generador : MonoBehaviour
{
    [Header("ObjetosBuenos")]
    [SerializeField] private GameObject[] ObjectBuenos;
    [SerializeField] private float timeGeneratorBuenos;
    [SerializeField] private float TimeMinBuenos;

    [Header("ObjetosMalos")]
    [SerializeField] private GameObject[] ObjectMalos;
    [SerializeField] private float timeGeneratorMalos;
    [SerializeField] private float TimeMinEnemigos;

    [Header("Limites spauneo")]
    [SerializeField] private float xmin;
    [SerializeField] private float xMax;
    private void Start()
    {
        GeneradorObjectMalos();
        GeneradorObjectBuenos();
    }
    private void GeneradorObjectMalos()
    {
        float randon = Random.Range(xmin, xMax);
        int randonObjectos = Random.Range(0, ObjectMalos.Length);
        Vector2 newPosition = new Vector2(randon, transform.position.y);
        Instantiate(ObjectMalos[randonObjectos], transform.position, transform.rotation);
        StartCoroutine(TimeGenerarEnemigos());
    }
    private void GeneradorObjectBuenos()
    {
        float randon = Random.Range(xmin, xMax);
        int randonObjectos = Random.Range(0, ObjectMalos.Length);
        Vector2 newPosition = new Vector2(randon, transform.position.y);
        Instantiate(ObjectBuenos[randonObjectos], transform.position, transform.rotation);
        StartCoroutine(TimeGenerarBuenos());
    }
    private IEnumerator TimeGenerarEnemigos()
    {
        yield return new WaitForSeconds(timeGeneratorMalos);
        if (TimeMinEnemigos <= timeGeneratorMalos)
        {
            --timeGeneratorMalos;
        }
        GeneradorObjectMalos();
    }
    private IEnumerator TimeGenerarBuenos()
    {
        yield return new WaitForSeconds(timeGeneratorBuenos);
        if (TimeMinBuenos <= timeGeneratorBuenos)
        {
            --timeGeneratorMalos;
        }
        GeneradorObjectBuenos();
    }
}

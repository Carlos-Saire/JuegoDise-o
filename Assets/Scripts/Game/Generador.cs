using UnityEngine;
using System.Collections;
using static FrutasController;
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
        GeneradorObjectBuenos();
        GeneradorObjectMalos();
    }
    private void GeneradorObjectMalos()
    {
        float randon = Random.Range(xmin, xMax);
        int randonObjectos = Random.Range(0, ObjectMalos.Length);
        Vector2 newPosition = new Vector2(randon, transform.position.y);
        GameObject go=  Instantiate(ObjectMalos[randonObjectos], newPosition, transform.rotation);
        FrutasController frutasController = go.GetComponent<FrutasController>();

        FruitType randomFruitType = FruitType.Chocolate;

        frutasController.SetFruitSprite(randomFruitType);
        StartCoroutine(TimeGenerarEnemigos());
    }
    private void GeneradorObjectBuenos()
    {
        float randon = Random.Range(xmin, xMax);
        int randonObjectos = Random.Range(0, ObjectBuenos.Length);
        Vector2 newPosition = new Vector2(randon, transform.position.y);

        GameObject go = Instantiate(ObjectBuenos[randonObjectos], newPosition, transform.rotation);
        FrutasController frutasController = go.GetComponent<FrutasController>();

        FruitType randomFruitType;

        int probability = Random.Range(0, 100);
        if (probability < 30) 
        {
            randomFruitType = (Random.value > 0.5f) ? FruitType.Velocity : FruitType.Time;
        }
        else
        {
            do
            {
                randomFruitType = (FruitType)Random.Range(0, System.Enum.GetValues(typeof(FruitType)).Length);
            } while (randomFruitType == FruitType.Chocolate || randomFruitType == FruitType.Velocity || randomFruitType == FruitType.Time);
        }

        frutasController.SetFruitSprite(randomFruitType);
        StartCoroutine(TimeGenerarBuenos());
    }
    private IEnumerator TimeGenerarEnemigos()
    {
        yield return new WaitForSeconds(timeGeneratorMalos);
        if (TimeMinEnemigos < timeGeneratorMalos)
        {
            --timeGeneratorMalos;
        }
        GeneradorObjectMalos();
    }
    private IEnumerator TimeGenerarBuenos()
    {
        yield return new WaitForSeconds(timeGeneratorBuenos);
        if (TimeMinBuenos < timeGeneratorBuenos)
        {
            --timeGeneratorBuenos;
        }
        GeneradorObjectBuenos();
    }
}

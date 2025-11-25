using UnityEngine;

public class crearEnemics : MonoBehaviour
{
    private const float LIMIT_ESQUERRA = -7f;
    private const float LIMIT_DRET = 7f;
    private const float LIMIT_INFERIOR = -1f;
    private const float LIMIT_SUPERIOR = 7f;
    private const float LIMIT_POSTERIOR = 90f;
    public GameObject prefabBlocEnemic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("GenerarEnemics", 0.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void GenerarEnemics()
    {
        GameObject enemic = Instantiate(prefabBlocEnemic);
        enemic.transform.position = new Vector3(
            Random.RandomRange(LIMIT_ESQUERRA, LIMIT_DRET),
             Random.RandomRange(LIMIT_INFERIOR, LIMIT_SUPERIOR),
            LIMIT_POSTERIOR

        );
    }

}

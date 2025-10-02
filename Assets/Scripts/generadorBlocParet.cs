using UnityEngine;

public class generadorBlocParet : MonoBehaviour
{
    private const float LIMIT_ESQUERRA = -7f;
    private const float LIMIT_DRET = 7f;
    private const float LIMIT_INFERIOR = -1f;
    private const float LIMIT_SUPERIOR = 7f;
    private const float LIMIT_POSTERIOR = 90f;

    public GameObject prefabBlocParet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // prarm1: funcio que es cridara repetidament
        // param2: Des de que s'obra l'escena, quant tarda a conmençar-se a cridar
        //param3: una vegada ja es crida, cada quant es torna a cridar
        InvokeRepeating("GenerarBlocsParets", 0.5f,1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void GenerarBlocsParets()
    {
        GameObject paretInferiorEsquerra = Instantiate(prefabBlocParet);
        paretInferiorEsquerra.transform.position = new Vector3(
            LIMIT_ESQUERRA,
            LIMIT_INFERIOR,
            LIMIT_POSTERIOR
        );
        GameObject paretInferiorDreta = Instantiate(prefabBlocParet);
        paretInferiorDreta.transform.position = new Vector3(
            LIMIT_DRET,
            LIMIT_INFERIOR,
            LIMIT_POSTERIOR
        );
        GameObject paretSuperiorrDreta = Instantiate(prefabBlocParet);
        paretSuperiorrDreta.transform.position = new Vector3(
            LIMIT_DRET,
            LIMIT_SUPERIOR,
            LIMIT_POSTERIOR
        );
        GameObject paretSuperiorEsquerra = Instantiate(prefabBlocParet);
        paretSuperiorEsquerra.transform.position = new Vector3(
            LIMIT_ESQUERRA,
            LIMIT_SUPERIOR,
            LIMIT_POSTERIOR
        );
}
}

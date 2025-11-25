using UnityEngine;

public class generarBala : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float vel = 30f;
    private const float LIMIT_Z_POSITIU = 30f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
           transform.position.x,
           transform.position.y,
           transform.position.z + vel * Time.deltaTime
       );
        //mirem si sur te la pantalla(camera)
        if (transform.position.z > LIMIT_Z_POSITIU)
        {
            Destroy(gameObject);
        }
    }
}

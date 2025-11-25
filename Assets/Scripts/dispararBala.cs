using UnityEngine;

public class dispararBala : MonoBehaviour
{
     public GameObject prefabBlocBala;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("prefabBlocBala", 0.5f,1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(prefabBlocBala, transform.position,transform.rotation);
        }
    }
    private void GenerarBala()
    {
        
    }
}

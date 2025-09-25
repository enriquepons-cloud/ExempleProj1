using System;
using OpenCover.Framework.Model;
using UnityEngine;

public class jugador : MonoBehaviour
{
    public float vel = 10f;
    private Camera camera;
    public GameObject Jugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {


        MovimentNau();
    }
    void MovimentNau()
    {
        //control limits pantalla 
        Vector3 limitInferiorEsquerra = camera.ViewportToWorldPoint(new Vector2(0, 0));
        Vector3 limitSuperiorDret = camera.ViewportToWorldPoint(new Vector2(1, 1));

        //Moviment nau.
        float direccioHoritzontal = Input.GetAxisRaw("Horizontal");
        float direccioVertical = Input.GetAxisRaw("Vertical");
        Vector3 direccio = new Vector3(direccioHoritzontal, direccioVertical, 0).normalized;
        //Debug.Log("direccioHoritzontal=" + direccio);
        Vector3 nouDesplacament = new Vector3(
            vel * direccio.x * Time.deltaTime,
            vel * direccio.y * Time.deltaTime,
            vel * direccio.z * Time.deltaTime);
        //Debug.Log("Time. deltaTime= " + Time.deltaTime);

        //control dels limits de la pantalla
        //El metode math.Clamp, ens retorna el primer parametre.
        //  pero si aquest primer parametre, te un valor mes petit ue el segon parametre,
        //      retornara el egon parametre. i si te un valor mes gran que el tercer
        //          parametre ens retornara el tercer parametre
        nouDesplacament.x = Math.Clamp(nouDesplacament.x, limitInferiorEsquerra.x, limitSuperiorDret.x);
        nouDesplacament.y = Math.Clamp(nouDesplacament.y, limitInferiorEsquerra.y, limitSuperiorDret.y);
        
        //apliquem el vector desplaçament a l'objecte.
        transform.position += nouDesplacament;
    }
}

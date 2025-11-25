using System;
using JetBrains.Annotations;
using OpenCover.Framework.Model;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class jugador : MonoBehaviour
{
    public float vel = 10f;
    private int numEscuts = 3;
    private Camera camera;
    private Vector3 limitInferiorEsquerra;
    private Vector3 limitSuperiorDret;
   // public GameObject Jugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("UI")]
    public TextMeshProUGUI textEscuts;
    void Start()
    {
        camera = Camera.main;
        textEscuts.text = "vidas " + numEscuts.ToString();
        //trobem la distancia entre la camera i l'objecte que no volem que surti
        // del viewport en les z's.
        float distanciaZCameraNau = Mathf.Abs(transform.position.z - camera.transform.position.z);
        limitInferiorEsquerra = camera.ViewportToWorldPoint(new Vector3(0, 0, distanciaZCameraNau));
        limitSuperiorDret = camera.ViewportToWorldPoint(new Vector3(1, 1, distanciaZCameraNau));
    }

    // Update is called once per frame
    void Update()
    {


        MovimentNau();
        ControlLimitsPantalla();
    }
    void MovimentNau()
    {
        //Moviment nau.
        float direccioHoritzontal = Input.GetAxisRaw("Horizontal");
        float direccioVertical = Input.GetAxisRaw("Vertical");
        Vector3 direccio = new Vector3(direccioHoritzontal, direccioVertical, 0).normalized;
        //Debug.Log("direccioHoritzontal=" + direccio);
        Vector3 nouDesplacament = new Vector3(
            vel * direccio.x * Time.deltaTime,
            vel * direccio.y * Time.deltaTime,
            vel * direccio.z * Time.deltaTime);

        //apliquem el vector desplaçament a l'objecte.
        transform.position += nouDesplacament;
    }
    void ControlLimitsPantalla()
    {
        Vector3 novaPos = transform.position;

        //control dels limits de la pantalla
        //El metode math.Clamp, ens retorna el primer parametre.
        //  pero si aquest primer parametre, te un valor mes petit ue el segon parametre,
        //      retornara el egon parametre. i si te un valor mes gran que el tercer
        //          parametre ens retornara el tercer parametre.
        novaPos.x = Math.Clamp(novaPos.x, limitInferiorEsquerra.x, limitSuperiorDret.x);
        novaPos.y = Math.Clamp(novaPos.y, limitInferiorEsquerra.y, limitSuperiorDret.y);
        transform.position = novaPos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemic")
        {
            DecrementarVides(1);
            if (numEscuts == 0)
            {
                Destroy(gameObject);
            }

        }
    }
    public void IncrementarVides(int videsPerIncrementar)
    {
        numEscuts += videsPerIncrementar;
    }
    public void DecrementarVides(int videsPerVaixar)
    {
        numEscuts -= videsPerVaixar;
    }
    public void ActualitzarText()
    {
        
    }
}

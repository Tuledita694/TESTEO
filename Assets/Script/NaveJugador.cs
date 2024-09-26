using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJugador : MonoBehaviour
{
    private float _vel;



    private Vector2 minPantalla, maxPantalla;

    [SerializeField] private GameObject prefaProjectil;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8;
    
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        float midaMeitatImatgeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float midaMeitatImatgeY = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        //minPantalla.x = minPantalla.x + 0.75f;
        //minPantalla.x += 0.75f;
        minPantalla.x += midaMeitatImatgeX;
        maxPantalla.x -= midaMeitatImatgeX;
        minPantalla.y += midaMeitatImatgeY;
        maxPantalla.y -= midaMeitatImatgeY;

    }

    // Update is called once per frame
    void Update()
    {
        MovimentNau();
        DisparaProyectil();
    
    
    }

    private void DisparaProyectil()
    {
        
        if (Input.GetKeyDown("space"))
        {
            GameObject proyectil = Instantiate(prefaProjectil);
            proyectil.transform.position = transform.position;
        }


    }

    private void MovimentNau()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: "+direccioIndicadaX +" - Y "+ direccioIndicadaY);

        Vector2 direccioindicada = new Vector2(direccioIndicadaX, direccioIndicadaY);

        Vector2 novaPos = transform.position;
        novaPos = novaPos + direccioindicada * _vel * Time.deltaTime;

        novaPos.x = Mathf.Clamp(novaPos.x, minPantalla.x, maxPantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minPantalla.y, maxPantalla.y);

        transform.position = novaPos;
    }
}

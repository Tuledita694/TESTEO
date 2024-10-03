using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numero : MonoBehaviour
{
    private float _vel;

    public Sprite[] spritesNumerosPossibles = new Sprite[10];

    private int valorNumero;

    private Vector2 minPantalla;
    // Start is called before the first frame update
    void Start()
    {
        _vel = 5f;
        
        System.Random aleatori = new System.Random();
        valorNumero = aleatori.Next(0, 10);
        GetComponent<SpriteRenderer>().sprite = spritesNumerosPossibles [valorNumero];
        
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0,0));

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos = novaPos + new Vector2(0, -1) * _vel * Time.deltaTime;
        transform.position = novaPos;
    
        if (transform.position.y < minPantalla.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "ProyectilJugador" || objecteTocat.tag == "NauJugador")
        {
            Destroy(gameObject);
        }
    }
}

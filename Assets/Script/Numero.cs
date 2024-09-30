using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numero : MonoBehaviour
{
    private float _vel;

    private Vector2 minPantalla;
    // Start is called before the first frame update
    void Start()
    {
        _vel = 5f;
        
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
}

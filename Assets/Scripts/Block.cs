using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    //cached refenced
    Level level;

    private void Start()
    {
        // En ves de setear el balor al objeto , cada block buscara la instacia creada en el nivel de este objeto, asi mas manejable y rapido
        level = FindObjectOfType<Level>(); 
        level.CountBreakableBloks();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        /*Este audio se reproduce aparte del objeto, es un objeto individual se crea en el mapa y se destruye cuando termina el sonido de reproducir
                perfecto apra explociones de objetos que son destruidos*/
        /*Se coloca en la pocision de la camara  para que esta le eschuche mejor, aunque creoq ue se escuha desde alla tambien*/
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.BlockDestroyed();
        Destroy(gameObject);
        // Debug.Log(gameObject.name);
    }
}

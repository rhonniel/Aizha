using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float startForceX;
    [SerializeField] float startForceY;
    [SerializeField] AudioClip[] audioClips;


    Vector2 paddleToBallVector;
    bool hasStarted;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /* El metodo que lookea la bola con la barra no dejara que esta se lance al aejecutarse 
        milisegundos despues, por esto se coloca una condicion al igual tampoco se desea que 
        el jugador continua lanzando la bola mas de una vez */
        if (!hasStarted) 
        {
            LookBallToPaddle();
            LaunchOnMouseClick();
           
        }
     
        
        
    }

    private void LookBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnMouseClick()
    {
        // el indice cero significa el click izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            /*El componente Rigibody es capas de tomar un vector de velocidad, 
             * a nivel fisico es logico que sea un cuerpo rigido quien actue de esta forma y no el transform.
             al utilizar un cuerpo rigido el objeto funcionara bajo las leyes de la fisica, 
            este vector de velocidad es la fuerza que lo impulsa a esa direccion dada*/
            GetComponent<Rigidbody2D>().velocity = new Vector2(startForceX, startForceY);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
         
            audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
        }
    }



}

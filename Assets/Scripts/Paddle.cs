using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour  
{
    //al serializar el campo este se mantiene privado pero se muestra en la interfaz de unity
    [SerializeField] float unitsScreen = 16;
    [SerializeField] float minUnits = 0;
    [SerializeField] float maxUnits = 14;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //screen.width es 1080 en este caso, la cantidad de pixeles, al dividir su movimiento en estos y multiplicarlo por la unidad en que se distribuyen los pixeles en la pantalla
        // se obtiene un valor de unidad de 0 hasta al numero de las unidades de la oantalla (16) por ejemplo
        float move = Mathf.Clamp((Input.mousePosition.x / Screen.width * unitsScreen), minUnits, maxUnits);
        Vector2 paddlePos = new Vector2(move, transform.position.y);
        transform.position = paddlePos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosibleRotacion : MonoBehaviour
{
    public Vector3 rotacionFinal = new Vector3(0, 0, 0); // La rotaci�n final que deseas alcanzar
    public float duracionRotacion = 2.0f; // La duraci�n total de la rotaci�n en segundos

    private float tiempoPasado = 0f;

    void Update()
    {
        if (tiempoPasado < duracionRotacion)
        {
            // Calcular la fracci�n de rotaci�n completada
            float fraccionRotada = tiempoPasado / duracionRotacion;

            // Lerp para interpolar gradualmente entre la rotaci�n actual y la rotaci�n final
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotacionFinal), fraccionRotada);

            // Actualizar el tiempo pasado
            tiempoPasado += Time.deltaTime;
        }
    }
}



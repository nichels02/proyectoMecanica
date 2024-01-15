using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosibleRotacion : MonoBehaviour
{
    public Vector3 rotacionFinal = new Vector3(0, 0, 0); // La rotación final que deseas alcanzar
    public float duracionRotacion = 2.0f; // La duración total de la rotación en segundos

    private float tiempoPasado = 0f;

    void Update()
    {
        if (tiempoPasado < duracionRotacion)
        {
            // Calcular la fracción de rotación completada
            float fraccionRotada = tiempoPasado / duracionRotacion;

            // Lerp para interpolar gradualmente entre la rotación actual y la rotación final
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotacionFinal), fraccionRotada);

            // Actualizar el tiempo pasado
            tiempoPasado += Time.deltaTime;
        }
    }
}



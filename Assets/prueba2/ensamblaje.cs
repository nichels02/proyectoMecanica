using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ensamblaje : MonoBehaviour
{
    [SerializeField] List<ensamblaje> listaDeObjetosPadre = new List<ensamblaje>();
    [SerializeField] rotacion calcularRotacion;
    [SerializeField] bool estaLibre = false;
    [SerializeField] bool EstaSiendoSujetado = false;
    [SerializeField] bool YaEstaEnSuPosicion = false;
    [SerializeField] bool YaEstaEnRotacion = false;
    [SerializeField] bool YaEstaEnSuLugar = false;
    [SerializeField] bool fueSoltado = false;
    [SerializeField] Vector3 posicion;
    [SerializeField] float DiferenciaPosicion;
    [SerializeField] Vector3 rotacion;
    [SerializeField] Vector3 LaRotacion;
    [SerializeField] float DiferenciaRotacion;
    [SerializeField] Rigidbody MyRigidbody;
    [SerializeField] float velocity;
    [SerializeField] float velocityRotation;
 

    // Start is called before the first frame update
    void Start()
    {
        posicion.x = transform.position.x;
        posicion.y = transform.position.y;
        posicion.z = transform.position.z;

        rotacion = transform.rotation.eulerAngles;

        if (listaDeObjetosPadre.Count == 0)
        {
            estaLibre = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (EstaSiendoSujetado == false && YaEstaEnSuLugar == false && fueSoltado==true)
        {
            if (YaEstaEnSuPosicion==false && posicion[0] != transform.position.x || posicion[1] != transform.position.y || posicion[2] != transform.position.z)
            {
                if (MyRigidbody.velocity==Vector3.zero)
                {
                    MyRigidbody.velocity = new Vector3(posicion.x - transform.position.x, posicion.y - transform.position.y, posicion.z - transform.position.z).normalized * velocity;
                }
                
                DiferenciaPosicion =  Vector3.Distance(transform.position, posicion);
                if (DiferenciaPosicion < 0.01f)
                {
                    MyRigidbody.velocity = Vector3.zero;
                    transform.position = posicion;
                    YaEstaEnSuPosicion = true;
                }
            }



            if (YaEstaEnRotacion==false && rotacion.x != transform.rotation.x || rotacion.y != transform.rotation.y || rotacion.z != transform.rotation.z)
            {
                
                LaRotacion = transform.rotation.eulerAngles;
                LaRotacion = LaRotacion.normalized - rotacion.normalized;
                transform.rotation=calcularRotacion.rotar(LaRotacion*Time.deltaTime);
                print(LaRotacion);
                //transform.rotation = transform.rotation * LaRotacion;






                // Verifica la diferencia entre la dirección actual y la dirección objetivo
                float angleDifference = Vector3.Angle(transform.rotation.eulerAngles, rotacion);
                print(angleDifference);
                // Si la diferencia es menor que el umbral, establece la rotación objetivo directamente
                if (angleDifference < 0.001f)
                {
                    Quaternion miQuaternion = Quaternion.LookRotation(rotacion);

                    transform.rotation = miQuaternion;
                    YaEstaEnRotacion = true;
                }
            }
            else
            {
                YaEstaEnRotacion = true;
            }

            /*
            if(YaEstaEnRotacion==false && rotacion.x!=transform.rotation.x || rotacion.y != transform.rotation.y || rotacion.z != transform.rotation.z)
            {
                // Calcula la rotación necesaria para mirar hacia el vector objetivo
                Quaternion targetQuaternion = Quaternion.LookRotation(rotacion - transform.position);

                // Interpola suavemente hacia la rotación objetivo
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetQuaternion, velocityRotation);

                // Verifica la diferencia entre la rotación actual y la rotación objetivo
                DiferenciaRotacion = Quaternion.Angle(transform.rotation, targetQuaternion);

                // Si la diferencia es menor que el umbral, establece la rotación objetivo directamente
                if (DiferenciaRotacion < 0.001f)
                {
                    transform.rotation = targetQuaternion;
                    YaEstaEnRotacion = true;
                }
            }
            else
            {
                YaEstaEnRotacion = true;
            }
            */

            if (YaEstaEnRotacion==true && YaEstaEnSuPosicion == true)
            {
                YaEstaEnSuPosicion = false;
                YaEstaEnSuLugar = true;
                YaEstaEnRotacion = false;
            }

        }
        
    }
}

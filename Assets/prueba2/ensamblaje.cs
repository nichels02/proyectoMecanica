using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ensamblaje : MonoBehaviour
{
    [SerializeField] bool fueSoltado = false;
    Rigidbody MyRigidbody;

    #region posicion_y_rotacion
    [SerializeField] bool YaEstaEnSuPosicion = false;
    [SerializeField] bool YaEstaEnRotacion = false;
    [SerializeField] bool YaEstaEnSuLugar = false;


    #region Posicion
        Vector3 posicion;
        float DiferenciaPosicion;
        [SerializeField] float velocity;
    #endregion
    #region Rotacion
        Vector3 rotacion;
        float DiferenciaRotacion;
        float tiempoRotacion = 0f;
        float angleDifference = 0f;
        Quaternion rotacionInicial;
    #endregion


    
    #endregion


    



    private void Awake()
    {
        MyRigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }
    void Update()
    {
        if (YaEstaEnSuLugar == false && fueSoltado == true)
        {
            if (YaEstaEnSuPosicion == false && posicion[0] != transform.position.x || posicion[1] != transform.position.y || posicion[2] != transform.position.z)
            {
                if (MyRigidbody.velocity == Vector3.zero)
                {
                    MyRigidbody.velocity = new Vector3(posicion.x - transform.position.x, posicion.y - transform.position.y, posicion.z - transform.position.z).normalized * velocity;
                }

                DiferenciaPosicion = Vector3.Distance(transform.position, posicion);
                if (DiferenciaPosicion < 0.01f)
                {
                    MyRigidbody.velocity = Vector3.zero;
                    transform.position = posicion;
                    YaEstaEnSuPosicion = true;
                }
            }



            if (YaEstaEnRotacion == false && rotacion.x != transform.rotation.x || rotacion.y != transform.rotation.y || rotacion.z != transform.rotation.z)
            {

                if (tiempoRotacion == 0)
                {
                    rotacionInicial = transform.rotation;
                    angleDifference = Vector3.Distance(transform.eulerAngles, rotacion) / 5000;
                }

                float fraccionRotada = tiempoRotacion / angleDifference;

                transform.rotation = Quaternion.Lerp(rotacionInicial, Quaternion.Euler(rotacion), fraccionRotada);

                tiempoRotacion += Time.deltaTime;



            }
            else
            {
                tiempoRotacion = 0;
                YaEstaEnRotacion = true;
            }


            if (YaEstaEnRotacion == true && YaEstaEnSuPosicion == true)
            {
                YaEstaEnSuPosicion = false;
                YaEstaEnSuLugar = true;
                YaEstaEnRotacion = false;
            }

        }

    }





    public void YaEstaSuelto()
    {
        posicion.x = transform.position.x;
        posicion.y = transform.position.y;
        posicion.z = transform.position.z;

        rotacion = transform.rotation.eulerAngles;

        
    }
}

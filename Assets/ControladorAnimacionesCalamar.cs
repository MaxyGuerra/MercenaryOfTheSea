using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAnimacionesCalamar : MonoBehaviour
{
    private Animator Animacion;
    private bool opened = false;
    private float tiempo;
    public float Cadencia;

    // Start is called before the first frame update
    void Start()
    {
        Animacion = GetComponent<Animator>();
    }

    public void DoAnimacion()
    {
        Animacion.SetBool("Puerta1", opened);
        opened = !opened;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo + Time.deltaTime;

        if(Cadencia>=tiempo)
        { 
            DoAnimacion();
            tiempo=0;
        }
    }
}

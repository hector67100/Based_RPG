using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public int dao;
    public int nombre;
    public Sprite icono;
    public Acciones[] acciones= new Acciones[3];
    public Acciones basico= new Acciones{
    nombre = "basico",
    poder = 0,
    costo = 10,
    descripcion = "basico",
    minNivel = 0,
    animacion = "",
    };

    public void usarHabilidad(int habilidad)
    {
        int daoTotal = dao+acciones[habilidad].poder;
        UICombate.Instance.setUiJugadorTurno();
        Director.Instance.cambiarTexto("Seleccione Enemigo");
        Director.Instance.setaccionEnCola(acciones[habilidad]);
    }

}


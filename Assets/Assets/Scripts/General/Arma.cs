using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public int dao;
    public int nombre;
    public Sprite icono;
    public Habilidades[] habilidades= new Habilidades[3];

    public void usarHabilidad(int habilidad)
    {
        Debug.Log(habilidad);
        int daoTotal = dao+habilidades[habilidad].poder;
        Director.Instance.jugadorAtaque(daoTotal);
    }

}


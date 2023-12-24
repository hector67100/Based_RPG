using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public int vida;
    public int vidamaxima;
    public int nivel;
    public int basedao;

    // Start is called before the first frame update

    public void modificarVida(int cantidad)
    {
        vida += cantidad;
    }

    public void modificarVidaMaxima(int cantidad)
    {
        vidamaxima += cantidad; 
    }

    public void modificarNivel(int cantidad)
    {
        nivel += cantidad; 
    }

    public void modificarBasedao(int cantidad)
    {
        basedao += cantidad; 
    }
}

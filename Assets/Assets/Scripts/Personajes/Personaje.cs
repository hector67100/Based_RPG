using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public int vida;
    public int vidamaxima;
    public float energia;
    public float energiamaxima;
    public int nivel;
    public int basedao;
    public int index;
    public Arma arma;
    public Habilidades[] habilidades = {
        new Habilidades{
            nombre="Sigilo",
            rango=0
        },
        new Habilidades{
            nombre="Supervivencia",
            rango=0
        },
        new Habilidades{
            nombre="Investigacion",
            rango=0
        },
        new Habilidades{
            nombre="Atletismo",
            rango=0
        },
        new Habilidades{
            nombre="Acrobacia",
            rango=0
        },
        new Habilidades{
            nombre="Engañar",
            rango=0
        },
        new Habilidades{
            nombre="Comerciar",
            rango=0
        },
        new Habilidades{
            nombre="Diplomacia",
            rango=0
        },
        new Habilidades{
            nombre="Escuchar",
            rango=0
        },
        new Habilidades{
            nombre="Avistar",
            rango=0
        },
        new Habilidades{
            nombre="Distancia",
            rango=0
        },
        new Habilidades{
            nombre="Una Mano",
            rango=0
        },
        new Habilidades{
            nombre="Dos Manos",
            rango=0
        },
        new Habilidades{
            nombre="Armas de asta",
            rango=0
        },
        new Habilidades{
            nombre="Mano a mano",
            rango=0
        },
        new Habilidades{
            nombre="Exotica",
            rango=0
        },
    };

    // Start is called before the first frame update

    void Awake()
    {
        if(arma && (gameObject.tag == "Player"))
        {
            UIManager.Instance.ponerBontonesAcciones(arma);            
        }

    }

    public void modificarVida(int cantidad)
    {
        vida += cantidad;
        if(gameObject.tag == "Player")
        {
            UIManager.Instance.setSlidersValues(vida);
        }

        if(vida < 0)
        {
            Destroy(gameObject);

            if(gameObject.tag == "Player")
            {
                // Director.Instance.limpiarArray(Director.Instance.grupoJugadores,0);
            } 
            else
            {
                 Director.Instance.limpiarArrayEnemigos(index);
            }
        }
        
    }

    public void modificarEnergia(float cantidad)
    {
        energia += cantidad;
        if(gameObject.tag == "Player")
        {
            UIManager.Instance.setSlidersValues(0,energia);
        }
        
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

    [System.Serializable]
    public class Habilidades
    {
        public string nombre;
        public int rango;

        // Start is called before the first frame update
        public int getRango()
        {
            return rango;
        }

        public string getNombre()
        {
            return nombre;
        }

    }
}

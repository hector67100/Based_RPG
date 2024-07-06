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
    public int buffDao;
    public int buffArmadura;
    public int defensa;
    public bool defendiendo;
    public int porcentajefallo;
    public Arma arma;
    public Armadura armadura;
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
            nombre="Unamano",
            rango=0
        },
        new Habilidades{
            nombre="Dosmanos",
            rango=0
        },
        new Habilidades{
            nombre="Armadeasta",
            rango=0
        },
        new Habilidades{
            nombre="Manoamano",
            rango=0
        },
        new Habilidades{
            nombre="Exotica",
            rango=0
        },
        // new Habilidades{
        //     nombre="Arcana",
        //     rango=0
        // },
        // new Habilidades{
        //     nombre="Divina",
        //     rango=0
        // },
        // new Habilidades{
        //     nombre="Pura",
        //     rango=0
        // },

    };

    // Vibrar
    [Header("Info")]
    private Vector3 _startPos;
    private float _timer;
    private Vector3 _randomPos;
    
    [Header("Settings")]
    [Range(0f, 2f)]
    public float _time = 0.1f;
    [Range(0f, 2f)]
    public float _distance = 0.1f;
    [Range(0f, 0.1f)]
    public float _delayBetweenShakes = 0f;
    // Start is called before the first frame update    

    void Awake()
    {
        if(arma && (gameObject.tag == "Player"))
        {
            UIManager.Instance.ponerBontonesAcciones(arma, this);            
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

    public void modificarEnergiaMaxima(int cantidad)
    {
        energiamaxima += cantidad; 
    }

    public void modificarNivel(int cantidad)
    {
        nivel += cantidad; 
    }

    public void modificarBasedao(int cantidad)
    {
        basedao += cantidad; 
    }

    public int acertarCritico()
    {
        if(Random.Range(100,0) <= arma.critico)
        {
            return arma.bonocritico;
        }

        return 1;
    }

    public void setDefendiendo()
    {
        defendiendo = true;
    }

    public void getPorcentajeVida()
    {
        return Mathf.Ceil((vida*100)/vidamaxima);
    }

    public void getPorcentajeEnergia()
    {
        return Mathf.Ceil((energia*100)/energiamaxima);
    }

    //codigo para vibrar

   private void OnValidate()
   {
       if (_delayBetweenShakes > _time)
           _delayBetweenShakes = _time;
   }
 

    public void vibrar()
    {
        _startPos = transform.position;
        StopAllCoroutines();
        StartCoroutine(Shake());
    }
 
   private IEnumerator Shake()
   {
       _timer = 0f;
 
       while (_timer < _time)
       {
           _timer += Time.deltaTime;
 
           _randomPos = _startPos + (Random.insideUnitSphere * _distance);
 
           transform.position = _randomPos;
 
           if (_delayBetweenShakes > 0f)
           {
               yield return new WaitForSeconds(_delayBetweenShakes);
           }
           else
           {
               yield return null;
           }
       }
 
       transform.position = _startPos;
   }
}

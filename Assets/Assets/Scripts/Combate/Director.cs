using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum estadoBatalla { INICIO, JUGADORTURNO, ENEMIGOTURNO, GANAR, PERDER}
public class Director : MonoBehaviour
{
    // Start is called before the first frame update
    public static Director Instance;
    [SerializeField] GameObject grupo;
    [SerializeField] GameObject enemigos;
    [SerializeField] estadoBatalla batalla;
    [SerializeField] CombatesScriptObject combate;
    [SerializeField] int inicioEnemigos;
    [SerializeField] Transform[] grupoJugadores;
    [SerializeField] Transform[] grupoEnemigos;
    [SerializeField] int turno = 0;
    private float distancia;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    
    void Start()
    {
        batalla = estadoBatalla.INICIO;
        StartCoroutine(Batalla());
    }

    public void Turno()
    {
        switch(batalla)
        {
            case  estadoBatalla.JUGADORTURNO:
                if(turno<grupoJugadores.Length)
                {
                    JugadorTurno();
                    Debug.Log(turno);
                    turno++;
                }else
                {
                    batalla = estadoBatalla.ENEMIGOTURNO;
                    StartCoroutine(InciarTurnoEnemigo());
                    turno = 1;
                }
            break;

            case  estadoBatalla.ENEMIGOTURNO:
                if(turno<grupoEnemigos.Length)
                {
                    turno++;
                    StartCoroutine(InciarTurnoEnemigo());
                }else
                {
                    batalla = estadoBatalla.JUGADORTURNO;
                    turno = 0;
                }
            break;
        }
    }

    void llenarContenedoresDeCombatientes()
    {
        List<Transform> objetos = new List<Transform>();
        foreach(Transform child in grupo.transform) 
        {
            objetos.Add(child);
        }
        grupoJugadores=objetos.ToArray();
        objetos.Clear();
        foreach(Transform child in enemigos.transform) 
        {
            objetos.Add(child);
        }
        grupoEnemigos=objetos.ToArray();
    }
    
    IEnumerator Batalla()
    {
        float espacioSprite = 0;
        Sprite sprites;

        switch(combate.prefabs.Length)
        {
            case 1:
            inicioEnemigos = 0;
            break;
            case 2:
            inicioEnemigos = -2;
            break;
            case 3:
            inicioEnemigos = -4;
            break;
            case 4:
            inicioEnemigos = -6;
            break;
            case 5:
            inicioEnemigos = -8;
            break;
        }
        
        foreach(GameObject enemigo in  combate.prefabs)
        {
            GameObject enemy = Instantiate(enemigo, new Vector3(inicioEnemigos,0,0), Quaternion.identity, enemigos.transform);
            sprites = enemy.GetComponentInChildren<SpriteRenderer>().sprite;
            enemy.transform.position = new Vector3(enemy.transform.position.x+(espacioSprite),enemy.transform.position.y,enemy.transform.position.z);
            espacioSprite +=  enemy.GetComponentInChildren<SpriteRenderer>().bounds.size.x +1;   
        }

        yield return new WaitForSeconds(2f);

        batalla = estadoBatalla.JUGADORTURNO;
        llenarContenedoresDeCombatientes();
        Turno();
    }

    public void JugadorTurno()
    {
        cambiarTexto("Turno Del Jugador");
    }

    public void jugadorAtaque(int dao)
    {
        Debug.Log(dao)
        grupoEnemigos[0].GetComponent<Personaje>().modificarVida(-dao);
        cambiarTexto("El enemigo ha recibido "+dao+" de daño");
        Turno();
    }

    //Enemigo Turno
    IEnumerator InciarTurnoEnemigo()
    {
        yield return new WaitForSeconds(1f);
        EnemigoTurno();
    }

    public void enemigoAtaque()
    {
        cambiarTexto("El Enemigo Ataca");
        grupoEnemigos[0].GetComponent<IA>().EjecutarIA();
        // grupoJugadores[0].GetComponent<Personaje>().modificarVida(-22);
        cambiarTexto("Recibes "+22+" de daño");
        Turno();
    }

    public void EnemigoTurno()
    {
        cambiarTexto("Turno Del Enemigo");
        enemigoAtaque();
    }

    void cambiarTexto(string text)
    {
        UICombate.Instance.cambiarTextoDescripcion(text);
    }

}

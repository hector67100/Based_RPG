using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    [SerializeField] public Transform[] grupoJugadores;
    [SerializeField] public Transform[] grupoEnemigos;
    [SerializeField] Transform Jugador;
    [SerializeField] int turno = 0;
    [SerializeField] int enemigoSeleccionado = 0;
    [SerializeField] Acciones accionEnCola = null;
    [SerializeField] Animator anim;
    private float distancia;
    public bool seleccionable = false;

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
                    UICombate.Instance.setUiJugadorTurno(true);
                    Jugador = grupoJugadores[turno];
                    JugadorTurno();
                    turno++;
                }else
                {
                    batalla = estadoBatalla.ENEMIGOTURNO;
                    StartCoroutine(InciarTurnoEnemigo());
                    UICombate.Instance.setUiJugadorTurno();
                    turno = 0;
                }
            break;

            case  estadoBatalla.ENEMIGOTURNO:
                if(turno<grupoEnemigos.Length)
                {
                    StartCoroutine(InciarTurnoEnemigo());
                }else
                {
                    batalla = estadoBatalla.JUGADORTURNO;
                    turno = 0;
                    StartCoroutine(ReiniciarTurno());
                }
            break;

            case  estadoBatalla.GANAR:
                Debug.Log("ganaste");
            break;
            case  estadoBatalla.PERDER:
                Debug.Log("perdiste");
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
        int conteoEnemigo = 0;
        foreach(GameObject enemigo in  combate.prefabs)
        {
            GameObject enemy = Instantiate(enemigo, new Vector3(inicioEnemigos,0,0), Quaternion.identity, enemigos.transform);
            enemy.name = enemy.name + conteoEnemigo.ToString();
            enemy.GetComponent<Personaje>().index = conteoEnemigo;
            sprites = enemy.GetComponentInChildren<SpriteRenderer>().sprite;
            enemy.transform.position = new Vector3(enemy.transform.position.x+(espacioSprite),enemy.transform.position.y,enemy.transform.position.z);
            espacioSprite +=  enemy.GetComponentInChildren<SpriteRenderer>().bounds.size.x +1;
            conteoEnemigo++;   
        }

        yield return new WaitForSeconds(2f);

        batalla = estadoBatalla.JUGADORTURNO;
        llenarContenedoresDeCombatientes();
        Personaje datojugador = grupoJugadores[0].GetComponent<Personaje>();
        UIManager.Instance.setSlidersMaxValues(datojugador.vidamaxima,datojugador.energiamaxima);
        UIManager.Instance.setSlidersValues(datojugador.vida,datojugador.energia);
        Turno();
    }

    public void JugadorTurno()
    {
        cambiarTexto("Turno Del Jugador");
    }

    public void jugadorAtaque(int dao)
    {
        setaccionEnCola(Jugador.GetComponentInChildren<Arma>().basico);
        UICombate.Instance.setUiJugadorTurno();
        cambiarTexto("Seleccione Enemigo");
    }

    //Enemigo Turno
    IEnumerator InciarTurnoEnemigo()
    {
        yield return new WaitForSeconds(1f);
        EnemigoTurno();
    }

    IEnumerator ReiniciarTurno()
    {
        yield return new WaitForSeconds(1f);
        Turno();
    }

    public void enemigoAtaque()
    {
        cambiarTexto("El Enemigo Ataca "+grupoEnemigos[turno].gameObject.name);
        VibrarCamara.Instance.MoverCamara(5,5,0.5f);
        grupoEnemigos[turno].GetComponent<IA>().EjecutarIA();
        cambiarTexto("Recibes "+22+" de daño");
        grupoJugadores[0].GetComponent<Personaje>().modificarVida(-23);
        StopCoroutine(InciarTurnoEnemigo());
        turno++;
        Turno();
    }

    public void EnemigoTurno()
    {
        cambiarTexto("Turno Del Enemigo");
        enemigoAtaque();
    }

    public void cambiarTexto(string text)
    {
        UICombate.Instance.cambiarTextoDescripcion(text);
    }

    public void seleccionarEnemigo(string name)
    {
       int index = Array.FindIndex(grupoEnemigos, enemigo => enemigo.name == name);
       enemigoSeleccionado = index;
       anim.Play(accionEnCola.animacion);
    }

    public void setaccionEnCola(Acciones habilidad)
    {
        accionEnCola = habilidad;
    }

    public void ejecutarAccion()
    {
        int dao = grupoJugadores[0].GetComponent<Personaje>().basedao + accionEnCola.poder;
        cambiarTexto("El Enemigo Recibe "+dao+" de daño");
        grupoEnemigos[enemigoSeleccionado].GetComponent<Personaje>().modificarVida(-dao);
        grupoJugadores[0].GetComponent<Personaje>().modificarEnergia(-accionEnCola.costo);
        Turno();
    }

    public bool obtenerTamano(Transform[] array)
    {
        if(array.Length <= 0)
        {
            return false;
        }

        return true;
    }

    public void limpiarArrayEnemigos(int index)
    {

        grupoEnemigos[index]=null;
        List<Transform> lista = new List<Transform>();
        foreach (Transform t in grupoEnemigos)
        {
          lista.Add(t);
        }

        lista.RemoveAll(s => s == null);
        grupoEnemigos = lista.ToArray();
        if(grupoEnemigos.Length > 0)
        {
            for(int i=0;i<grupoEnemigos.Length;i++)
            {
                grupoEnemigos[i].GetComponent<Personaje>().index = i;
            }
        }
        else
        {
            batalla = estadoBatalla.GANAR;
        }
    }

    public void limpiarArrayJugador(int index)
    {

        grupoJugadores[index]=null;
        List<Transform> lista = new List<Transform>();
        foreach (Transform t in grupoJugadores)
        {
          lista.Add(t);
        }

        lista.RemoveAll(s => s == null);
        grupoJugadores = lista.ToArray();

        if(grupoEnemigos.Length > 0)
        {
            for(int i=0;i<grupoJugadores.Length;i++)
            {
                grupoJugadores[i].GetComponent<Personaje>().index = i;
            }
        }
        else
        {
            batalla = estadoBatalla.PERDER;
        }
    }

}

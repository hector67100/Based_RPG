using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABase
{
    public Director dic = Director.Instance;
    public Personaje enemigo;
    public Personaje jugador;
    public int vidaEnemigo;
    public int energiaEnemigo;
    public int vidaJugador;
    public List<Acciones> acciones = new List<Acciones>();
    
    public Acciones pasar = new Acciones{
    nombre = "",
    poder = 0,
    costo = 0,
    descripcion = "",
    minNivel = 0,
    animacion = "",
    tipo = Acciones.Tipo.pasar
    };

    public Acciones defender = new Acciones{
    nombre = "",
    poder = 0,
    costo = 0,
    descripcion = "",
    minNivel = 0,
    animacion = "",
    tipo = Acciones.Tipo.defender
    };
}

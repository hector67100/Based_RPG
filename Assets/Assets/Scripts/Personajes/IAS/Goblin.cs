using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : IExecuteIA 
{
    // Start is called before the first frame update
    private Director dic = Director.Instance;
    private Personaje enemigo;
    private Personaje jugador;
    private int vidaEnemigo;
    private int energiaEnemigo;
    private int vidaJugador;
    public void Exec()
    {
        enemigo = dic.obtenerEnemigoConTurno();
        jugador = dic.grupoJugadores[0].GetComponent<Personaje>();
        vidaJugador = jugador.getPorcentajeVida();
        vidaEnemigo = enemigo.getPorcentajeVida();
        energiaEnemigo = enemigo.getPorcentajeEnergia();
    }
}

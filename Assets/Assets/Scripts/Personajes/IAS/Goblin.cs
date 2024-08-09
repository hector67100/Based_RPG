using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : IABase, IExecuteIA 
{
    // Start is called before the first frame update
    public void Exec()
    {
        enemigo = dic.obtenerEnemigoConTurno();
        jugador = dic.grupoJugadores[0].GetComponent<Personaje>();
        vidaJugador = jugador.getPorcentajeVida();
        vidaEnemigo = enemigo.getPorcentajeVida();
        energiaEnemigo = enemigo.getPorcentajeEnergia();
         
        
        if(vidaEnemigo <= 100 && vidaEnemigo >60)
        {
            if(vidaJugador <= 100 && vidaJugador > 20)
            {
                acciones.Add(enemigo.arma.acciones[0]);
                acciones.Add(enemigo.arma.acciones[1]);
                acciones.Add(pasar);
            }
            else
            {
                acciones.Add(pasar);
            }
        }

        dic.igualarListaAcciones(acciones.ToArray());
        acciones.Clear();
    }
}

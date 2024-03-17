using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herramientas : MonoBehaviour
{
    // Start is called before the first frame update
    public int personajeConMasVida(Transform[] grupo)
    {
        int indexGrupo = 0;
        int vida = grupo[0].GetComponent<Personaje>().vida;
        for(int i = 1;i<grupo.Length;i++)
        {
            if(vida > grupo[i].GetComponent<Personaje>().vida)
            {
                indexGrupo = i;
                vida = grupo[i].GetComponent<Personaje>().vida;
            }
        }

        return indexGrupo;
    }
    

    public int personajeConMenosVida(Transform[] grupo)
    {
        int indexGrupo = 0;
        int vida = grupo[0].GetComponent<Personaje>().vida;
        for(int i = 1;i<grupo.Length;i++)
        {
            if(vida < grupo[i].GetComponent<Personaje>().vida)
            {
                indexGrupo = i;
                vida = grupo[i].GetComponent<Personaje>().vida;
            }
        }

        return indexGrupo;
    }

    public int personajeConMasNivel(Transform[] grupo)
    {
        int indexGrupo = 0;
        int vida = grupo[0].GetComponent<Personaje>().nivel;
        for(int i = 1;i<grupo.Length;i++)
        {
            if(vida > grupo[i].GetComponent<Personaje>().nivel)
            {
                indexGrupo = i;
                vida = grupo[i].GetComponent<Personaje>().nivel;
            }
        }

        return indexGrupo;
    }
    

    public int personajeConMenosNivel(Transform[] grupo)
    {
        int indexGrupo = 0;
        int vida = grupo[0].GetComponent<Personaje>().nivel;
        for(int i = 1;i<grupo.Length;i++)
        {
            if(vida < grupo[i].GetComponent<Personaje>().nivel)
            {
                indexGrupo = i;
                vida = grupo[i].GetComponent<Personaje>().nivel;
            }
        }

        return indexGrupo;
    }


        public int personajeConMasDao(Transform[] grupo)
    {
        int indexGrupo = 0;
        int vida = grupo[0].GetComponent<Personaje>().basedao;
        for(int i = 1;i<grupo.Length;i++)
        {
            if(vida > grupo[i].GetComponent<Personaje>().basedao)
            {
                indexGrupo = i;
                vida = grupo[i].GetComponent<Personaje>().basedao;
            }
        }

        return indexGrupo;
    }
    

    public int personajeConMenosDao(Transform[] grupo)
    {
        int indexGrupo = 0;
        int vida = grupo[0].GetComponent<Personaje>().basedao;
        for(int i = 1;i<grupo.Length;i++)
        {
            if(vida < grupo[i].GetComponent<Personaje>().basedao)
            {
                indexGrupo = i;
                vida = grupo[i].GetComponent<Personaje>().basedao;
            }
        }

        return indexGrupo;
    }
}

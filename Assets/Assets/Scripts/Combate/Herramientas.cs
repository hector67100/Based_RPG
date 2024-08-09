using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Herramientas
{
    // Start is called before the first frame update
    public static int personajeConMasVida(Transform[] grupo)
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
    

    public static int personajeConMenosVida(Transform[] grupo)
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

    public static int personajeConMasNivel(Transform[] grupo)
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
    

    public static int personajeConMenosNivel(Transform[] grupo)
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


        public static int personajeConMasDao(Transform[] grupo)
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
    

    public static int personajeConMenosDao(Transform[] grupo)
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

    public static  bool Cronometro(out float temp, float tiempo, float limite)
    {
        temp = tiempo + Time.deltaTime;
        if (temp >= limite)
        {
            temp = 0;
            return true;
        }
        return false;
    }
}

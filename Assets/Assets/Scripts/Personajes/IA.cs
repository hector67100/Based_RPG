using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class IA : MonoBehaviour
{
    [SerializeField] string ia;

    public void EjecutarIA()
    {   
        Debug.Log("ay");
        switch(ia)
        {
            case "Tanque":
            IAtype<IATanque> PUTA = new IAtype<IATanque>(new IATanque());
            break;
        }
    }
}

public interface IExecuteIA 
{
    void Exec();
}

public class IAtype<T> where T:IExecuteIA 
{
    public T data;

    public IAtype (T value)
    {
        value.Exec();
    }
}

public class IACurador : IExecuteIA 
{
    public void Exec()
    {
        Debug.Log("Yo curo");
    }
}

public class IATanque: IExecuteIA 
{
    public void Exec()
    {
        Debug.Log("Yo Tanqueo");
    }
}

public class IADao: IExecuteIA 
{
    public void Exec()
    {
        Debug.Log("Yo Hago DAO");
    }
}

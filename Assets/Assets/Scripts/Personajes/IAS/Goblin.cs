using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : IExecuteIA 
{
    // Start is called before the first frame update
    Director dic = Director.Instance;
    public void Exec()
    {
        dic.cambiarTexto("hola");
    }
}

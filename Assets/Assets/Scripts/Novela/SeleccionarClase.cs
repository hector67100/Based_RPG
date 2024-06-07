using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;
using Naninovel.Commands;

[CommandAlias("actualizarClase")]
public class SeleccionarClase : Command
{
    // Start is called before the first frame update    
    [ParameterAlias("Clase")]
    public IntegerParameter clase = 0;
    public static Personaje pordefecto = new Personaje();
    public string[] clases = new string[]{"Guerrero","Picaro"};
    public override async UniTask ExecuteAsync (AsyncToken asyncToken)
    {
        var varManager = Engine.GetService<ICustomVariableManager>();
        
        foreach(Habilidades habilidad in pordefecto.habilidades)
        {
            varManager.SetVariableValue(habilidad.nombre.ToLower(), "0");
        }

        switch(clase)
        {
            case var value when value == 0:
                varManager.SetVariableValue("claseMostrar", clases[clase]);
                varManager.SetVariableValue("atletismo", "1");
                varManager.SetVariableValue("acrobacia", "1");
                varManager.SetVariableValue("avistar", "1");
                varManager.SetVariableValue("escuchar", "1");
                varManager.SetVariableValue("diplomacia", "1");
            break;
            case var value when value == 1:
                varManager.SetVariableValue("claseMostrar", clases[clase]);
                varManager.SetVariableValue("sigilo", "1");
                varManager.SetVariableValue("engañar", "1");
                varManager.SetVariableValue("avistar", "1");
                varManager.SetVariableValue("escuchar", "1");
                varManager.SetVariableValue("diplomacia", "1");
            break;
            default:
                varManager.SetVariableValue("claseMostrar", clases[clase]);
                varManager.SetVariableValue("atletismo", "1");
                varManager.SetVariableValue("acrobacia", "1");
                varManager.SetVariableValue("avistar", "1");
                varManager.SetVariableValue("escuchar", "1");
                varManager.SetVariableValue("diplomacia", "1");
            break;
        }
    }
}

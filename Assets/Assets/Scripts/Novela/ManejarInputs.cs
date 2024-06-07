using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Naninovel;
public class ManejarInputs : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField input;
    public string Script;
    public string nameVar;
    
    public async void ejecutarScript()
    {
        var switchCommand = new ActualizarVariableCustomYEjecutarScript { ScriptName = Script, Label= nameVar, value = input.text};
        switchCommand.ExecuteAsync().Forget();
    }
}

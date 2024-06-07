using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;

public class ActualizarVariableCustomYEjecutarScript : Command
{
    // Start is called before the first frame update
    public StringParameter ScriptName;
    public StringParameter Label;
    public StringParameter value;
    public override async UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {
        var varManager = Engine.GetService<ICustomVariableManager>();
        varManager.SetVariableValue(Label, value);
        Debug.Log(varManager.GetVariableValue(Label));
        if (Assigned(ScriptName))
        {
            var scriptPlayer = Engine.GetService<IScriptPlayer>();
            await scriptPlayer.PreloadAndPlayAsync(ScriptName);
        }
    }
}


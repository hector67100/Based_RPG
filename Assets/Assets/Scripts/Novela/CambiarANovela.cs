using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;

public class CambiarANovela : Command
{
    // Start is called before the first frame update
    public StringParameter ScriptName;
    public StringParameter Label;
    public override async UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {
        if (Assigned(ScriptName))
        {
            var scriptPlayer = Engine.GetService<IScriptPlayer>();
            await scriptPlayer.PreloadAndPlayAsync(ScriptName, label: Label);
        }

        // 4. Enable Naninovel input.
        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = true;
    }
}

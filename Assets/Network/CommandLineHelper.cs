using System.Collections.Generic;
using ParrelSync;
using Unity.Netcode;
using UnityEngine;

public class CommandLineHelper : MonoBehaviour
{
    private NetworkManager netManager;

    private void Start()
    {
        netManager = GetComponentInParent<NetworkManager>();

        // if (Application.isEditor) return;

        var args = GetCommandlineArgs();

        if (args.TryGetValue("-mode", out var mode))
        {
            switch (mode)
            {
                case "server":
                    netManager.StartServer();
                    break;
                case "host":
                    netManager.StartHost();
                    break;
                case "client":
                    netManager.StartClient();
                    break;
            }
        }
        if (ClonesManager.IsClone()) {
            var editorMode = ClonesManager.GetArgument();
            switch (editorMode)
            {
                case "server":
                    netManager.StartServer();
                    break;
                case "client":
                    netManager.StartClient();
                    break;
            }
        }
        else {
            netManager.StartHost();
        }

    }

    private Dictionary<string, string> GetCommandlineArgs()
    {
        Dictionary<string, string> argDictionary = new Dictionary<string, string>();

        var args = System.Environment.GetCommandLineArgs();

        for (int i = 0; i < args.Length; ++i)
        {
            var arg = args[i].ToLower();
            if (arg.StartsWith("-"))
            {
                var value = i < args.Length - 1 ? args[i + 1].ToLower() : null;
                value = (value?.StartsWith("-") ?? false) ? null : value;

                argDictionary.Add(arg, value);
            }
        }
        return argDictionary;
    }
}
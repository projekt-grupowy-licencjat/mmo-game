using System.Collections.Generic;
using ParrelSync;
using Unity.Netcode;
using UnityEngine;

public class CommandLineHelper : MonoBehaviour
{
    private NetworkManager _netManager;

    private void Start()
    {
        _netManager = GetComponentInParent<NetworkManager>();

        if (Application.isEditor) {
            if (ClonesManager.IsClone()) {
                var editorMode = ClonesManager.GetArgument();
                switch (editorMode)
                {
                    case "server":
                        _netManager.StartServer();
                        break;
                    case "client":
                        _netManager.StartClient();
                        break;
                }
            }
            else {
                _netManager.StartHost();
            }
        }
        else {
            var args = GetCommandlineArgs();
            if (!args.TryGetValue("-mode", out var mode)) return;
            switch (mode)
            {
                case "server":
                    _netManager.StartServer();
                    break;
                case "host":
                    _netManager.StartHost();
                    break;
                case "client":
                    _netManager.StartClient();
                    break;
            }
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
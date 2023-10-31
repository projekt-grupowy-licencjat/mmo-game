using System;
using UnityEngine;

namespace UIManager
{
    [Serializable]
    public class KeycodeElement
    {
        public string Keycode;
        public GameObject Element;
        public bool Active = false;
    }
}
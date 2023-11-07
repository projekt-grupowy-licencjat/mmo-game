using Unity.Netcode;
using UnityEngine;

namespace Network
{
    public class LocalPlayerSingleton : NetworkBehaviour
    {
        public static LocalPlayerSingleton Instance { get; private set; }
        public GameObject LocalPlayer { get; set; }
        
        private void Start()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }
    }
}
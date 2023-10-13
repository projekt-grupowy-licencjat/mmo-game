using UnityEngine;

namespace NPC
{
    public class DialogueBox : MonoBehaviour
    {
        public NpcController npc;

        private void Exit()
        {
            npc.isBusy = false;
            Destroy(this);
        }
    }
}
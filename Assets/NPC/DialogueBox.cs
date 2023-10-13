using UnityEngine;

namespace NPC
{
    public class DialogueBox : MonoBehaviour
    {
        public NpcController npc;

        private Canvas _canvas;
        
        public void Start()
        {
            _canvas = gameObject.AddComponent<Canvas>();
        }
        
        // Method called by NPCController when creating DialogueBox (should be used for getting data from npc)
        public void SetUp()
        {
            
        }
        
        private void Exit()
        {
            npc.isBusy = false;
            Destroy(this);
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace NPC
{
    public class DialogueBox : MonoBehaviour
    {
        public NpcController npc;
        
        
        // Method called by NPCController when creating DialogueBox (should be used for getting data from npc)
        public void SetUp()
        {
            
        }

        public void Start()
        {
            var canvas = this.gameObject.transform.Find("Canvas");
            Button[] buttons = canvas.gameObject.GetComponentsInChildren<Button>();
            buttons[2].onClick.AddListener(Exit);
            Debug.Log(buttons.Length);
        }
        
        private void Exit()
        {
            npc.isBusy = false;
            Destroy(this.gameObject);
        }
    }
}
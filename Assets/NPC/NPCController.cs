using System;
using UnityEngine;
using UnityEngine.EventSystems;

// TODO: Make dialog box customisable from here
namespace NPC
{
    public class NpcController : MonoBehaviour
    {
        public GameObject player;
        public double interactiveDistance;
        public bool isBusy;
        
        private bool _isInteractive;
    
        public void Start()
        {
            isBusy = false;
            _isInteractive = false;
            
            var eventTrigger = gameObject.AddComponent<EventTrigger>();
            
            var pointerEnter = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerEnter
            };
            pointerEnter.callback.AddListener(OnPointerEnterDelegate);
            eventTrigger.triggers.Add(pointerEnter);
            
            var pointerExit = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerExit
            };
            pointerExit.callback.AddListener(OnPointerExitDelegate);
            eventTrigger.triggers.Add(pointerExit);
            
            var pointerClick = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerClick
            };
            pointerClick.callback.AddListener(OnPointerClickDelegate);
            eventTrigger.triggers.Add(pointerClick);
        }
    
        public void Update()
        {
            _isInteractive = CalculateDistanceToPlayer() <= interactiveDistance;
        }
    
        private void OnPointerEnterDelegate(BaseEventData data)
        {
            Debug.Log("test3");
            
        }
        
        private void OnPointerExitDelegate(BaseEventData data)
        {
            Debug.Log("test2");

        }
        
        private void OnPointerClickDelegate(BaseEventData data)
        {
            if (isBusy) return;

            isBusy = true;
            var dialogueBox = new GameObject(name+"DialogueBox");
            dialogueBox.AddComponent<DialogueBox>();
        }
        
        private double CalculateDistanceToPlayer()
        {
            var playerPosition = player.transform.position;
            var npcPosition = transform.position;
            var subtractionX = playerPosition.x - npcPosition.x;
            var subtractionY = playerPosition.y - npcPosition.y;
        
            return Math.Sqrt(Math.Pow(subtractionX, 2) + Math.Pow(subtractionY, 2));
        }
    }
}

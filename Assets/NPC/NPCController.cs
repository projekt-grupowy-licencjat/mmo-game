using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;

// TODO: Maybe part this big script to two separate scripts?
namespace NPC
{
    public class NpcController : MonoBehaviour
    {
        public GameObject player;
        public double interactiveDistance;
        public bool isBusy;
        [SerializeField] public string prefabAddress = "Assets/NPC/DialogueBox.prefab";
        [SerializeField] public List<string> dialogueLines;
        
        private AsyncOperationHandle<GameObject> _dialogueHandle; 
        private bool _isInteractive;
    
        public IEnumerator Start()
        {
            isBusy = false;
            _isInteractive = false;
            
            _dialogueHandle = Addressables.LoadAssetAsync<GameObject>(prefabAddress);
            yield return _dialogueHandle;
            
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

        public void OnDestroy()
        {
            Addressables.Release(_dialogueHandle);    
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
            if (!_isInteractive) return;
            if (_dialogueHandle.Status != AsyncOperationStatus.Succeeded) return;
            
            isBusy = true;
            GameObject obj = _dialogueHandle.Result;
            var dialogueBox = obj.AddComponent<DialogueBox>();
            dialogueBox.npc = this;
            dialogueBox.SetUp(dialogueLines);
            Instantiate(obj, transform);
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

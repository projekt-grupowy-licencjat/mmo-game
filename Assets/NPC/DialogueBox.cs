using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace NPC
{
    public class DialogueBox : MonoBehaviour {
        public MorseCode morseCodeController;
        public NpcController npc;
        public TMP_Text _talkText;
        public List<string> _dialogueLines;
        private readonly Random _rnd = new Random();
        
        
        // Method called by NPCController when creating DialogueBox (should be used for getting data from npc)
        public void SetUp([NotNull] List<string> dialogueLines)
        {
            _dialogueLines = dialogueLines ?? throw new ArgumentNullException(nameof(dialogueLines));
        }

        public void Start()
        {
            var canvas = this.gameObject.transform.Find("Canvas"); // TODO: Get component?
            Button[] buttons = canvas.gameObject.GetComponentsInChildren<Button>();
            _talkText = canvas.gameObject.GetComponentInChildren<TMP_Text>();
            Debug.Log(_talkText.text);
            buttons[0].onClick.AddListener(Talk);
            buttons[2].onClick.AddListener(Exit);
        }

        private void Talk()
        {
            var elemInd = _rnd.Next(_dialogueLines.Count);
            _talkText.text = _dialogueLines[elemInd];
            morseCodeController.StopMorseCode();
            morseCodeController.PlayMorseCodeMessage(_talkText.text);
        }
        
        private void Exit()
        {
            npc.isBusy = false;
            morseCodeController.StopMorseCode();
            Destroy(this.gameObject);
        }
    }
}
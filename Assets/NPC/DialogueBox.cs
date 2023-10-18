using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace NPC
{
    public class DialogueBox : MonoBehaviour
    {
        public NpcController npc;

        private List<string> _dialogueLines;
        private readonly Random _rnd = new Random();
        private TMP_Text talkText;
        
        // Method called by NPCController when creating DialogueBox (should be used for getting data from npc)
        public void SetUp([NotNull] List<string> dialogueLines)
        {
            this._dialogueLines = dialogueLines ?? throw new ArgumentNullException(nameof(dialogueLines));
        }

        public void Start()
        {
            var canvas = this.gameObject.transform.Find("Canvas"); // TODO: Get component?
            Button[] buttons = canvas.gameObject.GetComponentsInChildren<Button>();
            talkText = canvas.gameObject.GetComponentInChildren<TMP_Text>();
            Debug.Log(talkText.text);
            buttons[0].onClick.AddListener(Talk);
            buttons[2].onClick.AddListener(Exit);
        }

        private void Talk()
        {
            // talkText.text =
            int elemInd = _rnd.Next(_dialogueLines.Count);
            Debug.Log(elemInd);
        }
        
        private void Exit()
        {
            npc.isBusy = false;
            Destroy(this.gameObject);
        }
    }
}
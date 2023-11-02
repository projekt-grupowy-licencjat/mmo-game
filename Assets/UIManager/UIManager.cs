using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UIManager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private List<KeycodeElement> keycodeElements;
        [SerializeField] private List<GameObject> staticElements;
        
        private List<ActiveElement> _activeElements;

        public void MakeTop(ElementManager elementManager)
        {
            foreach (var (element, index) in _activeElements.Select((item, index) => (item, index)))
            {
                var panelChild = element.Element.transform.GetChild(0).gameObject;
                if (panelChild.GetComponent<ElementManager>() == elementManager)
                {
                    var elementCanvas = element.Element.GetComponent<Canvas>();
                    elementCanvas.sortingOrder = 1;
                    
                    var previousTopCanvas = _activeElements[0].Element.GetComponent<Canvas>();
                    previousTopCanvas.sortingOrder = 0;
                    
                    _activeElements.RemoveAt(index);
                    _activeElements.Insert(0, element);
                    return;
                }
            }
        }
        
        private void Start()
        {
            _activeElements = new List<ActiveElement>();

            foreach (var element in staticElements)
            {
                var staticElem = Instantiate(element, transform, true);
                var elemCanvas = staticElem.GetComponent<Canvas>();
                elemCanvas.sortingOrder = 2;
            }
        }

        private void Update()
        {
            foreach (var (element, index) in keycodeElements.Select((item, index) => (item, index)))
            {
                if (Input.GetKeyDown(element.Keycode) && !element.Active)
                {
                    element.Active = true;
                    var newElement = Instantiate(element.Element, gameObject.transform, true);
                    var panelChild = newElement.transform.GetChild(0).gameObject;
                    var elemManager = panelChild.AddComponent<ElementManager>();
                    
                    _activeElements.Insert(0, new ActiveElement(index, newElement));
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape) && _activeElements.Count != 0)
            {
                var keycodeIndex = _activeElements[0].KeycodeElementIndex;
                keycodeElements[keycodeIndex].Active = false;
                Destroy(_activeElements[0].Element);
                _activeElements.RemoveAt(0);
            }
        }
    }
}
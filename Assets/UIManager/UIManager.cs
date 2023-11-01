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
        
        private List<Tuple<int, GameObject>> _activeElements;
        private Canvas _canvas;
        
        private void Start()
        {
            _canvas = GetComponent<Canvas>();
            _activeElements = new List<Tuple<int, GameObject>>();

            foreach (var element in staticElements)
            {
                Instantiate(element, transform, true);
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
                    _activeElements.Insert(0, Tuple.Create(index, newElement));
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape) && _activeElements.Count != 0)
            {
                int keycodeIndex = _activeElements[0].Item1;
                keycodeElements[keycodeIndex].Active = false;
                Destroy(_activeElements[0].Item2);
                _activeElements.RemoveAt(0);
            }
        }
    }
}
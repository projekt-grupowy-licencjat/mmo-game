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
        
        private void Start()
        {
            _activeElements = new List<Tuple<int, GameObject>>();

            foreach (var element in staticElements)
            {
                // TODO: spawn in children canvas here
            }
        }

        private void Update()
        {
            foreach (var (element, index) in keycodeElements.Select((item, index) => (item, index)))
            {
                if (Input.GetKeyDown(element.Keycode) && !element.Active)
                {
                    element.Active = true;
                    // TODO: Refactor it to be instantiated in canvas of this manager
                    var newElement = Instantiate(element.Element);
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
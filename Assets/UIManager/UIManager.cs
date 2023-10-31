using System.Collections.Generic;
using UnityEngine;

namespace UIManager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private List<KeycodeElement> keycodeElements;
        private List<GameObject> _activeElements;
        
        private void Start()
        {
            _activeElements = new List<GameObject>();
        }

        private void Update()
        {
            foreach (var element in keycodeElements)
            {
                if (Input.GetKeyDown(element.Keycode) && !element.Active)
                {
                    element.Active = true;
                    var newElement = Instantiate(element.Element);
                    _activeElements.Add(newElement);
                }
            }
        }
    }
}
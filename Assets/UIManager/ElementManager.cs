using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIManager
{
    public class ElementManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private UIManager _uiManager;
        private bool _isMouseDown = false;
        private Vector3 _startMousePosition;
        private Vector3 _startPosition;
        
        private void Start()
        {
            _uiManager = GetComponentInParent<UIManager>();
        }

        private void Update()
        {
            if (_isMouseDown)
            {
                Vector3 currentPosition = Input.mousePosition;
                
                Vector3 diff = currentPosition - _startMousePosition;
 
                Vector3 pos = _startPosition + diff;
 
                transform.position = pos;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _uiManager.MakeTop(this);
            _isMouseDown = true;
            _startPosition = transform.position;
            _startMousePosition = Input.mousePosition;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isMouseDown = false;
        }
    }
}
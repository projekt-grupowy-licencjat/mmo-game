using UnityEngine;

namespace UIManager
{
    public class ActiveElement
    {
        public int KeycodeElementIndex { get; }
        public GameObject Element { get; }

        public ActiveElement(int keycodeElementIndex, GameObject element)
        {
            KeycodeElementIndex = keycodeElementIndex;
            Element = element;
        }
    }
}
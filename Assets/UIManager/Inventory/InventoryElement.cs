using Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace UIManager.Inventory
{
    public class InventoryElement : MonoBehaviour
    {
        public ItemData itemData;
        private TextMeshProUGUI _text;
        private Image _image;

        private void Start()
        {
            _text = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
            _image = GameObject.Find("Image").GetComponent<Image>();

            _text.text = itemData.itemName;
            _image.sprite = itemData.itemSprite;
        }
    }
}
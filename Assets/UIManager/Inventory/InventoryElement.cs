using Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace UIManager.Inventory
{
    public class InventoryElement : MonoBehaviour
    {
        public ItemData itemData;
        public global::Inventory.Inventory playerInventory;
        private TextMeshProUGUI _text;
        private Image _image;
        private Button _drop;
        
        private void Start()
        {
            
            _text = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
            _image = GameObject.Find("Image").GetComponent<Image>();
            _drop = GameObject.Find("Drop").GetComponent<Button>();
            
            _text.text = itemData.itemName;
            _image.sprite = itemData.itemSprite;
            _drop.onClick.AddListener(DropItem);
        }

        private void DropItem()
        {
            // TODO: Specify position here and change it in manager to handle it ? or here
            ItemManager.Instance.CreateItem(itemData);
            playerInventory.RemoveItem(itemData);
            Destroy(gameObject);
        }
    }
}
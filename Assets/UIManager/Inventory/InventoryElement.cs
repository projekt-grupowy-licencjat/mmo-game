using System;
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
        private Button _equip;
        public WeaponStats playerWeapon;
        public GameObject weaponPanel;
        public Image weaponImage;
        
        private void Start()
        {
            
            // _text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            // _image = gameObject.GetComponentInChildren<Image>();
            // var buttons = gameObject.GetComponentsInChildren<Button>();
            // _drop = buttons[1];
            // _equip = buttons[0];
            _text = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _image = gameObject.transform.GetChild(2).GetComponent<Image>();
            _equip = gameObject.transform.GetChild(0).GetComponent<Button>();
            _drop = gameObject.transform.GetChild(3).GetComponent<Button>();
            
            _text.text = itemData.itemName;
            _image.sprite = itemData.itemSprite;
            _drop.onClick.AddListener(DropItem);
            _equip.onClick.AddListener(EquipWeapon);

            try
            {
                var a = (Weapon)itemData;
            }
            catch (Exception e) // TODO
            {
                Destroy(_equip.gameObject);
            }

            weaponImage = weaponPanel.GetComponent<Image>();
        }

        private void DropItem()
        {
            var pos = playerInventory.gameObject.transform.position;
            ItemManager.Instance.CreateItem(itemData, pos.x, pos.y);
            playerInventory.RemoveItem(itemData);
            Destroy(gameObject);
        }

        private void EquipWeapon()
        {
            playerWeapon.ChangeWeapon((Weapon)itemData);
            weaponImage.sprite = itemData.itemSprite;
        }
    }
}
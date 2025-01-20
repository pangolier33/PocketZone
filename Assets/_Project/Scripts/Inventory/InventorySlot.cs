using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Inventory;
using _Project.Scripts.Inventory.ItemsData;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    [field: SerializeField] public int Id { get; private set; }
    [field: SerializeField] public Item Item { get; private set; }
    [field: Space (10)]
    [field: SerializeField] public Image Image { get; private set; }
    [field: SerializeField] public TMP_Text ItemCountText { get; private set; }

    [SerializeField] private Image _defaultImage;
    [SerializeField] private DeleteItemPanel _deleteInventoryPanel;

    public void InitializeSlot(Item item)
    {
        Image.sprite = item.Sprite;
        Image.preserveAspect = true;
        Item = item;
        ItemCountText.text = item.Count <= 1 ? string.Empty : item.Count.ToString();
    }

    public void ClearSlot()
    {
        Item = null;
        Image.sprite = _defaultImage.sprite;
        ItemCountText.text = string.Empty;
    }

    public bool DropItem(Transform player)
    {
        if (player == null)
        {
            return false;
        }

        Item.transform.position = player.position + Vector3.right * 2;
        Item.gameObject.SetActive(true);
        ClearSlot();
        return true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Item == null) return;
        _deleteInventoryPanel.gameObject.SetActive(true);
        _deleteInventoryPanel.Initialize(Item, this);
    }
}

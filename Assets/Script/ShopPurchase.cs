using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class ShopPurchase : MonoBehaviour
{

    private Transform itemContainer;
    private Transform itemTemplate;

    private void Awake()
    {
        itemContainer = transform.Find("itemContainer");
        itemTemplate = itemContainer.Find("itemTemplate");
        itemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        
    }

    private void CreateItemButton(Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(itemTemplate, itemContainer);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 20f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;

        //shopItemTransform.GetComponent<Button_UI>().ClickFunc = () =>
        //{

        //}
    }
}

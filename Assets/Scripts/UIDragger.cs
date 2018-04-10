using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Professor.Class;
using System;

public class UIDragger : MonoBehaviour {
    static ScrollRect scrollRect;
    static GameObject equipedItems;
    private Vector2 equipedItemsPosition;


    public const string Dragable_Tag = "UIDraggable";
    public const string Dragable_TagEuiped = "UIDraggableEquiped";

    private bool dragging = false;
    private Vector2 OrgPosition;
    private Transform objectToDrag;
    private Image objectToDragImage;

    List<RaycastResult> hitObjects = new List<RaycastResult>();
    // Use this for initialization
    void Start () {
        scrollRect = GetComponent<ScrollRect>();
        scrollRect.onValueChanged.AddListener(ListenerMethod);
        equipedItems = GameObject.Find("EquipedItems");
        equipedItemsPosition = equipedItems.transform.position;
    }

    public void ListenerMethod(Vector2 value)
    {
        equipedItems.transform.position = equipedItemsPosition;
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            objectToDrag = GetDraggableTransformUnderMouse();
            if (objectToDrag != null)
            {
                gameObject.GetComponent<ScrollRect>().vertical = false;
                dragging = true;
                objectToDrag.SetAsLastSibling();
                if (objectToDrag.gameObject.tag == Dragable_TagEuiped)
                {
                    equipedItems.transform.SetAsLastSibling();
                }
                OrgPosition = objectToDrag.position;
                objectToDragImage = objectToDrag.GetComponent<Image>();
                objectToDragImage.raycastTarget = false;
            }
        }

        if (dragging)
        {
            objectToDrag.position = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            gameObject.GetComponent<ScrollRect>().vertical = true;
            if (objectToDrag != null)
            {
                Transform objecttoreplace = GetDraggableTransformUnderMouse();
                if (objecttoreplace != null)
                { 
                    GameObject InvObj = ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).InventoryObj;
                    Transform InvItems = InvObj.transform.Find("InventoryContain").transform.Find("InventoryItems");
                    //Transform EquipedItems = InvObj.transform.Find("InventoryContain").transform.Find("InventoryItems").transform.Find("EquipedItems");
                    Text MoveText;
                    Text ReplaceText;
                    ItemObj move = new ItemObj();
                    ItemObj replace = new ItemObj();
                    //ItemObj moveit = new ItemObj();
                    //ItemObj replaceit = new ItemObj();
                    string moveName = "";
                    string replaceName = "";
                    int hldItemNumber = 0;
                    bool GoodSwap = true;
                    bool MoveEquiped = false;
                    bool ReplaceEquiped = false;

                    if (objectToDrag.gameObject.tag == Dragable_TagEuiped || objecttoreplace.gameObject.tag == Dragable_TagEuiped)
                    {

                        String hldTextNameDrag = "";
                        String hldTextNameReplace = "";

                        if (objectToDrag.gameObject.tag == Dragable_TagEuiped)
                        {
                            move = DataManger.EquipedItems.Find(x => x.InvSlot == objectToDrag.name);
                            
                            hldTextNameDrag = objectToDrag.name;
                            if (move.ItemNumber != 0)
                            {
                                moveName = DataManger.AllItems.Find(x => x.ItemNumber == move.ItemNumber).Name;
                            }
                            MoveText = null;
                            MoveEquiped = true;
                        }
                        else
                        {
                            move = DataManger.playerItems.Find(x => x.InvSlot == objectToDrag.name);                            
                            hldTextNameDrag = "Text " + objectToDrag.name.Split(' ')[1];
                            if (move.ItemNumber != 0)
                            {
                                moveName = DataManger.AllItems.Find(x => x.ItemNumber == move.ItemNumber).Name;
                            }
                            MoveText = InvItems.transform.Find(hldTextNameDrag).GetComponent<Text>();
                        }

                        if (objecttoreplace.gameObject.tag == Dragable_TagEuiped)
                        {
                            replace = DataManger.EquipedItems.Find(x => x.InvSlot == objecttoreplace.name);
                            hldTextNameReplace = objecttoreplace.name;
                            if (replace.ItemNumber != 0)
                            {
                                replaceName = DataManger.AllItems.Find(x => x.ItemNumber == replace.ItemNumber).Name;
                            }
                            ReplaceText = null;
                            ReplaceEquiped = true;
                        }
                        else
                        {
                            replace = DataManger.playerItems.Find(x => x.InvSlot == objecttoreplace.name);
                            hldTextNameReplace = "Text " + objecttoreplace.name.Split(' ')[1];
                            if (replace.ItemNumber != 0)
                            {
                                replaceName = DataManger.AllItems.Find(x => x.ItemNumber == replace.ItemNumber).Name;
                            }
                            ReplaceText = InvItems.transform.Find(hldTextNameReplace).GetComponent<Text>();
                        }

                        if (MoveEquiped && replace.ItemNumber != 0)
                        {
                            if (hldTextNameDrag != DataManger.AllItems.Find(x => x.ItemNumber == replace.ItemNumber).Type
                                && hldTextNameDrag != DataManger.AllItems.Find(x => x.ItemNumber == replace.ItemNumber).AltType1
                                && hldTextNameDrag != DataManger.AllItems.Find(x => x.ItemNumber == replace.ItemNumber).AltType2)
                            {
                                GoodSwap = false;
                            }
                        }
                        if (ReplaceEquiped && move.ItemNumber != 0)
                        {
                            if (hldTextNameReplace != DataManger.AllItems.Find(x => x.ItemNumber == move.ItemNumber).Type
                                && hldTextNameReplace != DataManger.AllItems.Find(x => x.ItemNumber == move.ItemNumber).AltType1
                                && hldTextNameReplace != DataManger.AllItems.Find(x => x.ItemNumber == move.ItemNumber).AltType2)
                            {
                                GoodSwap = false;
                            }
                        }

                        if (GoodSwap)
                        {
                            if (MoveText != null)
                            {
                                MoveText.text = replaceName;
                            }
                            if (ReplaceText != null)
                            {
                                ReplaceText.text = moveName;
                            }
                            hldItemNumber = move.ItemNumber;
                            move.ItemNumber = replace.ItemNumber;
                            replace.ItemNumber = hldItemNumber;
                        }
                    }
                    else
                    {
                        String hldTextNameDrag = "Text " + objectToDrag.name.Split(' ')[1];
                        String hldTextNameReplace = "Text " + objecttoreplace.name.Split(' ')[1];
                                              
                        move = DataManger.playerItems.Find(x => x.InvSlot == objectToDrag.name);
                        if (move.ItemNumber != 0)
                        {
                            moveName = DataManger.AllItems.Find(x => x.ItemNumber == move.ItemNumber).Name;
                        }
                        replace = DataManger.playerItems.Find(x => x.InvSlot == objecttoreplace.name);
                        if (replace.ItemNumber != 0)
                        {
                            replaceName = DataManger.AllItems.Find(x => x.ItemNumber == replace.ItemNumber).Name;
                        }

                        InvItems.transform.Find(hldTextNameDrag).GetComponent<Text>().text = replaceName;
                        InvItems.transform.Find(hldTextNameReplace).GetComponent<Text>().text = moveName;

                        hldItemNumber = move.ItemNumber;
                        move.ItemNumber = replace.ItemNumber;
                        replace.ItemNumber = hldItemNumber;
                    }

                    if (GoodSwap)
                    {
                        Sprite hldSprite = objecttoreplace.GetComponentInParent<Image>().sprite;
                        objecttoreplace.GetComponentInParent<Image>().sprite = objectToDragImage.sprite;
                        objectToDragImage.sprite = hldSprite;
                    }

                    objectToDrag.position = OrgPosition;
                }
                else
                {
                    objectToDrag.position = OrgPosition;
                }
                objectToDragImage.raycastTarget = true;
                objectToDrag = null;
            }
            dragging = false;
            DataManger.populatePlayerStats();
            DataManger.populateEquipedDisplay();
        }
	}

    private GameObject getObjectUnderMouse()
    {
        var pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;
        EventSystem.current.RaycastAll(pointer, hitObjects);
        if (hitObjects.Count <= 0) return null;
        return hitObjects.First().gameObject;

    }

    private Transform GetDraggableTransformUnderMouse()
    {
        GameObject clickedObject = getObjectUnderMouse();
        if (clickedObject != null && (clickedObject.tag == Dragable_Tag || clickedObject.tag == Dragable_TagEuiped))
        {
            return clickedObject.transform;
        }

        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
                    Sprite hldSprite = objecttoreplace.GetComponentInParent<Image>().sprite;
                    objecttoreplace.GetComponentInParent<Image>().sprite = objectToDragImage.sprite;
                    objectToDragImage.sprite = hldSprite;                    
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

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ClickMovement : MonoBehaviour
{
    /// <summary>
    /// 1 - The speed of the ship
    /// </summary>

    public GameObject Player;
    public float speed = 20f;
    private Vector3 target;

    private Vector2 movement;
    private bool ClickMove = false;
    void Start()
    {

    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = Player.transform.position.z;
                ClickMove = true;
            }
            else
            {
                ClickMove = false;
            }
        }
        
    }

    void FixedUpdate()
    {
        if (ClickMove)
        {
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, target, speed * Time.deltaTime);
        }
    }
}

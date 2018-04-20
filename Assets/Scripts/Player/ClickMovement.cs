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
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = Player.transform.position.z;
                DataManger.movementObj.ClickMove = true;
                if (target.x > Player.transform.position.x)
                {
                    animator.SetFloat("hSpeed", 1);
                }
                else
                {
                    animator.SetFloat("hSpeed", -1);
                }
            }
            else
            {
                DataManger.movementObj.ClickMove = false;
            }
        }
        
    }

    void FixedUpdate()
    {
        if (DataManger.movementObj.ClickMove)
        {
            if (Player.transform.position != target)
            {
                Player.transform.position = Vector3.MoveTowards(Player.transform.position, target, speed * Time.deltaTime);
            }
        }
    }
}

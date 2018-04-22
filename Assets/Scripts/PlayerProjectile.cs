using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    public float ProjectileSpd;
    public float Damage = 0;
    GameObject Monster;
    Vector3 MonsterPos;
    float timeAlive = 0;


    // Use this for initialization
    void Start()
    {
        Monster = DataManger.movementObj.combatTarget;
        Vector3 vectorToTarget = Monster.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += ProjectileSpd * transform.right * .08f;
        timeAlive += Time.deltaTime;
        if (timeAlive >= 5)
        {
            //print("PlayerMissed!!");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("PlayerGotcha " + Damage.ToString());
        DataManger.movementObj.combatMonster.Health -= Damage;
        Destroy(gameObject);
    }
}

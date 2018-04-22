using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float ProjectileSpd; 
    public float Damage = 0;
    GameObject Player;
    Vector3 playerPos;
    float timeAlive = 0;
    
   
    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");
        Vector3 vectorToTarget = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);        
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position += transform.forward * 2f * Time.deltaTime;
        transform.localPosition += ProjectileSpd * transform.right * .08f;
        timeAlive += Time.deltaTime;
        if (timeAlive >= 5)
        {
            print("Missed!!");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Gotcha " + Damage.ToString() );        
        DataManger.playerobj.Health -= Damage;
        Destroy(gameObject);
    }
}

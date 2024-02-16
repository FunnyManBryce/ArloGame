using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    public LavaGolemAttack lavaGolemAttack;
    public Enemy enemyScript;
    public GameObject shockwave;
    public int shockwaveDamage = 30;
    public Transform Corner1;
    public Transform Corner2;
    public Transform Center;
    public Vector3 centerPoint;
    public Vector2 point1;
    public Vector2 point2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        point1 = new Vector2(Corner1.position.x, Corner1.position.y);
        point2 = new Vector2(Corner2.position.x, Corner2.position.y);
        centerPoint = new Vector3(Center.position.x, Center.position.y, Center.position.z);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = Center == null ? Vector3.zero : Center.position;
        Gizmos.DrawWireCube(position, centerPoint);
    }

    public void DetectColliders()
    {
        Debug.Log("why");
        foreach (Collider2D collider in Physics2D.OverlapAreaAll(point1, point2))
        {
            Debug.Log("yipee");
            Debug.Log(collider.name);
            Health health;
            if (health = collider.GetComponent<Health>())
            {
                health.GetHit(shockwaveDamage, transform.parent.gameObject);
            }
        }
    }
    /*private void OnCollisionStay2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            Health health;
            health = col.gameObject.GetComponent<Health>();
            health.GetHit(damage, shockwave);
        }
    }*/
}

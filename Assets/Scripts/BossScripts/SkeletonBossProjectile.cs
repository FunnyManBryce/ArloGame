using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBossProjectile : MonoBehaviour
{
    public GameObject projectile;

    public float travelSpeed;
    public float lifespan = 3f;

    public Vector2 projectileTrajectory;

    public int projectileNumber;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;
        if(lifespan <= 0 )
        {
            Destroy(projectile);
        }
        if(projectileNumber == 1)
        {
            projectileTrajectory = new Vector2(0, 1);
            transform.Translate(projectileTrajectory * Time.deltaTime * travelSpeed);
        }
        if (projectileNumber == 2)
        {
            projectileTrajectory = new Vector2(0, -1);
            transform.Translate(projectileTrajectory * Time.deltaTime * travelSpeed);
        }
        if (projectileNumber == 3)
        {
            projectileTrajectory = new Vector2(1, 0);
            transform.Translate(projectileTrajectory * Time.deltaTime * travelSpeed);
        }
        if (projectileNumber == 4)
        {
            projectileTrajectory = new Vector2(-1, 0);
            transform.Translate(projectileTrajectory * Time.deltaTime * travelSpeed);
        }
        if (projectileNumber == 5)
        {
            projectileTrajectory = new Vector2(0.5f, 0.5f);
            transform.Translate(projectileTrajectory * Time.deltaTime * travelSpeed);
        }
        if (projectileNumber == 6)
        {
            projectileTrajectory = new Vector2(0.5f, -0.5f);
            transform.Translate(projectileTrajectory * Time.deltaTime * travelSpeed);
        }
        if (projectileNumber == 7)
        {
            projectileTrajectory = new Vector2(-0.5f, 0.5f);
            transform.Translate(projectileTrajectory * Time.deltaTime * travelSpeed);
        }
        if (projectileNumber == 8)
        {
            projectileTrajectory = new Vector2(-0.5f, -0.5f);
            transform.Translate(projectileTrajectory * Time.deltaTime * travelSpeed);
        }
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Health health;
            health = col.gameObject.GetComponent<Health>();
            health.GetHit(damage, projectile);
            
        }
        Destroy(projectile);
    }
}

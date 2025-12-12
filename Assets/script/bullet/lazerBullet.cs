using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.UI.Image;

public class lazerBullet : MonoBehaviour
{
    public float distance;
    public int Damage;
    public float maxDistance=10f;
    int layerMask;
    float originalLength;
   
    void Start()
    {
       // Debug.Log("Lazer spawn");
       
        layerMask = LayerMask.GetMask("enemy");
        originalLength = GetComponent<SpriteRenderer>().sprite.bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        changeDistance();
    }
    void changeDistance()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up,maxDistance,layerMask);
        distance = maxDistance/originalLength;
       
       // Debug.DrawRay(transform.position, transform.up * maxDistance, Color.red);
        if (hit)
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            enemy.takeDamage(Damage);
            //Debug.Log("Distane" + distance);
            distance = hit.distance/originalLength ;
            Debug.Log("After distancce " + distance);
            //Debug.Log(hit.collider.name + " / scale before: " + transform.localScale.y);
            float dt= (enemy.transform.position.y- transform.position.y)/originalLength;
            Debug.Log("scale after: " + transform.localScale.y);
            Debug.Log("khoang cach den boss" + dt);
        }
        else
        {
            //Debug.Log("No hit");
        }
        transform.localScale = new Vector3(transform.localScale.x, distance, transform.localScale.z);

    }
}

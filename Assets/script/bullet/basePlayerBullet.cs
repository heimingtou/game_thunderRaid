using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basePlayerBullet : MonoBehaviour
{
    public float Damage;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); // toa do ao theo camera
        Destroyer(viewPos);
    }
    public void Move()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
    public virtual void Destroyer(Vector3 viewPos)
    {
        if (viewPos.y > 1 || viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0)
            Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemy : MonoBehaviour
{
    public float speed = 5f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameControl player = other.gameObject.GetComponent<GameControl>();

        if (player != null)
        {
            Time.timeScale = 0f;
            playGameManager.instance.showPopupLose();
        }
    }
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += 1*transform.up * speed * Time.deltaTime;
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); // toa do ao theo camera
        destroyBullet(viewPos);
    }
    void destroyBullet(Vector3 viewPos)
    {
        if (viewPos.y < 0)
            Destroy(gameObject);
    }
}

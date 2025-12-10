using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gif : MonoBehaviour
{
    Collider2D cl;
    float time=0;
    // Start is called before the first frame update
    private void Awake()
    {
         cl= GetComponent<Collider2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -1 * transform.up * Time.deltaTime * 1.5f;
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); // toa do ao theo camera
        destroyGif(viewPos);
        time += Time.deltaTime;
        if(time>0.05f)
            cl.isTrigger = true;
    }
    
    void destroyGif(Vector3 viewPos)
    {
        if (viewPos.y < 0)
            Destroy(gameObject);
    }
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        GameControl gameCtrl = other.gameObject.GetComponent<GameControl>();

        if (gameCtrl != null)
        {
            AudioManager.instance.playSFX(AudioManager.instance.putGif, 0.5f);
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlBackground : MonoBehaviour
{

    
    Vector3 spaw = new Vector3(0f, 17f, 2f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        transform.position += -1*transform.up * Time.deltaTime;
        if (viewPos.y < -1f)
            transform.position = spaw;
    }
}

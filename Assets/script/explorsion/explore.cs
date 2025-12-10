using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitExplore(0.5f));
    }

    // Update is called once per frame
    IEnumerator WaitExplore(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}

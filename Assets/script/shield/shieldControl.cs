using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject explore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        bulletEnemy bullet = other.GetComponent<bulletEnemy>();
        if (bullet != null)
        {
            Instantiate(explore, bullet.transform.position, Quaternion.identity);
            Debug.Log("destroy");
            Destroy(bullet.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
 
}
        // Shield hoạt động 5s yield return new WaitForSeconds(activeTime); shieldObject.SetActive(false); isActive = false; // Hồi chiêu 30s yield return new WaitForSeconds(cooldownTime); isCooldown = false;
        // Shield hoạt động 5s yield return new WaitForSeconds(activeTime); shieldObject.SetActive(false); isActive = false; // Hồi chiêu 30s yield return new WaitForSeconds(cooldownTime); isCooldown = false;


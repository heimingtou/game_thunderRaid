using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popup : MonoBehaviour
{
    private void OnDisable()
    {
        // Lệnh này giết chết TOÀN BỘ Tween đang dính trên người con Enemy này
        transform.DOKill();
    }
    // Start is called before the first frame update
    public void OnEnable()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1.5f, 1f).SetEase(Ease.OutBounce).SetUpdate(true);
        //Debug.Log("DotWeen");
    }
   
}

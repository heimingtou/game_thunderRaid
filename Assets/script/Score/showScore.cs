using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class showScore : MonoBehaviour
{
    public TMP_Text textScore;
    int lastScore;
    // Start is called before the first frame update
    public 
    void Start()
    {
        lastScore = saveManger.instance.Score;
        textScore.text = lastScore.ToString();
        transform.DORotate(new Vector3(0, 360, 360), 2f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        Debug.Log("Dotween dang hoat dong");
    }

    // Update is called once per frame
    void Update()
    {
        if(lastScore < saveManger.instance.Score)
        {
            
            lastScore = saveManger.instance.Score;
            textScore.text = lastScore.ToString();
            
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatNip : MonoBehaviour
{
    private Score ScoreText;
    private void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Score>();
    }

    private void Update()
    {
        gameObject.transform.Rotate(0, 0, 0.5f);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        ScoreText.ScorePlusOne();
        Destroy(gameObject);
    }
}

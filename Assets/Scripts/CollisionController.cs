using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    public static event Action OnCatNipConsumed; 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            SceneManager.LoadScene("Main");
        }
        else if (other.tag == "CatNip")
        {
            OnCatNipConsumed?.Invoke();
            Debug.Log("CatNip Yoinked!");
        }
    }
}

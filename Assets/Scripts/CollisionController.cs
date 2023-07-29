using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    public AudioSource hit_source;
    public AudioSource purr_source;

    public static event Action OnCatNipConsumed; 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            hit_source.Play();
            // SceneManager.LoadScene("Main");
        }
        else if (other.tag == "CatNip")
        {
            purr_source.Play();
            OnCatNipConsumed?.Invoke();
            Debug.Log("CatNip Yoinked!");
        }
    }
}

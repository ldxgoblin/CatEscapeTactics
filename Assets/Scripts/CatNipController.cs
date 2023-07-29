using System;
using System.Collections;
using UnityEngine;

public class CatNipController : MonoBehaviour
{
    [SerializeField] private LevelGenerator _levelGenerator;
    
    [SerializeField] private float _slowMotionFactor = .5f; // The amount to increase the speed by during the power-up.
    [SerializeField] private float _slowMotionDuration = 5.0f; // Duration of the power-up in seconds.
    [SerializeField] private float _lerpDuration = 1.0f; // Duration of the speed lerp when transitioning.
    
    private bool _isPowerUpActive = false;

    private void Awake()
    {
        CollisionController.OnCatNipConsumed += ActivatePowerUp;
    }

    private void OnDisable()
    {
        CollisionController.OnCatNipConsumed -= ActivatePowerUp;
    }
    
    // Call this method to activate the power-up.
    private void ActivatePowerUp()
    {
        if (!_isPowerUpActive)
        {
            _isPowerUpActive = true;
            StartCoroutine(DeactivatePowerUp());
        }
    }

    private IEnumerator DeactivatePowerUp()
    {
        if (_levelGenerator == null) yield break;
        
        float initialSpeed = _levelGenerator.GetLevelSpeed();
        float targetSpeed = initialSpeed * _slowMotionFactor;

        float elapsed = 0f;

        while (elapsed < _lerpDuration)
        {
            float newSpeed = Mathf.Lerp(initialSpeed, targetSpeed, elapsed / _lerpDuration);
            _levelGenerator.SetLevelSpeed(newSpeed);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the speed reaches the exact target value after the lerp.
        _levelGenerator.SetLevelSpeed(targetSpeed);

        yield return new WaitForSeconds(_slowMotionDuration - (_lerpDuration * 2f)); // Subtract lerpDuration twice to account for both transitions.

        elapsed = 0f;

        while (elapsed < _lerpDuration)
        {
            float newSpeed = Mathf.Lerp(targetSpeed, initialSpeed, elapsed / _lerpDuration);
            _levelGenerator.SetLevelSpeed(newSpeed);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the speed reaches the exact initial value after the lerp.
        _levelGenerator.SetLevelSpeed(initialSpeed);

        _isPowerUpActive = false;
    }
}

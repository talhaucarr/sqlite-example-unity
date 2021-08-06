using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    [SerializeField] [ShowOnly] private float _curHealth;

    private LevelSystem _levelSystem;
    

    private void Start()
    {
        _levelSystem = GetComponent<LevelSystem>();
        _curHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _curHealth -= damage;

        if (IsDead()){
            _curHealth = 0;
            Death();
        }
    }

    private bool IsDead()
    {
        return _curHealth < 0;
    }

    private void Death()
    {
        //TODOc
        _levelSystem.GainExp(15);
        CanvasManager.Instance.DisableAllGameScreen();
        GainManager.Instance.TriggerErrorMessage("Kazanc", "kazandin!");
        
    }
}

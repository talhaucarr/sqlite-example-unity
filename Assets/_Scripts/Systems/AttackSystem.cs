using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] private Image enemySprite;

    [SerializeField] private GameObject enemy;

    private HealthSystem _healthSystem;

    private void Start()
    {
        _healthSystem = enemy.GetComponent<HealthSystem>();
    }

    public void EnemyOnHit()
    {
        enemySprite.color = Color.white;
        _healthSystem.TakeDamage(15);
        StartCoroutine("ColorBack");
    }

    private IEnumerator ColorBack()
    {
        yield return new WaitForSeconds(.1f);
        enemySprite.color = Color.black;
    }
}

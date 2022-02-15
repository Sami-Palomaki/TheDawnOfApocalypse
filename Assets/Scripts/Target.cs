using UnityEngine;


public class Target : MonoBehaviour
{
    public float health = 50f;
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    public static int howManyKills = 0;
    private Enemy enemyControl;
    private Collider enemyCol;


    void Awake()
    {
        enemyControl = GetComponent<Enemy>();
    }

    void Start()
    {
        enemyCol = GetComponent<Collider>();
        
    }

    public void TakeDamage (float amount)           // Tässä vihollinen ottaa damagea
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()                      // Vihollinen kuolee, metodi
    {
        enemyCol.enabled = false;
        howManyKills+=1;                            // Laskee Game Over -ruudulle tapot
        UIManager.instance.killCount++;             // Lisää killCount muuttujaan tapon
        UIManager.instance.UpdateKillCounterUI();   // Päivittää metodikutsulla tappolaskurin
        enemyControl.Death();

        if(OnEnemyKilled != null)
        {
            OnEnemyKilled();
        }
    }
}

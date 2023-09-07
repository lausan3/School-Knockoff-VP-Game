using System.Collections;
using UnityEngine;
using TMPro;

class Dummy : MonoBehaviour
{
    [Header("Stats")] 
    public float startingHealth = 20f;
    public float attackDamage = 20f;
    public float IFrameTime = 0.02f;

    public float maxDistDelta = 0.01f;
    public Color damagedFlashColor = Color.red;

    private TextMeshProUGUI healthText;

    private Color originalColor;
    
    private float health;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        health = startingHealth;

        healthText.text = health.ToString();
        
        originalColor = gameObject.GetComponent<Material>().color;
    }

    public IEnumerator Hurt(float damage)
    {
        health -= damage;

        healthText.text = health.ToString();

        if (health <= 0)
        {
            Destroy(this);
        }
        
        // flash color
        Material mat = gameObject.GetComponent<Material>();
        mat.color = damagedFlashColor;

        yield return new WaitForSeconds(IFrameTime);

        mat.color = originalColor;
    }
}
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatHUD : MonoBehaviour
{
    public Text _healthText;

    private void Start()
    {
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.AddHealthSubscriber(HandleHealthChange);
    }

    private void HandleHealthChange(int maxHealth, int currentHealth)
    { 
        _healthText.text = "Player Health   " + currentHealth + " / " + maxHealth;
    }
}

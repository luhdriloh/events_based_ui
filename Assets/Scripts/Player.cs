using UnityEngine;

// this delegate references any method with the following signature type
// result: void
// parameter 1: int
// parameter 2 : int
public delegate void HealthChangeHandler(int maxHealth, int currentHealth);

public class Player : MonoBehaviour
{
    // create an event. handler will need to be of same signature as delegate
    public event HealthChangeHandler _healthChangeEvent;
    public int _maxHealth;
    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(8);
        }
    }

    private void TakeDamage(int amountOfDamage)
    {
        _currentHealth = Mathf.Max(_currentHealth - amountOfDamage, 0);
        OnHealthChange();

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    // EVENT FUNCTIONS //

    // event is called, call all subscribers 
    private void OnHealthChange()
    {
        if (_healthChangeEvent != null)
        {
            _healthChangeEvent(_maxHealth, _currentHealth);
        }
    }

    // add a subscriber to the event
    public void AddHealthSubscriber(HealthChangeHandler healthHandler)
    {
        _healthChangeEvent += healthHandler;
    }
}

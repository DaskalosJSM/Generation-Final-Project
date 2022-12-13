using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{

    private Image HealthBar;

    [Range(0.0f, 200.0f)]
    public float CurrentHealth;
    public float MaxHealt;
    public GameObject Player;
    private PlayerStats Playerstats;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
        Playerstats = Player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = Playerstats.Health;
        HealthBar.fillAmount = CurrentHealth / MaxHealt;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;


    public void UpdateHealth(float health)
    {        
        healthBar.value = health;
    }
}

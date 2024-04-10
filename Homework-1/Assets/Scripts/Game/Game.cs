using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    [SerializeField] string gameOverSceneName;
    [SerializeField] string winSceneName;
    [SerializeField] int keysToWin = 3;

    HUD hud;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        hud = GetComponentInChildren<HUD>();
        player = GetComponentInChildren<Player>();

        player.onHealthChanged = OnPlayerHealthChangedHandler;
        player.onHealthChanged += hud.OnHealthChangedHandler;
        player.onKeysChanged = OnPlayerKeysChangedHandler;
        player.onKeysChanged += hud.OnKeysChangedHandler;
    }

    void OnPlayerHealthChangedHandler(int newHealth)
    {
        if(newHealth <= 0) 
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }

    void OnPlayerKeysChangedHandler(int keyCount)
    {
        if(keyCount >= keysToWin)
        {
            SceneManager.LoadScene(winSceneName);
        }
    }
}

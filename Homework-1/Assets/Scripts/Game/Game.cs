using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    HUD hud;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        hud = GetComponentInChildren<HUD>();
        player = GetComponentInChildren<Player>();

        player.onDeath = OnPlayerDeathHandler;
        player.onHealthChanged = hud.onHealthChangedHandler;
        player.onKeysChanged = hud.onKeysChangedHandler;
    }

    void OnPlayerDeathHandler()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

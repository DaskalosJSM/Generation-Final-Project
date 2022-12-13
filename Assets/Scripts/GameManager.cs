using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState
{
    PrincipalMenu,
    Game,
    Village,
    Credits,
    GameOver,
    Store
}

public class GameManager : MonoBehaviour
{
    // Inicializo el singleton en el primer script 
    [SerializeField] GameObject menuPausa;
    public static GameManager sharedInstance;
    public bool isPlaying;
    // Declaración del estado del juego
    public GameState currentGameState = GameState.PrincipalMenu;

    public void Awake()
    {
        // que despierte y enfatizo con el siguiente fragmento
        // Singleton
        if (sharedInstance == null)
        {
            sharedInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Función encargado de iniciar la scena menú principal
    public void PrincipalMenu()
    {
        SetGameState(GameState.PrincipalMenu);
    }
    // Función encargado de iniciar la scena Game
    public void Game()
    {
        SetGameState(GameState.Game);
    }
    // Función encargado de iniciar la scena créditos
    public void Village()
    {
        SetGameState(GameState.Village);
    }
    // Función encargado de iniciar la scena controls
    public void Credits()
    {
        SetGameState(GameState.Credits);
    }
    // Función encargado de iniciar la scena de final de juego
    public void Store()
    {
        SetGameState(GameState.Store);
    }
     public void GameOver()
    {
        SetGameState(GameState.GameOver);
    }

    public void SetGameState(GameState newGameState)
    {
        this.currentGameState = newGameState;

        if (newGameState == GameState.PrincipalMenu)
        {
            //TODO: colocar la logica del menu
            SceneManager.LoadScene("Main Menu");
        }
        else if (newGameState == GameState.Game)
        {
            //TODO: colocar la logica del level game
            isPlaying = true;
            Time.timeScale = 1f;
            SceneManager.LoadScene("Dungeon");
            SceneManager.LoadScene("PlayerMovement", LoadSceneMode.Additive);
            SceneManager.LoadScene("UI Elements", LoadSceneMode.Additive);
        }
        else if (newGameState == GameState.Village)
        {
            //TODO: colocar la logica de la scena Village
            SceneManager.LoadScene("Village");
        }
        else if (newGameState == GameState.Credits)
        {
            //TODO: colocar la logica de la scena Credits
            SceneManager.LoadScene("Credits");
        }
        else if (newGameState == GameState.Store)
        {
            //TODO: colocar la logica de la scena Store
            SceneManager.LoadScene("Store");
        }
        else if (newGameState == GameState.GameOver)
        {
            //TODO: colocar la logica de la scena Store
            SceneManager.LoadScene("GameOver");
        }
    }
    public void Pausa()
    {
        //TODO: colocar la logica de la pausa
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
        isPlaying = false;
    }
    public void Reanudar()
    {
        //TODO: colocar la logica de la reanudar
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
        isPlaying = true;
    }
    public void Reiniciar()
    {
        //TODO: colocar la logica de la reiniciar
        Game();
    }
    public void Abandonar()
    {
        //TODO: colocar la logica de abandonar
        Time.timeScale = 1f;
        PrincipalMenu();
    }
}

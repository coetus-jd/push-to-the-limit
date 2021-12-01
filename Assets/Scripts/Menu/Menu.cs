using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;


public class Menu : MonoBehaviour
{
    public string cena;
    public string menu;
    public GameObject optionsPanel;
    public GameObject helpPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.X ) )
             SceneManager.LoadScene(menu);
    }

    public void StartGame()
    {   
        StartCoroutine(LoadingGame());
    }
    
    IEnumerator LoadingGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(cena);
    }

    public void QuitGame()
    {
        StartCoroutine(ExitGame());        
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(1);
        //Editor Unity
        // UnityEditor.EditorApplication.isPlaying = false;
        //Jogo Compilado
        Application.Quit();
    }

    public void ShowOptions()
    {
        StartCoroutine(ActiveOptions());
    }

    IEnumerator ActiveOptions()
    {
        yield return new WaitForSeconds(1);
        optionsPanel.SetActive(true);
    }

    public void BackToMenu()
    {        
        StartCoroutine(CloseOptions());
    }

    IEnumerator CloseOptions()
    {
        yield return new WaitForSeconds(1);
        optionsPanel.SetActive(false);
    }
    
    public void ShowHelp()
    {
        StartCoroutine(ActiveHelp());
    }

    IEnumerator ActiveHelp()
    {
        yield return new WaitForSeconds(1);
        helpPanel.SetActive(true);
    }

    public void BackToMenuHelp()
    {
        StartCoroutine(CloseHelp());
    }

    IEnumerator CloseHelp()
    {
        yield return new WaitForSeconds(1);
        helpPanel.SetActive(false);
    }

    

}

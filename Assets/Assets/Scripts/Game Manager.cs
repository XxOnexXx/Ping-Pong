using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void RestartGame()
    {
        if (Input.GetKey(KeyCode.R))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.LogWarning("Only works in build and not in unity");
    } 
}

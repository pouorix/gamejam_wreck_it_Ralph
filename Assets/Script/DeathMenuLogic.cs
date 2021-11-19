using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click_Restart()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
    }

    public void Click_Exit()
    {
        Application.Quit();
    }
}

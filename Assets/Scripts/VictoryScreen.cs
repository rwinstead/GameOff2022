using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{

    public void Replay()
    {
        SceneManager.LoadScene("TitlePage");
    }

}

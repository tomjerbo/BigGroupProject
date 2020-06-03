using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Quit");
        Invoke("QGame", 4.0f);
    }

    private void QGame()
    {
        Application.Quit();
    }
}

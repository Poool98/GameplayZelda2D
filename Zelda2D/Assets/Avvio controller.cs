using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Avviocontroller : MonoBehaviour

{
    public void BottunAvvio()
    {
        SceneManager.LoadScene(1);
    }
}
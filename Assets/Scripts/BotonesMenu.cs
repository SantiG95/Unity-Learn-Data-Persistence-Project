using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class BotonesMenu : MonoBehaviour
{
    [SerializeField] Button botonInicio;
    [SerializeField] Button botonSalir;

    public void empezar()
    {
        string nombreIngresado = GameObject.Find("Text").GetComponent<Text>().text;
        if(nombreIngresado == "")
        {
            GameObject.Find("Placeholder").GetComponent<Text>().color = Color.red;
            return;
        }

        GameObject.Find("DataManager").GetComponent<DataManager>().guardarNombreJugador(nombreIngresado);
        SceneManager.LoadScene(1);
    }

    public void salir()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

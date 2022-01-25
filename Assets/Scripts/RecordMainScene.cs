using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordMainScene : MonoBehaviour
{
    public Text recordText;
    private DataManager dataManager;

    // Start is called before the first frame update
    void Start()
    {
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        recordText.text = $"Record : {dataManager.darNombreRecord()} : {dataManager.darPuntajeRecord()}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

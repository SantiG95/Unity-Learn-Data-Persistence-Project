using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;

public class DataManager : MonoBehaviour
{
    public static DataManager instancia;
    private void Awake()
    {
        if (instancia)
        {
            Destroy(gameObject);
            return;
        }

        instancia = this;
        DontDestroyOnLoad(gameObject);

        cargarRecord();
    }

    [SerializeField] string nombreRecord = "";
    [SerializeField] int puntajeRecord = 0;

    [SerializeField] string nombreJugador;


    [System.Serializable]
    class SaveData
    {
        public string nombreRecord = "";
        public int puntajeRecord = 0;
    }

    public void guardarNombreJugador(string nombre)
    {
        nombreJugador = nombre;
    }

    public async void guardarRecord(int puntaje)
    {
        nombreRecord = nombreJugador;
        puntajeRecord = puntaje;

        SaveData saveData = new SaveData();
        saveData.nombreRecord = nombreJugador;
        saveData.puntajeRecord = puntaje;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        await Task.Yield();
    }

    public void cargarRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            nombreRecord = saveData.nombreRecord;
            puntajeRecord = saveData.puntajeRecord;
        }
        
    }

    public string darNombre()
    {
        return nombreJugador;
    }

    public string darNombreRecord()
    {
        return nombreRecord;
    }

    public int darPuntajeRecord()
    {
        return puntajeRecord;
    }
}

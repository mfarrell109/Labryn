using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour
{

    public static LocalizationManager instance;

    //private Dictionary<string, string> localizedText;
    private List<LocalizationData> localizedText;
    private bool isReady = false;
    private string missingTextString = "Localized text not found";

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadLocalizedText(string fileName)
    {
        //localizedText = new Dictionary<string, string>();
        localizedText = new List<LocalizationData>();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localizedText.Add(loadedData);
                GetLocalizedValue(loadedData.items[i].key, fileName, i);

            }
            Debug.Log( localizedText.Count);
        }
        else
        {
            Debug.LogError("Cannot find file!");
        }

        isReady = true;
    }

    public string GetLocalizedValue(string key, string fileName, int i)
    {
        string result = missingTextString;
        if (localizedText[i].items[i].key.Contains(key))
        {
            result = localizedText[i].items[i].key + " " +
                     localizedText[i].items[i].value + " " +
                     localizedText[i].items[i].val2;
        }
        Debug.Log(result.ToString());
        return result;

    }

    public bool GetIsReady()
    {
        return isReady;
    }

}
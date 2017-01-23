using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Character
{
    [System.Serializable]
    public class MonsterGenerator : MonoBehaviour
    {
        //private string missingTextString = "Localized text not found";
        private static MonsterGenerator _instance;
        private string fileName = "MonsterRoll.json";
        private List<LocalizationMonsterData> localizedText;
        private int i;

        void Start()
        {
            i = 0;
            BuildMonsterList(fileName);
        }
        // Singleton
        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }
        public void randomMonster()
        {
                i = Random.Range(0, 36);
        }
        public void BuildMonsterList(string fileName)
        {

        localizedText = new List<LocalizationMonsterData>();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(filePath))
        {
                string dataAsJson = File.ReadAllText(filePath);
                LocalizationMonsterData loadedData = JsonUtility.FromJson<LocalizationMonsterData>(dataAsJson);

                for (int i = 0; i < loadedData.items.Length; i++)
                {
                    localizedText.Add(loadedData);
                    GetLocalizedValue(loadedData.items[i].Class, fileName, i);
                }
                Debug.Log(loadedData.items.Length.ToString());
                //int num = Random.Range(1, 37);
            }
        else
        {
            Debug.LogError("Cannot find file!");
        }
        }

        public string GetLocalizedValue(int Class, string fileName, int i)
        {
            
            string result = "Missing String";

            if (localizedText[i].items[i].Class.Equals(Class))
            {
                result = "Class: " + localizedText[i].items[i].Class.ToString() + " " +
                         "Level: " + localizedText[i].items[i].Level.ToString() + " " +
                         "Attack: " + localizedText[i].items[i].Attack.ToString() + " " +
                         "Defense: " + localizedText[i].items[i].Defense.ToString() + " " +
                         "Surprise: " + localizedText[i].items[i].Surprise + " " +
                         "HP: " + localizedText[i].items[i].HP.ToString() + " " +
                "Exp: " + localizedText[i].items[i].Reward.Exp.ToString() + " " +
                "Jewels: " + localizedText[i].items[i].Reward.Jewels.ToString();
            }
            Debug.Log(result.ToString());
            return result;
        }



        public int getClass
        {
            get { return localizedText[i].items[i].Class; }                        
        }

        public int getLevel
        {
            get { return localizedText[i].items[i].Level; }
            set { localizedText[i].items[i].Level = value; }
        }

        public int getAttack
        {
            get { return localizedText[i].items[i].Attack; }
            set { localizedText[i].items[i].Attack = value; }
        }

        public int getDefense
        {
            get { return localizedText[i].items[i].Defense; }
            set { localizedText[i].items[i].Defense = value; }
        }
        public string getSurprise
        {
            get { return localizedText[i].items[i].Surprise; }
            set { localizedText[i].items[i].Surprise = value; }
        }

        public int getHP
        {
            get { return localizedText[i].items[i].HP; }
            set { localizedText[i].items[i].HP = value; }
        }

        public int getExp
        {
           get { return localizedText[i].items[i].Reward.Exp; }
        }

        public int getJewels
        {
            get { return localizedText[i].items[i].Reward.Jewels; }

        }
    }
}
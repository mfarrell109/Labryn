using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class MonsterGenerator : MonoBehaviour
    {
        private static MonsterGenerator _instance;
        private static List<MonsterStats> _monsters;

        public List<MonsterStats> MonsterList { get; set; }

        // Singleton
        private MonsterGenerator()
        {
            BuildMonsterList();
        }

        public static MonsterGenerator Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MonsterGenerator();

                return _instance;
            }
        }
        private void BuildMonsterList()
        {
            string json;
            using (StreamReader sr = new StreamReader(Path.GetFullPath(@"Assets\Scripts\MonsterRollSheet.json")))
            {
                json = sr.ReadToEnd();
            }

            _monsters = JsonUtility.FromJson<List<MonsterStats>>(json);

        }
    }
}

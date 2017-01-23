using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Assets.Scripts.Character
{
    [System.Serializable]
    public class MonsterStats
    {
        public int Class;
        public int Level;
        public string Surprise;
        public int HP;
        public int Attack;
        public int Defense;
        public Reward Reward;
    }

    [System.Serializable]
    public class LocalizationMonsterData
    {
        public MonsterStats[] items;
    }

}

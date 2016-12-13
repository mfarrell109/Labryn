using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Assets.Scripts.Character
{
    public class MonsterStats
    {
        public int Class { get; set; }
        public int Level { get; set; }
        public bool Supriseable { get; set; }
        public int HP { get; set; }
        public Reward Reward { get; set; }

    }
}

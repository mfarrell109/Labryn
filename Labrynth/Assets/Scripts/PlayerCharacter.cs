using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Character
{
    public class PlayerCharacter : CharacterBase
    {
        //Reward re = new Reward();
        public PlayerCharacter(int hp) : base(CharacterType.Player, hp)
        {
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public abstract class CharacterBase
    {
        private CharacterType _characterType;
        private int _hp = 0;
        private int _numberAttackDice;
        private int _numberDefenseDice;

        public CharacterBase(CharacterType type, int hitPoints = 100)
        {
            _characterType = type;
            _hp = hitPoints;
        }
        public int NumberOfAttackDice
        {
            get { return _numberAttackDice; }
            protected set { _numberAttackDice = value; }
        }

        public int NumberOfDefenseDice
        {
            get { return _numberDefenseDice; }
            protected set { _numberDefenseDice = value; }
        }

    }

    public enum CharacterType
    {
        Player,
        Monster
    }

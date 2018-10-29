﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[System.Serializable]

   public abstract class Building
    {
        protected int X_position;
        protected int Y_position;
        protected int Health;
        protected int Speed;
        protected int Faction;
        protected string Symbol;

        public Building() { }

        abstract public bool isDestoryed();
        abstract public string toString();

    }


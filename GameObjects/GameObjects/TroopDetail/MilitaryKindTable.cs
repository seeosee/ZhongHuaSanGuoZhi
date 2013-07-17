﻿namespace GameObjects.TroopDetail
{
    using GameObjects;
    using System;
    using System.Collections.Generic;

    public class MilitaryKindTable
    {
        public Dictionary<int, MilitaryKind> MilitaryKinds = new Dictionary<int, MilitaryKind>();

        public bool AddMilitaryKind(MilitaryKind militaryKind)
        {
            if (this.MilitaryKinds.ContainsKey(militaryKind.ID))
            {
                return false;
            }
            this.MilitaryKinds.Add(militaryKind.ID, militaryKind);
            return true;
        }

        public bool AddMilitaryKind(GameScenario scenario, int kind)
        {
            if (this.MilitaryKinds.ContainsKey(kind))
            {
                return false;
            }
            MilitaryKind militaryKind = scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(kind);
            if (militaryKind != null)
            {
                this.MilitaryKinds.Add(kind, militaryKind);
            }
            return true;
        }

        public bool RemoveMilitaryKind(GameScenario scenario, int kind)
        {
            if (!this.MilitaryKinds.ContainsKey(kind))
            {
                return false;
            }
            MilitaryKind militaryKind = scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(kind);
            if (militaryKind != null)
            {
                this.MilitaryKinds.Remove(militaryKind.ID);
            }
            return true;
        }

        public void Clear()
        {
            this.MilitaryKinds.Clear();
        }

        public MilitaryKind GetMilitaryKind(int militaryKindID)
        {
            MilitaryKind kind = null;
            this.MilitaryKinds.TryGetValue(militaryKindID, out kind);
            return kind;
        }

        public GameObjectList GetMilitaryKindList()
        {
            GameObjectList list = new GameObjectList();
            foreach (MilitaryKind kind in this.MilitaryKinds.Values)
            {
                list.Add(kind);
            }
            return list;
        }

        public void LoadFromString(MilitaryKindTable allMilitaryKinds, string militaryKindIDs)
        {
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = militaryKindIDs.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            MilitaryKind kind = null;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (allMilitaryKinds.MilitaryKinds.TryGetValue(int.Parse(strArray[i]), out kind))
                {
                    this.AddMilitaryKind(kind);
                }
            }
        }

        public string SaveToString()
        {
            string str = "";
            foreach (MilitaryKind kind in this.MilitaryKinds.Values)
            {
                str = str + kind.ID.ToString() + " ";
            }
            return str;
        }
    }
}


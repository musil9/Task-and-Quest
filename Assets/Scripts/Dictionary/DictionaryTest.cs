using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DictionaryTest : MonoBehaviour
{
    [Serializable]
    public class Item
    {
        public int code;
        public string name;

        public Item(int code, string name)
        {
            this.code = code;
            this.name = name;
        }

        public void Print()
        {
            Debug.Log($"code : {code}, name : {name}");
        }
    }
    
    public Item[] items = new Item[]
    {
        new Item(3, "��"),
        new Item(2, "��"),
        new Item(1, "��"),
         new Item(4, "��")
    };
     void Start()
    {
        Array.Sort(items, (x, y) => x.code.CompareTo(y.code));
        Array.ForEach(items, x => x.Print());
    }
}

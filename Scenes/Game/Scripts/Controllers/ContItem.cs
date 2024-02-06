using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;

public class ContItem : MonoBehaviour {

    public static ContItem I;
	public void Awake(){ I = this; }

    public List<DB_Items.Item> items;

    public void setup (){
        load_json ();
    }

    private void load_json (){
        string _filePath = Application.persistentDataPath + "/items.json";

        if (File.Exists(_filePath)) {
            string json = File.ReadAllText(filePath);
            items = JsonUtility.FromJson<List<DB_Items.Item>>(json);
        } else {
            save_json ();
        }
    }

    private void save_json (){
        string json = JsonUtility.ToJson(items);
        File.WriteAllText(filePath, json);
    }

    public void add_item (){
        
    }
}
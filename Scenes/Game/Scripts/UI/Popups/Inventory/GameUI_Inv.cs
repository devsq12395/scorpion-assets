using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI_Inv : MonoBehaviour
{
    
    public static GameUI_Inv I;
	public void Awake(){ I = this; }

    public GameObject goUI, goCanvas;

    public GameObject go;
    public TextMeshProUGUI tPage;
    public int NUMBER_OF_BUTTONS;
    
    public int pageCur, pageMax;
    public int NUM_OF_ITEMS_PER_PAGE;
    
    public string mode = "check";
        // Modes:
        // "hide" = UI is not showing
        // "check" = checking the inventory
        // "equip" = selecting an equippable item from the inventory

    void Start() {
        go.SetActive (true);

        

        go.SetActive (false);
    }

    void Update() {
        
    }
    
    public void show (string _mode){
        mode = _mode;
        go.SetActive (true);
        refresh_ui_list ();
    }

    public void hide (){
        go.SetActive (false);
        mode = "hide";
    }

    public void create_item (){
        GameObject _newItemUI = Instantiate(goUI, goCanvas.transform);
        RectTransform _transform = _newItemUI.GetComponent<RectTransform>();

        _transform.anchoredPosition = new Vector2(-110f - 100f * chars.Count, -118f);

        Image portImage = _newItemUI.transform.Find("Port").GetComponent<Image>();
        Image hpBarImage = _newItemUI.transform.Find("HPBar").transform.Find("BarValue_HP").GetComponent<Image>();
        Image mpBarImage = _newItemUI.transform.Find("MPBar").transform.Find("BarValue_MP").GetComponent<Image>();

        Char _newChar = new Char(_num, _newItemUI, portImage, hpBarImage, mpBarImage);
        chars.Add(_newChar);
    }
    
    // UI Manipulation
    public void switch_page (int _inc){
        pageCur += _inc;
        if (pageCur > pageMax)  pageCur = 0;
        if (pageCur < 0)        pageCur = pageMax;
    }
}

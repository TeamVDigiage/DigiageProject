using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveSystem : MonoBehaviour
{
    public SaveObject so;
    GameObject canvas;
    GameObject objCoin;
    int objCoins;
    [SerializeField] TextMeshProUGUI coin;
    int coins;
    //string coins;
    public List<GameObject> prefabs;
    private void Start()
    {
        so = SaveManager.Load();
        if (PlayerPrefs.HasKey("Coin"))
        {
            coin.text = PlayerPrefs.GetInt("Coin").ToString();
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                canvas = hit.transform.GetChild(0).gameObject;
                objCoin = canvas.transform.GetChild(1).gameObject;
                objCoins = Convert.ToInt32(objCoin.GetComponent<TextMeshProUGUI>().text);
                coins = Convert.ToInt32(coin.GetComponent<TextMeshProUGUI>().text);
                PlayerPrefs.SetInt("Coin", coins);
                if (hit.transform != null && coins >= objCoins)
                {
                    Debug.Log(objCoin);
                    so.objName = hit.transform.name;
                    SaveManager.Save(so);
                    coins -= objCoins;
                    coin.text = "" + coins;
                    PlayerPrefs.SetInt("Coin", coins);
                    objCoins = 0;
                    objCoin.GetComponent<TextMeshProUGUI>().text = "" + objCoins;
                    objCoin.gameObject.SetActive(false);
                    //Destroy(objCoin);
                    for (int i = 0; i < prefabs.Count; i++)
                    {
                        if (prefabs[i].name == objCoin.name)
                        {
                            Debug.Log("sada");
                            //objCoin.gameObject.SetActive(false);
                            prefabs[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "0";
                            prefabs[i].gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}

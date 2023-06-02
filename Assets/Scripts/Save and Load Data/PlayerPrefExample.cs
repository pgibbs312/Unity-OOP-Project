using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPrefExample : MonoBehaviour
{
    [SerializeField] TMP_InputField input;
    [SerializeField] TMP_Text txtDisplay;

    public void SaveData()
    {
        PlayerPrefs.SetString("Save_Data", input.text);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("Save_Data"))
        {
            txtDisplay.SetText(PlayerPrefs.GetString("Save_Data"));
        } else 
        {
            Debug.Log("No Data Found!");
        }
    }

    public void ClearData()
    {
        PlayerPrefs.DeleteKey("Save_Data");
    }
}

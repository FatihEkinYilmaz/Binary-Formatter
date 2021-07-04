using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour
{
    public InputField playerNameInput;
    public Slider playerAgeSlider;
    public Dropdown playerClassDropdown;

    string filePath;
    private void Awake()
    {
        filePath = Path.Combine(Application.dataPath, "playerdata.dat");
    }
    public void PlayerSaveData()
    {
        PlayerData playerData = new PlayerData();
        playerData.playerName = playerNameInput.text;
        playerData.playerAge = playerAgeSlider.value;
        playerData.playerClass = playerClassDropdown.value;

        Stream stream = new FileStream(filePath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(stream, playerData);
        stream.Close();
    }
    public void PlayerLoadData()
    {
        if (File.Exists(filePath))
        {
            Stream stream = new FileStream(filePath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            PlayerData data = (PlayerData)binaryFormatter.Deserialize(stream);
            stream.Close();

            playerNameInput.text = data.playerName;
            playerAgeSlider.value = data.playerAge;
            playerClassDropdown.value = data.playerClass;
        }
    }
}

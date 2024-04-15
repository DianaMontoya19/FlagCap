using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharactersManager : MonoBehaviour
{
    public GameObject[] characterPrefabs; 
    public GameObject[] characterIA;
    private Vector3 spawnPosition;

    void Start()
    {   
        spawnPosition = new Vector3 (3f,0f,0f);
        string selectedCharacterName = PlayerPrefs.GetString("SelectedCharacter");

        if (!string.IsNullOrEmpty(selectedCharacterName))
        {
            for (int i = 0; i < characterPrefabs.Length; i++)
            {
                if (characterPrefabs[i].name == selectedCharacterName)
                {
                    Instantiate(characterPrefabs[i], transform.position, Quaternion.identity);
                    print(selectedCharacterName);
                    break;
                }
            }

            if(selectedCharacterName == "Human_Knight")
            {
                Instantiate(characterIA[0], spawnPosition, Quaternion.identity);
            }

            if (selectedCharacterName == "Human_Barbarian")
            {
                Instantiate(characterIA[1], spawnPosition, Quaternion.identity);
            }

            if (selectedCharacterName == "Skeleton_Warrior")
            {
                print("Lo consegui 3");
            }

            if (selectedCharacterName == "Skeleton_Minion")
            {
                print("Lo consegui 4");
            }
        }
        else
        {
            Debug.LogError("No se ha seleccionado ningún personaje.");
        }
    }
}

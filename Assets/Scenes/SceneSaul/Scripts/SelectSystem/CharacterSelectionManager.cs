using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionManager : MonoBehaviour
{
   public static CharacterSelectionManager Instance;
   private GameObject selectedCharacterPrefab;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SelectCharacter(GameObject characterPrefab)
    {
        selectedCharacterPrefab = characterPrefab;
    }

    public void StartGame()
    {
        if (selectedCharacterPrefab != null)
        {
            PlayerPrefs.SetString("SelectedCharacter", selectedCharacterPrefab.name);
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainSceneSaul");
        }
        else
        {
            Debug.LogError("No se ha seleccionado ningún personaje.");
        }
    }
}

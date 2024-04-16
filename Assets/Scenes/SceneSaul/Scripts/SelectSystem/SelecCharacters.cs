using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelecCharacters : MonoBehaviour
{
    public GameObject Character;
    public void OnClickSelectKnight(GameObject Character)
    {
        CharacterSelectionManager.Instance.SelectCharacter(Character);
        CharacterSelectionManager.Instance.StartGame();
    }

}

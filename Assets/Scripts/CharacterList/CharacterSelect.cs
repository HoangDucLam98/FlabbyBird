using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characterList;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("characterSelected");

        characterList = new GameObject[transform.childCount];

        for(int i = 0; i < transform.childCount; i++) {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject bird in characterList)
        {
            bird.SetActive(false);
        }

        characterList[index].SetActive(true);
    }

    public void _ToggleRight()
    {
        characterList[index].SetActive(false);
        index++;
        if( index > characterList.Length - 1 ) {
            index = 0;
        }
        characterList[index].SetActive(true);
    }

    public void _ToggleLeft()
    {
        characterList[index].SetActive(false);
        index++;
        if( index < 0 ) {
            index = characterList.Length - 1;
        }
        characterList[index].SetActive(true);
    }

    public void _SetIndex()
    {
        PlayerPrefs.SetInt("characterSelected", index);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomCharacter : MonoBehaviour
{
    public List<GameObject> Characters;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        deactivateCharacters();
        activateRandomCharacter();
    }

    // Update is called once per frame
    void activateRandomCharacter()
    {
        Random.InitState(DateTime.Now.Minute * DateTime.Now.Millisecond);
        int random = Random.Range(0, Characters.Count);
        Characters[random].SetActive(true);
    }

    void deactivateCharacters()
    {
        foreach (GameObject c in Characters)
        {
            c.SetActive(false);
        }
    }
}

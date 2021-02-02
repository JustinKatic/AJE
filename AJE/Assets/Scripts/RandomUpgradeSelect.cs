using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomUpgradeSelect : MonoBehaviour
{
    [SerializeField] GameObject[] buttonsPos;
    [SerializeField] ListOfButtons PowerUpButtons;
    [SerializeField] GameObject Parent;
    Button button;

    int randomNum;


    private void OnEnable()
    {
        for (int i = 0; i < buttonsPos.Length; i++)
        {
            randomNum = Random.Range(0, PowerUpButtons.List.Count);
            button = Instantiate(PowerUpButtons.List[randomNum], buttonsPos[i].transform.position, buttonsPos[i].transform.rotation, Parent.transform);
            button.onClick.AddListener(RemoveButtonFromList);
        }
    }

    private void RemoveButtonFromList()
    {
        PowerUpButtons.List.RemoveAt(randomNum);
    }
}



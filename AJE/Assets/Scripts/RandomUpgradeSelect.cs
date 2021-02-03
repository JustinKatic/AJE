using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomUpgradeSelect : MonoBehaviour
{
    [SerializeField] GameObject[] buttonsPos;
    [SerializeField] List<Button> PowerUpButtons;
    [SerializeField] GameObject Parent;
    Button button1, button2, button3;

    int randomNum1, randomNum2, randomNum3;



    private void OnEnable()
    {
        List<int> UsedNumbers = new List<int>();
        UsedNumbers.Clear();

        //button 1
        randomNum1 = Random.Range(0, PowerUpButtons.Count);
        while (UsedNumbers.Contains(randomNum1))
        {
            randomNum1 = Random.Range(0, PowerUpButtons.Count);
            if (PowerUpButtons.Count <= 3)
                break;
        }
        UsedNumbers.Add(randomNum1);

        button1 = Instantiate(PowerUpButtons[randomNum1], buttonsPos[0].transform.position, buttonsPos[0].transform.rotation, Parent.transform);
        button1.onClick.AddListener(delegate { RemoveButton1FromList(randomNum1); });

        //button 2
        randomNum2 = Random.Range(0, PowerUpButtons.Count);
        while (UsedNumbers.Contains(randomNum2))
        {
            randomNum2 = Random.Range(0, PowerUpButtons.Count);
            if (PowerUpButtons.Count <= 3)
                break;
        }
        UsedNumbers.Add(randomNum2);

        button2 = Instantiate(PowerUpButtons[randomNum2], buttonsPos[1].transform.position, buttonsPos[1].transform.rotation, Parent.transform);
        button2.onClick.AddListener(delegate { RemoveButton2FromList(randomNum2); });

        //button 3
        randomNum3 = Random.Range(0, PowerUpButtons.Count);
        while (UsedNumbers.Contains(randomNum3))
        {
            randomNum3 = Random.Range(0, PowerUpButtons.Count);
            if (PowerUpButtons.Count <= 3)
                break;
        }
        UsedNumbers.Add(randomNum3);

        button3 = Instantiate(PowerUpButtons[randomNum3], buttonsPos[2].transform.position, buttonsPos[2].transform.rotation, Parent.transform);
        button3.onClick.AddListener(delegate { RemoveButton3FromList(randomNum3); });
    }

    private void RemoveButton1FromList(int index)
    {
        PowerUpButtons.RemoveAt(index);
    }
    private void RemoveButton2FromList(int index)
    {
        PowerUpButtons.RemoveAt(index);
    }
    private void RemoveButton3FromList(int index)
    {
        PowerUpButtons.RemoveAt(index);
    }
}



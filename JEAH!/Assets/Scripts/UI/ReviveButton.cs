using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveButton : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject defeatScreen;
    [SerializeField] GameObject shopScreen;
    PlayerHealthManager healthManager;
    [SerializeField] GameEvent playerHealthIncreaseEvent;
    [SerializeField] IntVariable hearts;
    [SerializeField] GameStateManager stateManager;
    [SerializeField] BoolVariable playerDead;
    [SerializeField] GameObject joystick;
    [SerializeField] GameEvent playerInvincibleEvent;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthManager = player.GetComponent<PlayerHealthManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RevivePlayer()
    {
        if (hearts.Value >= 1)
        {
            playerDead.Value = false;
            healthManager.Revive();
            hearts.Value -= 1;
            Debug.Log("hearts remaining = " + hearts.Value);
            playerInvincibleEvent.Raise();
            defeatScreen.SetActive(false);
            shopScreen.SetActive(false);
            stateManager.ResumeGame();
            joystick.SetActive(true);
            playerHealthIncreaseEvent.Raise();
        }
        else
        {
            Debug.Log("not enough hearts, opening shop page");
            shopScreen.SetActive(true);          
        }
    }
}

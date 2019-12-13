using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public ArrayList playerName = PlayerNaming._.getPlayerName();
    
    // Start is called before the first frame update
    public static List<Player> playerList = new List<Player>();

    public GameObject[] koordinat;

    void Start()
    {
        Debug.Log("=========GamePlay============");
        playerList = GivingRole.playerList;
        for (int i = 0; i < playerList.Count; i++) {

            Debug.Log(playerList[i].getPlayerName());
            Debug.Log(playerList[i].getPlayerRole().getRoleName());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

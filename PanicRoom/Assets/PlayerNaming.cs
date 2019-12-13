using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerNaming : MonoBehaviour
{
    public InputField [] playerName;
    public static PlayerNaming _;
    
    // Start is called before the first frame update
    void Start()
    {
        _ = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void log() {
        var playerName = getPlayerName();
        for (int i = 0; i < 5; i++) {
            Debug.Log(playerName[i]);
        }
            
          }

    

    public void loadGivingRoleScene() {
        log();
        SceneManager.LoadSceneAsync("GivingRole");

    }

    public ArrayList getPlayerName() {
        //get text from textField
        var data = new ArrayList();
        foreach(var i in playerName)
        {
            data.Add(i.text);
        }
       
        return data;
    }
}

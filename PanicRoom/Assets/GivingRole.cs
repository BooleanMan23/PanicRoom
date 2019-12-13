using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GivingRole : MonoBehaviour

{
    public SpriteRenderer roleSprite;
    public Text playerText;
    public Text roleDescription;
    public Button nextButton;

    public ArrayList playerName = PlayerNaming._.getPlayerName();
    public static List<Player> playerList = new List<Player>();

    public Sprite[] sprites;
    public Sprite[] playerPawnSprite;
    int countTombol = 0;
    int countRole = 0;

    public static GivingRole givingRole;
    void Start()
    {
        givingRole = this;
        Debug.Log("Giving Role Scene");
        PlayerNaming._.log();
        getRole();
        playerText.text = "Send The Device To : "+playerList[0].getPlayerName();
        roleSprite.sprite = null;
        nextButton.GetComponentInChildren<Text>().text = "Open";

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void tombol() {

       
        if (countRole >= playerList.Count)
        {
            nextButton.GetComponentInChildren<Text>().text = "To Gameplay";
            SceneManager.LoadSceneAsync("GameScene");

        }

        if (countTombol % 2 == 0)
        {
            roleDescription.text = playerList[countRole].getPlayerRole().getRoleDescription();
            roleSprite.sprite = playerList[countRole].getPlayerRole().roleImage;
            nextButton.GetComponentInChildren<Text>().text = "Close";
            countTombol = countTombol + 1;
            countRole = countRole + 1;
            Debug.Log("Count Tombol = " + countTombol);

        }
       

        else
        {
            roleDescription.text = "";
            roleSprite.sprite = null;
            playerText.text = "Send The device to : " + playerList[countRole].getPlayerName();
            countTombol = countTombol + 1;
            nextButton.GetComponentInChildren<Text>().text = "Open";
             Debug.Log("Count Tombol = " + countTombol);
        }


    }

    public List<Player> getPlayers() {
        return playerList;
    }



    public void getRole()
    {

        Role lazarus = new Role("Lazarus", "Description : Lazarus", sprites[1]);
        Role hitman = new Role("Hitman", "Description : hitman", sprites[0]);
        Role gunner = new Role("Gunner", "Description : gunner", sprites[4]);
        Role supply = new Role("Supply", "Description : Supply", sprites[3]);
        Role serialKiller = new Role("Serial Killer", "Description : Serial Killer", sprites[2]);
    
        ArrayList roleList = new ArrayList();

        roleList.Add(lazarus);
        roleList.Add(hitman);
        roleList.Add(gunner);
        roleList.Add(supply);
        roleList.Add(serialKiller);

        for (var i = 0; i < 5; i++)
        {
            Role role = (Role)roleList[Random.Range(0, roleList.Count)];
            roleList.Remove(role);
            Player player = new Player(playerName[i].ToString(), role, playerPawnSprite[i]);
            Debug.Log("Player Name : " + player.getPlayerName() + "Role : " + player.getPlayerRole().getRoleName());
            playerList.Add(player);

        }


    }

    



}
[System.Serializable]
public class Player
{
    private string playerName;
    private Role playerRole;
    public Sprite playerPawnSprite;
    public int koordinatX;
    public int KoordinatY;

    public void setKoordinatX(int koordinatX) {
        this.koordinatX = koordinatX;
    }

    public void setKoordinatY(int koordinatY) {
        this.KoordinatY = koordinatY;
    }

    public int getKoordinatX() {
        return this.koordinatX;
    }

    public int getKoordinatY() {
        return this.KoordinatY;
    }


    public Player(string playerName, Role playerRole, Sprite playerPawnSprite)
    {
        this.playerName = playerName;
        this.playerRole = playerRole;
        this.playerPawnSprite = playerPawnSprite;
    }

    public string getPlayerName()
    {
        return this.playerName;
    }

    public Role getPlayerRole()
    {
        return this.playerRole;
    }

    public void setPlayerName(string playerName)
    {
        this.playerName = playerName;
    }

    public void setPlayerRole(Role playerRole)
    {
        this.playerRole = playerRole;
    }
}

public class Role
{

    private string roleName;
    private string roleDescription;
    public Sprite roleImage;


    public Role(string roleName, string roleDescription, Sprite roleImage)
    {
        this.roleName = roleName;
        this.roleDescription = roleDescription;
        this.roleImage = roleImage;
    }

    public string getRoleName()
    {
        return this.roleName;
    }

    public string getRoleDescription()
    {
        return this.roleDescription;
    }



    public void setRoleName(string roleName)
    {
        this.roleName = roleName;
    }

    public void setRoleDescription(string roleDescription)
    {
        this.roleDescription = roleDescription;
    }
}

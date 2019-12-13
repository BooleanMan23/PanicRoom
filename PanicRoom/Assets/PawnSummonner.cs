using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnSummonner : MonoBehaviour
{
    public static int count;
    static List<string> koordinatTempati = new List<string>();
    public static Dictionary<string, Vector3> gridList = new Dictionary<string,Vector3>();
    public static List<GameObject> playerList = new List<GameObject>();
    private void Start()
    {
        var PawnList = FindObjectsOfType<PawnSummonner>();
        foreach(var pawn in PawnList)
        {
            gridList.Add(pawn.name, pawn.transform.position);
        }
    }



    private void OnMouseDown()
    {
        if (count < GivingRole.playerList.Count && checkTempati(gameObject.name) != true) {
            //check
            var pawn = Instantiate(new GameObject(), transform);
            pawn.AddComponent<SpriteRenderer>();
            
            pawn.GetComponent<SpriteRenderer>().sprite = GivingRole.playerList[count].playerPawnSprite;
            pawn.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
            playerList.Add(pawn);
            Debug.Log(gameObject.name);
            koordinatTempati.Add(gameObject.name);
            int koordinatX = System.Convert.ToInt32(gameObject.name.Substring(0,1));
            int koordinatY = System.Convert.ToInt32(gameObject.name.Substring(1, 1));
            GivingRole.playerList[count].setKoordinatX(koordinatX);
            GivingRole.playerList[count].setKoordinatX(koordinatY);
            Debug.Log(GivingRole.playerList[count].getKoordinatX());
            Debug.Log(GivingRole.playerList[count].getKoordinatY());
            count = count + 1;
        }
       
    }

    public static void Normalize()
    {
        if(count >= GivingRole.playerList.Count)
        {
            count = 0;
        }
    }

    public bool checkTempati(string koordinat) {
        bool checkTempat = false;
        for (int i = 0; i < koordinatTempati.Count; i++) {
            if (koordinat.Equals(koordinatTempati[i])) {

                checkTempat = true;
            }

        }
        return checkTempat;
    }

   
}

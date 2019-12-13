using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class moveButtin : MonoBehaviour
{
    public Direction arah;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Move();
    }

    public void Move()
    {
        PawnSummonner.Normalize();

        var pawnPojo = GivingRole.playerList[PawnSummonner.count];
        pawnPojo.koordinatX =+ 1;

        var pawnGameObject = PawnSummonner.playerList[PawnSummonner.count];
        pawnGameObject.transform.position = PawnSummonner.gridList[pawnPojo.getKoordinatX()+""+pawnPojo.getKoordinatY()];
        PawnSummonner.count++;
    }

    
}

public enum Direction
{
    Right,Left,Bottom,Up
}

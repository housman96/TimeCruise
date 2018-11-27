using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiseEnPlaceEcoute : MonoBehaviour
{
    public Transform placeCiblePaul;
    public Transform placeCibleMaurice;

    public AIDestinationSetter PaulDestination;
    public AIDestinationSetter MauriceDestination;
    public void StartMovement()
    {
        MauriceDestination.target = placeCibleMaurice;
        PaulDestination.target = placeCiblePaul;
    }
}

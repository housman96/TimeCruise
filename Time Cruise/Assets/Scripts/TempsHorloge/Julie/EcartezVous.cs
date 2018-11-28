using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcartezVous : MonoBehaviour
{
    public Transform PierreEcarte;
    public Transform JulieEcarte;

    public AIDestinationSetter JulieDestination;
    public AIDestinationSetter PierreDestination;

    public void StartMovement()
    {
        JulieDestination.target = JulieEcarte;
        PierreDestination.target = PierreEcarte;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManageTrigger : MonoBehaviour
{
    public static bool _canloadnextStage;
    public void GMTrigger()
    {
        _canloadnextStage = true;
    }
}

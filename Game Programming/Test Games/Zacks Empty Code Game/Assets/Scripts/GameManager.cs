using UnityEngine;
using UnityEngine.Events;

// Game Manager
/*
    This script should be a game specific overall controller.

    This script should be how game managers should talk to each other
    and send information to each other

    It should also control when the game starts, and when and how a game
    should end.
*/

public class GameManager : MonoBehaviour
{
    public UnityEvent onRoundStart, onRoundReset, onPlayerWin, onGhostWin;

    
    public void StartRound(){
        onRoundStart.Invoke();
    }

    public void RoundReset(){
        onRoundReset.Invoke();
    }

    public void GhostWin(){
        onGhostWin.Invoke();
    }

    public void PlayerWin(){
        onPlayerWin.Invoke();
    }


}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CoroutineBehavior : MonoBehaviour
{
    public UnityEvent startCountEvent, repeatCountEvent, endCountEvent, repeatUntilFalse;
    public IntData counterNum;
    private bool canRun;
    public float seconds = 3.0f;
    private WaitForSeconds wfsObj;
    private WaitForFixedUpdate wffuObj;

    public bool CanRun { get => canRun; set => canRun = value; }

    // Start is called before the first frame update

    private void Awake()
    {
        wfsObj = new WaitForSeconds(seconds);
        wffuObj = new WaitForFixedUpdate();
    }

    public void startCounting(){
        StartCoroutine(Counting());
    }

    private IEnumerator Counting()
    {
        
        startCountEvent.Invoke();
        yield return wfsObj;
        while (counterNum.value > 0)
        {
            repeatCountEvent.Invoke();
            Debug.Log(counterNum.value);
            counterNum.value --;
            yield return wfsObj;
        }

        endCountEvent.Invoke();

    }

    public void StartRepeatUntilFalse(){
        CanRun = true;
        StartCoroutine(RepeatUntilFalse());
    }



    private IEnumerator RepeatUntilFalse(){
        yield return wfsObj;
        while(CanRun)
        {
            repeatUntilFalse.Invoke();
            yield return wfsObj;
        }
    }
}

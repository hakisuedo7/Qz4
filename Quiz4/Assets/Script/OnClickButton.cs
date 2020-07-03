using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickButton : MonoBehaviour
{
    Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickOn()
    {
        controller.BlurOn();
    }

    public void ClickOff()
    {
        controller.BlurOff();
    } 
}

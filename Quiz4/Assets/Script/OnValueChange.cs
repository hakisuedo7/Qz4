using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnValueChange : MonoBehaviour
{
    [SerializeField] private Dropdown dropdown;
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

    public void Select()
    {
        controller.SelectState(dropdown.value);
    }

    public void Speed(float value)
    {
        controller.SetSpeed(value);
    }
}

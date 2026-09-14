using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private KeyCode[] keys = {
        KeyCode.A,
        KeyCode.B,
        KeyCode.C,
        KeyCode.D,
        KeyCode.E,
        KeyCode.F,
        KeyCode.G,
        KeyCode.H,
        KeyCode.I,
        KeyCode.J,
        KeyCode.K,
        KeyCode.L,
        KeyCode.M,
        KeyCode.N,
        KeyCode.O,
        KeyCode.P,
        KeyCode.Q,
        KeyCode.R,
        KeyCode.S,
        KeyCode.T,
        KeyCode.U,
        KeyCode.V,
        KeyCode.W,
        KeyCode.X,
        KeyCode.Y,
        KeyCode.Z,
        KeyCode.Keypad0,
        KeyCode.Keypad1,
        KeyCode.Keypad2,
        KeyCode.Keypad3,
        KeyCode.Keypad4,
        KeyCode.Keypad5,
        KeyCode.Keypad6,
        KeyCode.Keypad7,
        KeyCode.Keypad8,
        KeyCode.Keypad9
    };

    private WordleController wordle;

    private void Start() {
        wordle = this.gameObject.GetComponent<WordleController>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode key in keys){
            if (Input.GetKeyDown(key)){
                wordle.SetLetter(key.ToString()[0]);
            }
        }
    }
}

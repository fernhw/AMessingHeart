using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merry:MonoBehaviour {
    public GameObject
        mouthSad,
        mouthHappy,
        heart1,
        heart2,
        heart3,
        eyesClosed,
        eyesClosedHappy,
        eyesSad,
        eyesWorried,
        whiteBG;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}

public enum MerryStatus {
    REGULAR,
    HAPPY,
    SAD,
    WORRIED,
    JOYFUL
}
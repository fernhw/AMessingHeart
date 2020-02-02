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
        heart4,
        eyesClosed,
        eyesClosedHappy,
        eyesSad,
        eyesWorried,
        whiteBG;

    public void SetMerry (MerryStatus emotion = MerryStatus.REGULAR, HeartStatus heartStatus = HeartStatus.ONE) {
        EraseAll();
        switch (emotion) {
        case MerryStatus.REGULAR:
            //
        break;
        case MerryStatus.HAPPY:
        mouthHappy.SetActive(true);
        break;
        case MerryStatus.SAD:
        mouthSad.SetActive(true);
        eyesSad.SetActive(true);
        break;
        case MerryStatus.WORRIED:
        mouthSad.SetActive(true);
        eyesWorried.SetActive(true);
        break;
        case MerryStatus.JOYFUL:
        mouthHappy.SetActive(true);
        eyesClosedHappy.SetActive(true);
        break;
        }

        switch (heartStatus) {
        case HeartStatus.ONE:
        heart1.SetActive(true);
        break;
        case HeartStatus.TWO:
        heart2.SetActive(true);
        break;
        case HeartStatus.THREE:
        heart3.SetActive(true);
        break;
        case HeartStatus.FOUR:
        heart4.SetActive(true);
        break;
        }

    }

    void EraseAll () {
        mouthSad.SetActive(false);
        mouthHappy.SetActive(false);
        heart1.SetActive(false);
        heart2.SetActive(false);
        heart3.SetActive(false);
        heart4.SetActive(false);
        eyesClosed.SetActive(false);
        eyesClosedHappy.SetActive(false);
        eyesSad.SetActive(false);
        eyesWorried.SetActive(false);
        whiteBG.SetActive(false);
    }
}

public enum MerryStatus {
    REGULAR,
    HAPPY,
    SAD,
    WORRIED,
    JOYFUL
}

public enum HeartStatus {
    WAITING, ONE,TWO,THREE,FOUR
}
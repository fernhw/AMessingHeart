using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpeechControl {
    List<Speech> speechList;
    public int currentSpeechID = 0;

    public SpeechPackage Start (List<Speech> speechList) {
        this.speechList = speechList;
        currentSpeechID = 0;
        return new SpeechPackage(speechList[0], true);
    }

    public SpeechPackage Current () {
        int size = speechList.Count;
        if (currentSpeechID >= size) {
            return new SpeechPackage(new Speech(), false);
        }
        return new SpeechPackage(speechList[currentSpeechID], true);
    }

    public SpeechPackage Continue () {
        currentSpeechID++;
        return Current();
    }
}

public class SpeechPackage {
    public Speech speech;
    public bool isValidSPeech;
    public SpeechPackage (Speech speech,
    bool isValidSPeech) {
        this.speech = speech;
        this.isValidSPeech = isValidSPeech;
    }

}
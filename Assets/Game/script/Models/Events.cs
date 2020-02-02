using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {

    public static List<Speech> bearCutscene = new List<Speech> {
        new Speech("It's a lonely bear", emotion: MerryStatus.WORRIED),
        new Speech("I wonder why it's there?"),
        new Speech(type: EventType.BLACK_SCREEN_TRANSITION)
    };

    
   

}

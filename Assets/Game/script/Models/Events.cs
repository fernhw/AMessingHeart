using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {

    public static List<Speech> bearCutscene = new List<Speech> {
        new Speech("It's a lonely bear.", emotion: MerryStatus.WORRIED),
        new Speech("Something feels off."),
        new Speech("It's missing an eye.", emotion: MerryStatus.SAD)

    };

    public static List<Speech> dollCutscene = new List<Speech> {
        new Speech("Ah music box!", emotion: MerryStatus.HAPPY),
        new Speech("You decided to wind the music box.", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("", emotion: MerryStatus.HAPPY),
        new Speech("", emotion: MerryStatus.REGULAR),
        new Speech("A silent song.", emotion: MerryStatus.SAD),
    };

    public static List<Speech> frameCutscene = new List<Speech> {
        new Speech("A picture of... legs.", emotion: MerryStatus.REGULAR),
        new Speech("You'd think they'd take pictures of their faces.", emotion: MerryStatus.WORRIED),
        new Speech("To each their own.", emotion: MerryStatus.AWRY),
    };
}

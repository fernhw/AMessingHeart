using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {

    public static List<Speech> bearCutscene = new List<Speech> {
        new Speech("Teddy bear!", emotion: MerryStatus.HAPPY),
        new Speech("Something feels off.", emotion: MerryStatus.AWRY),
        new Speech("..", emotion: MerryStatus.SAD),
        new Speech("It's missing an eye.", emotion: MerryStatus.WORRIED)
    };
    public static List<Speech> bearCutsceneInv = new List<Speech> {
        new Speech("I think I can give you an eye buddie."),
        new Speech(type:EventType.OPEN_INVENTORY)
    };

    public static List<Speech> dollCutscene = new List<Speech> {
        new Speech("Ah music box!", emotion: MerryStatus.HAPPY),
        new Speech("You decided to wind the music box.", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("", emotion: MerryStatus.HAPPY),
        new Speech("", emotion: MerryStatus.REGULAR),
        new Speech("...A silent song.", emotion: MerryStatus.SAD)
    };
    public static List<Speech> dollCutsceneInv = new List<Speech> {
        new Speech("Maybe I can piece it back together"),
        new Speech(type:EventType.OPEN_INVENTORY)
    };

    public static List<Speech> frameCutscene = new List<Speech> {
        new Speech("A picture of... legs.", emotion: MerryStatus.REGULAR),
        new Speech("You'd think they'd take pictures of their faces.", emotion: MerryStatus.WORRIED),
        new Speech("To each their own.", emotion: MerryStatus.AWRY),
    };
    public static List<Speech> frameCutsceneInv = new List<Speech> {
        new Speech("There's ways to fix this avant-garde photo.", emotion: MerryStatus.HAPPY),
        new Speech(type:EventType.OPEN_INVENTORY)
    };


    public static List<Speech> ButtonFlavor = new List<Speech> {
        new Speech("Looks like a cookie, but it's clearly a button.", emotion: MerryStatus.REGULAR),
        new Speech("Maybe. I can attatch it to something.", emotion: MerryStatus.REGULAR),
        new Speech("Obtained: Button", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("button",type:EventType.AQUIRE_ITEM)
    };
    public static List<Speech> Photo1Flavor = new List<Speech> {
        new Speech("A torn Photo of a man.", emotion: MerryStatus.REGULAR),
        new Speech("I feel this...", emotion: MerryStatus.REGULAR),
        new Speech("", emotion: MerryStatus.SAD),
        new Speech("This girl kind-of looks like me.", emotion: MerryStatus.REGULAR),
        new Speech("Obtained: Photo of a Man", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("photo_1",type:EventType.AQUIRE_ITEM)        
    };
    public static List<Speech> Photo2Flavor = new List<Speech> {
        new Speech("A torn Photo of a woman.", emotion: MerryStatus.REGULAR),
        new Speech("Obtained: Photo of a Woman", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("photo_2",type:EventType.AQUIRE_ITEM)
    };
    public static List<Speech> stringStringFlavor = new List<Speech> {
        new Speech("A string and needle.", emotion: MerryStatus.JOYFUL),
        new Speech("Perfect to fix about anything", emotion: MerryStatus.HAPPY),
        new Speech("Almost anything", emotion: MerryStatus.WORRIED),
        new Speech("Obtained: Thread", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("thread",type:EventType.AQUIRE_ITEM)
    };
    public static List<Speech> ballerinaFlavor = new List<Speech> {
        new Speech("A ballerina.", emotion: MerryStatus.WORRIED),
        new Speech("A beautiful ballerina.", emotion: MerryStatus.WORRIED),
        new Speech("I feel it belongs to something.", emotion: MerryStatus.WORRIED),
        new Speech("Obtained: A Ballerina", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("ballerina",type:EventType.AQUIRE_ITEM)
    };
    public static List<Speech> winderFlavor = new List<Speech> {
        new Speech("...", emotion: MerryStatus.AWRY),
        new Speech("It's a weird thing this one.", emotion: MerryStatus.WORRIED),
        new Speech("Maybe I can open a bottle with it.", emotion: MerryStatus.HAPPY),
        new Speech("Obtained: Winder", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("winder",type:EventType.AQUIRE_ITEM)
    };


    public static List<Speech> bearButton = new List<Speech> {
        new Speech("This will work as an eye", emotion: MerryStatus.AWRY),
        new Speech("winder",type:EventType.OPEN_INVENTORY_2ND_STAGE)
    };

    public static List<Speech> time = new List<Speech> {
        new Speech("There's a time and place", emotion: MerryStatus.WORRIED, type: EventType.DIMMED_DIALOG)
    };


    public static List<Speech> what = new List<Speech> {
        new Speech("You created an abomination", emotion: MerryStatus.WORRIED, type: EventType.BLACK_SCREEN_DIALOG)
    };

    public static List<Speech> fixBear = new List<Speech> {
        new Speech("I will fix you up little fellow", emotion: MerryStatus.HAPPY),
        new Speech("Snip", emotion: MerryStatus.HAPPY, type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("Snip", emotion: MerryStatus.HAPPY, type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("Snip", emotion: MerryStatus.HAPPY, type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("100 times better", emotion: MerryStatus.HAPPY),
        new Speech("bear", type: EventType.FIX),

    };


}

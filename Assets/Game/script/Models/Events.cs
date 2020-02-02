using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {
    public static List<Speech> start = new List<Speech> {
        new Speech("This Room....", emotion: MerryStatus.HAPPY,type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("..", emotion: MerryStatus.REGULAR),
        new Speech("This room", emotion: MerryStatus.REGULAR,type: EventType.DIMMED_DIALOG),
        new Speech("It has such a familiar scent.", emotion: MerryStatus.WORRIED),
        new Speech("A Messing Heart", emotion: MerryStatus.HAPPY,type: EventType.BLACK_SCREEN_DIALOG),
    };
    public static List<Speech> bearCutscene = new List<Speech> {
        new Speech("Teddy bear!", emotion: MerryStatus.HAPPY),
        new Speech("Something feels off.", emotion: MerryStatus.AWRY),
        new Speech("..", emotion: MerryStatus.SAD),
        new Speech("It's missing an eye.", emotion: MerryStatus.WORRIED)
    };
    public static List<Speech> bearCutscene2 = new List<Speech> {
        new Speech("Teddy bear!", emotion: MerryStatus.HAPPY),
        new Speech("Oh lookat you!", emotion: MerryStatus.JOYFUL),
        new Speech("..", emotion: MerryStatus.SAD),
        new Speech("You hug the Teddy Bear", emotion: MerryStatus.JOYFUL,type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("So cute! Baby bear! Wubly Bear!", emotion: MerryStatus.JOYFUL),
        new Speech("I love you!", emotion: MerryStatus.JOYFUL),
    };
    public static List<Speech> bearCutsceneInv = new List<Speech> {
        new Speech("I think I can give you an eye buddy."),
        new Speech(type:EventType.OPEN_INVENTORY)
    };

    public static List<Speech> dollCutscene = new List<Speech> {
        new Speech("Ah music box!", emotion: MerryStatus.HAPPY),
        new Speech("You decided to wind the music box.", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("", emotion: MerryStatus.HAPPY),
        new Speech("", emotion: MerryStatus.REGULAR),
        new Speech("...A silent song.", emotion: MerryStatus.SAD)
    };

    public static List<Speech> dollCutsceneI = new List<Speech> {
        new Speech("I fixeds it, I fixeds IT! Hohoho", emotion: MerryStatus.JOYFUL),
        new Speech("hehehe Hohoho", emotion: MerryStatus.JOYFUL)
    };
    public static List<Speech> frameCutsceneI = new List<Speech> {
        new Speech("...", emotion: MerryStatus.HAPPY)
    };
    public static List<Speech> bearCutsceneI = new List<Speech> {
        new Speech("I hope it's enjoying stereoscopic vision.", emotion: MerryStatus.HAPPY)
    };

    public static List<Speech> dollCutscene2 = new List<Speech> {
        new Speech("There you are!", emotion: MerryStatus.HAPPY),
        new Speech("You decided to wind the music box.", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("", emotion: MerryStatus.HAPPY),
        new Speech("", emotion: MerryStatus.JOYFUL),
        new Speech("Music fills the room", emotion: MerryStatus.HAPPY, type: EventType.DIMMED_DIALOG),
        new Speech("You try to immitate the ballerina, but balance is not your forte.", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("hohoho", emotion: MerryStatus.HAPPY)
    };
    public static List<Speech> dollCutsceneInv = new List<Speech> {
        new Speech("Maybe I can piece it back together."),
        new Speech(type:EventType.OPEN_INVENTORY)
    };

    public static List<Speech> frameCutscene = new List<Speech> {
        new Speech("A picture of... legs.", emotion: MerryStatus.REGULAR),
        new Speech("You'd think they'd take pictures of their faces.", emotion: MerryStatus.WORRIED),
        new Speech("To each their own.", emotion: MerryStatus.AWRY),
    };
    public static List<Speech> frameCutscene2 = new List<Speech> {
        new Speech("There! Now you have a leg to stand on.", emotion: MerryStatus.REGULAR),
        new Speech("...", type: EventType.BLACK_SCREEN_DIALOG),
    };
    public static List<Speech> frameCutsceneInv = new List<Speech> {
        new Speech("There's ways to fix this avant-garde photo.", emotion: MerryStatus.HAPPY),
        new Speech(type:EventType.OPEN_INVENTORY)
    };


    public static List<Speech> ButtonFlavor = new List<Speech> {
        new Speech("Looks like a cookie, but it's clearly a button.", emotion: MerryStatus.REGULAR),
        new Speech("Maybe. I can attach it to something.", emotion: MerryStatus.REGULAR),
        new Speech("Obtained: Button.", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("button",type:EventType.AQUIRE_ITEM)
    };
    public static List<Speech> Photo1Flavor = new List<Speech> {
        new Speech("A torn Photo of a man.", emotion: MerryStatus.REGULAR),
        new Speech("I feel this...", emotion: MerryStatus.REGULAR),
        new Speech("", emotion: MerryStatus.SAD),
        new Speech("This girl kind-of looks like me.", emotion: MerryStatus.REGULAR),
        new Speech("Obtained: Photo of a Man.", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("photo_1",type:EventType.AQUIRE_ITEM)        
    };
    public static List<Speech> Photo2Flavor = new List<Speech> {
        new Speech("A torn Photo of a woman.", emotion: MerryStatus.REGULAR),
        new Speech("Obtained: Photo of a Woman.", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("photo_2",type:EventType.AQUIRE_ITEM)
    };
    public static List<Speech> stringStringFlavor = new List<Speech> {
        new Speech("A string and needle.", emotion: MerryStatus.JOYFUL),
        new Speech("Perfect to fix about anything.", emotion: MerryStatus.HAPPY),
        new Speech("Almost anything...", emotion: MerryStatus.WORRIED),
        new Speech("Obtained: Thread And Needle.", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("thread",type:EventType.AQUIRE_ITEM)
    };
    public static List<Speech> ballerinaFlavor = new List<Speech> {
        new Speech("A ballerina.", emotion: MerryStatus.HAPPY),
        new Speech("A beautiful ballerina.", emotion: MerryStatus.WORRIED),
        new Speech("I feel it belongs to something.", emotion: MerryStatus.WORRIED),
        new Speech("Obtained: A Ballerina.", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("ballerina",type:EventType.AQUIRE_ITEM)
    };
    public static List<Speech> winderFlavor = new List<Speech> {
        new Speech("...", emotion: MerryStatus.AWRY),
        new Speech("It's a weird thing this one.", emotion: MerryStatus.WORRIED),
        new Speech("Maybe I can open a bottle with it.", emotion: MerryStatus.HAPPY),
        new Speech("Obtained: Winder", type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("winder",type:EventType.AQUIRE_ITEM)
    };


    public static List<Speech> time = new List<Speech> {
        new Speech("There's a time and place.", emotion: MerryStatus.WORRIED, type: EventType.DIMMED_DIALOG)
    };

    //BEAR
    public static List<Speech> bearButton = new List<Speech> {
        new Speech("This can work as an eye.", emotion: MerryStatus.JOYFUL),
        new Speech("But how can I make it stick?", emotion: MerryStatus.WORRIED),
        new Speech("bear",type:EventType.OPEN_INVENTORY_2ND_STAGE)
    };
    public static List<Speech> bearButtonThread = new List<Speech> {
        new Speech("Thread is... nice, but eyes are more circular than that.", emotion: MerryStatus.AWRY),
    };
    public static List<Speech> bearButtonPhotos = new List<Speech> {
        new Speech("I don't have a clue of what I'm doing.", emotion: MerryStatus.SAD),
    };
    public static List<Speech> fixBear = new List<Speech> {
        new Speech("I will fix you up little fellow.", emotion: MerryStatus.HAPPY),
        new Speech("Snip", emotion: MerryStatus.HAPPY, type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("Snip", emotion: MerryStatus.HAPPY, type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("Snip", emotion: MerryStatus.HAPPY, type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("bear", type: EventType.FIX),
        new Speech("100 times better.", emotion: MerryStatus.HAPPY),
    };

    //BOX
    public static List<Speech> boxButtonBall = new List<Speech> {
        new Speech("One word, perfection.", emotion: MerryStatus.REGULAR),
        new Speech("...", emotion: MerryStatus.WORRIED),
        new Speech("I still need to make her flip around and dance.", emotion: MerryStatus.WORRIED),
        new Speech("winder",type:EventType.OPEN_INVENTORY_2ND_STAGE)
    };
    public static List<Speech> boxButtonWinder = new List<Speech> {
        new Speech("It's making sound, but where is the finesse.", emotion: MerryStatus.REGULAR),
        new Speech("The spectacle.", emotion: MerryStatus.REGULAR),
        new Speech("winder",type:EventType.OPEN_INVENTORY_2ND_STAGE)
    };
    public static List<Speech> fixBox = new List<Speech> {
        new Speech("Ok, I know what to do.", emotion: MerryStatus.HAPPY),
        new Speech("This goes here!", emotion: MerryStatus.HAPPY, type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("Twist and........", emotion: MerryStatus.HAPPY, type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("Click", emotion: MerryStatus.HAPPY, type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("box", type: EventType.FIX),
        new Speech("100 times better.", emotion: MerryStatus.HAPPY),
    };


    //Picture
    public static List<Speech> pictureButtonP1 = new List<Speech> {
        new Speech("You, and her.", emotion: MerryStatus.REGULAR),
        new Speech("...", emotion: MerryStatus.WORRIED),
        new Speech("It's still missing someone.", emotion: MerryStatus.WORRIED),
        new Speech("winder",type:EventType.OPEN_INVENTORY_2ND_STAGE)
    };
    public static List<Speech> pictureButtonP2 = new List<Speech> {
        new Speech("Here you are.", emotion: MerryStatus.REGULAR),
        new Speech("...", emotion: MerryStatus.SAD),
        new Speech("There's a whole triangle where I can fit more photo.", emotion: MerryStatus.REGULAR),
        new Speech("winder",type:EventType.OPEN_INVENTORY_2ND_STAGE)
    };
    public static List<Speech> pictureButtonFinale = new List<Speech> {
        new Speech("Here.", emotion: MerryStatus.HAPPY),
        new Speech("...", emotion: MerryStatus.HAPPY, type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("frame", type: EventType.FIX),
        new Speech("100 times better.", emotion: MerryStatus.SAD),
    };

    public static List<Speech> finale = new List<Speech> {
        new Speech("Odd...", emotion: MerryStatus.WORRIED),
        new Speech("I feel...", emotion: MerryStatus.REGULAR),
        new Speech("..whole..", emotion: MerryStatus.HAPPY, type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("And so I fell asleep.", emotion: MerryStatus.JOYFUL, type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("Finally.", emotion: MerryStatus.HAPPY, type: EventType.DIMMED_DIALOG),
        new Speech("I feel 100 times better.", emotion: MerryStatus.HAPPY, type: EventType.BLACK_SCREEN_DIALOG),
        new Speech("finale", type: EventType.FINALE),

        new Speech("I feel 100 times better.", emotion: MerryStatus.HAPPY, type: EventType.BLACK_SCREEN_DIALOG),
        //FINALE CG
    };

    public static List<Speech> what = new List<Speech> {
        new Speech("You created an abomination", emotion: MerryStatus.WORRIED, type: EventType.BLACK_SCREEN_DIALOG)
    };

}

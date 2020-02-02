

[System.Serializable]
public class Speech {
    public string dialog = "";
    public MerryStatus emotion = MerryStatus.REGULAR;
    public EventType type = EventType.DIALOG;
    public SpecialEffect specialEffect = SpecialEffect.SIMPLE;

    public Speech (string dialog = "",
        MerryStatus emotion = MerryStatus.REGULAR,
        EventType type = EventType.DIALOG,
        SpecialEffect specialEffect = SpecialEffect.SIMPLE) {
        this.dialog = dialog;
        this.emotion = emotion;
        this.type = type;
        this.specialEffect = specialEffect;
    }

}

public enum EventType {
    WHITE_SCREEN_JUMP,
    BLACK_SCREEN_TRANSITION,
    CG,
    DIALOG,
    DIMMED_DIALOG,
    BLACK_SCREEN_DIALOG
}

public enum SpecialEffect {
    SIMPLE,
    WHITE_SCREEN_JUMP
}
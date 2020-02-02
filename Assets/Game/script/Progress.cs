using UnityEngine;
using System.Collections;

public class Progress {
    public int heartHeal = 0;


    public HeartStatus GetHeartStatus () {
        switch (heartHeal) {
        case 0:
    //
        return HeartStatus.WAITING;
        case 1:
        return HeartStatus.ONE;
        case 2:
        return HeartStatus.TWO;
        case 3:
        return HeartStatus.THREE;
        case 4:
        default:
        return HeartStatus.FOUR;
        }
    }
}


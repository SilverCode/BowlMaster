using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

    public enum Action { Tidy, Reset, EndTurn, EndGame, Error }

    public Action Bowl(int pins) {
        if (pins < 0 || pins > 10) {
            throw new UnityException("Invalid number of pins");
        }

        if (10 == pins) {
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what action to return!");
    }
}

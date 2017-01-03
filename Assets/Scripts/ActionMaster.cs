﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class ActionMaster {

    public enum Action { Tidy, Reset, EndTurn, EndGame, Error }

    private int[] bowls = new int[21];
    private int bowl = 1;

    public Action Bowl(int pins) {
        if (pins < 0 || pins > 10) {
            throw new UnityException("Invalid number of pins");
        }

        bowls[bowl - 1] = pins;

        if (bowl == 21) {
            return Action.EndGame;
        }

        if (bowl >= 19 && Bowl21Awarded()) {
            bowl++;
            return Action.Reset;
        } else if (bowl == 20 && !Bowl21Awarded()) {
            return Action.EndGame;
        }

        if (10 == pins) {
            bowl += 2;
            return Action.EndTurn;
        }

        if (bowl % 2 != 0) {
            bowl++;
            return Action.Tidy;
        } else if (bowl % 2 == 0) {
            bowl++;
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what action to return!");
    }

    private bool Bowl21Awarded() {
        return (bowls[19 - 1] + bowls[20 - 1] >= 10);
    }
}

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest {

    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster actionMaster;

    [SetUp]
    public void Setup() {
        actionMaster = new ActionMaster();
    }

	[Test]
	public void PassingTest() {
	    Assert.AreEqual(1,1);
	}

    [Test]
    public void T01OneStrikeReturnsEndTurn() {
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }

    [Test]
    public void T02Bowl8ReturnsTidy() {
        Assert.AreEqual(ActionMaster.Action.Tidy, actionMaster.Bowl(8));
    }

    [Test]
    public void T03Bowl28ReturnsEndTurn() {
        Assert.AreEqual(ActionMaster.Action.Tidy, actionMaster.Bowl(2));
        Assert.AreEqual(ActionMaster.Action.EndTurn, actionMaster.Bowl(8));
    }

    [Test]
    public void T04CheckResetAtStrikeInLastFrame() {
        int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,};
        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(ActionMaster.Action.Reset, actionMaster.Bowl(10));
    }

    [Test]
    public void T05CheckResetAtSpareInLastFrame() {
        int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(1);
        Assert.AreEqual(ActionMaster.Action.Reset, actionMaster.Bowl(9));
    }

    [Test]
    public void T06YouTubeRollsEndInEndGame() {
        int[] rolls = {8, 2,7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2};
        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(ActionMaster.Action.EndGame, actionMaster.Bowl(9));
    }

    [Test]
    public void T07GameEndsAtBowl20() {
        int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1};
        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(ActionMaster.Action.EndGame, actionMaster.Bowl(1));
    }

    [Test]
    public void T08TidyAtBowl20AfterStrike() {
        int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10};
        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(ActionMaster.Action.Tidy, actionMaster.Bowl(5));
    }

    [Test]
    public void T09TidyAtBowl20AfterNoHit() {
        int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10};
        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(ActionMaster.Action.Tidy, actionMaster.Bowl(0));
    }
}

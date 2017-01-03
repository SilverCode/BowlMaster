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
}

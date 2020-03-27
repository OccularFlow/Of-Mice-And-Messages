using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : DockLevelGameManager

{
    public GameObject[] popUps;
    public int popUpIndex = 0;
	private GridBlock first_grid;
	private float rotation;
	GridBlock[] gridBlocks;

	protected override void Start() {
		base.Start();
		dock.addPipe(PipeTypes.Straight);
        dock.addPipe(PipeTypes.L);
		gridBlocks = FindObjectsOfType<GridBlock>();
		foreach (GridBlock gridBlock in gridBlocks) {
			gridBlock.deactivate();
		}
	}

	void activateGridBlock(int id) {
		foreach (GridBlock gridBlock in gridBlocks) {
			if (gridBlock.getID() == id) {
				gridBlock.activate();
				return;
			}
		}
	}

	void deactivateGridblock(int id) {
		foreach (GridBlock gridBlock in gridBlocks) {
			if (gridBlock.getID() == id) {
				gridBlock.deactivate();
				return;
			}
		}
	}
    void Update()
    {
		for (int i = 0; i < popUps.Length; i++)
		{
			if (i == popUpIndex)
			{
				popUps[i].SetActive(true);
			}
			else
			{
				popUps[i].SetActive(false);
			}
		}
		if (popUpIndex == 3)
		{
            if(currentSelectedPipe != null)
			{
				rotation = currentSelectedPipe.Rotation;
				nextPopUp();
			}
		}
        else if (popUpIndex == 4)
		{
			activateGridBlock(1);

            if (currentSelectedPipe.getGridBlock() != null)
			{
				first_grid = currentSelectedPipe.getGridBlock();
				nextPopUp();
			}
		}
        else if (popUpIndex == 5)
		{
			activateGridBlock(8);

			if (currentSelectedPipe.getGridBlock() != first_grid)
			{
				nextPopUp();
			}
		}
        else if (popUpIndex == 6)
		{
			if (rotation != currentSelectedPipe.Rotation)
			{
				nextPopUp();
			}
		}
        else if (popUpIndex == 7)
		{
			if (currentSelectedPipe == null)
			{
				deactivateGridblock(1);
				deactivateGridblock(8);
				nextPopUp();
			}
			
		}
        else if (popUpIndex == 11)
		{
            if (isWaterRunning)
			{
				nextPopUp();
			}
		}
        else if (popUpIndex == 12)
		{
			if (!isWaterRunning)
			{
				nextPopUp();
			}
		}

    }

    public void nextPopUp()
	{
		popUpIndex++;
	}

}


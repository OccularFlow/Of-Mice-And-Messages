using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
This class is used to manage the game when a level is being played.
It is used to communicate between the various different game components.
When the water is running, the user cannot change anything in the scene.
**/
public class DockLevelGameManager : GameManager
{
    protected Dock dock;
    protected bool isCurrentPipeFromDock;    
    
    protected override void Start() {
        dock = FindObjectOfType<Dock>();
        buttonManager.deactivateButtons();
    }
    public override void pipeSelected(Pipe pipe) {
        base.pipeSelected(pipe);
        if (isWaterRunning) {
            return;
        }

        isCurrentPipeFromDock = pipe.fromDock();
        if (isCurrentPipeFromDock) {
            buttonManager.deactivateButtons();
        } else {
            buttonManager.activateButtons();
        }
    }

    public void binPipe() {
        PipeTypes destroyedPipeType = currentSelectedPipe.getPipeType();
        currentSelectedPipe.getGridBlock().setPipe(null);
        Destroy(currentSelectedPipe.gameObject);
        dock.addPipe(destroyedPipeType);
        soundManager.playSound("bin");
        selectionBox.remove();
        buttonManager.deactivateButtons();
    }

    public void gridBlockToggled(GridBlock gridBlock) {
        if (isGridNotSelectable(isWaterRunning, currentSelectedPipe)) {
            return;
        }

        if (isCurrentPipeFromDock) {            
            currentSelectedPipe = dock.removePipe(currentSelectedPipe);
        } else {
            currentSelectedPipe.getGridBlock().setPipe(null);
        }

        currentSelectedPipe.updateGridBlock(gridBlock);
        gridBlock.setPipe(currentSelectedPipe);
        var pipeTransform = currentSelectedPipe.transform;
        pipeTransform.position = gridBlock.transform.position;
        selectionBox.move(pipeTransform.position);
        soundManager.playSound("move");
        isCurrentPipeFromDock = false;
        buttonManager.activateButtons();
    }
    public bool isGridNotSelectable(bool isWaterRunning, Pipe currentSelectedPipe)
    {
        return (isWaterRunning || currentSelectedPipe == null);
    }

}

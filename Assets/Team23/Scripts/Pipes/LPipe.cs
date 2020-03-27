using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPipe : Pipe
{
    private float xVel = 6f;
    private float yVel = 0f;
    private int[] xRotations;
    private int[] yRotations;
    
    protected virtual void Start()
    {
        waterSource = this.transform.position;
        waterSource.y = waterSource.y + 2f;
        xRotations = new int[] {0,1,0,-1};
        yRotations = new int[] {-1,0,1,0};
        waterRunning = false;
        pipeType = PipeTypes.L;
    }

    protected override Vector2 getExitVelocity() {
        return new Vector2(xVel, yVel);
    }

    protected override bool correctDirection(Vector2 incomingVel, string location)
    {
        if (location == "Head"){
            if (yRotations[rotationCounter] * incomingVel.y > 0) {
                return true;
            }
            if (xRotations[rotationCounter] * incomingVel.x > 0) {
                return true;
            }
            return false;
        }
        if (yRotations[(rotationCounter + 1) % 4] * incomingVel.y < 0) {
            return true;
        }
        if (xRotations[(rotationCounter + 1) % 4] * incomingVel.x < 0) {
            return true;
        }
        return false;
    }

    protected override void resetSpawnLocation(string newLocation) {
        spawnLocation = newLocation;
        int correctRotation;
        if (spawnLocation == "Head") {
            correctRotation = (rotationCounter + 1) % 4;
        } else {
            correctRotation = (rotationCounter + 2) % 4;
        }
        waterSource = this.transform.position;
        waterSource.x = waterSource.x + (1.5f * xRotations[correctRotation]);
        waterSource.y = waterSource.y + (1.5f * yRotations[correctRotation]);
        xVel = 6f * xRotations[correctRotation];
        yVel = 7f * yRotations[correctRotation];
        }
}

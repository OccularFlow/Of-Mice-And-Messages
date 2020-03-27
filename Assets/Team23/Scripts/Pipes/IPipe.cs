using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IPipe : Pipe {
    private float xVel = 0f;
    private float yVel = -6f;
    private int[] xRotations;
    private int[] yRotations;
    
    protected virtual void Start() {
        waterSource = transform.position;
        waterSource.y = waterSource.y - 1f;
        xRotations = new[] {0,1,0,-1};
        yRotations = new[] {-1,0,1,0};
        waterRunning = false;
        pipeType = PipeTypes.Straight;
    }

    protected override void resetSpawnLocation(string newLocation) {
        spawnLocation = newLocation;
        int correctRotation;
        if (spawnLocation == "Head") {
            correctRotation = rotationCounter;
        } else {
            correctRotation = (rotationCounter + 2) % 4;
        }
        waterSource = this.transform.position;
        waterSource.x = waterSource.x + 1.3f * xRotations[correctRotation];
        waterSource.y = waterSource.y + 1.5f * yRotations[correctRotation];
        xVel = 7f * xRotations[correctRotation];
        yVel = 8f * yRotations[correctRotation]; 
    }


    protected override Vector2 getExitVelocity() {
        return new Vector2(xVel, yVel);
    }

    protected override bool correctDirection(Vector2 incomingVel, string location) {        
        if (location == "Head"){
            if (yRotations[rotationCounter] * incomingVel.y > 0) {
                return true;
            }
            if (xRotations[rotationCounter] * incomingVel.x > 0) {
                return true;
            }
            return false;
        }
        if (yRotations[rotationCounter] * incomingVel.y < 0) {
            return true;
        }
        if (xRotations[rotationCounter] * incomingVel.x < 0) {
            return true;
        }
        return false;
    }
}

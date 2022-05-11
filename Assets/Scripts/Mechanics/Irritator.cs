using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;
using System;

namespace Platformer.Mechanics
{
    public class Irritator{

        long minTime;
        long maxTime;
        long counter;
        Action callback;

        public Irritator(Action _callback,long _minTime, long _maxTime){
            callback = _callback;
            minTime = _minTime;
            maxTime = _maxTime;
            counter = (long)UnityEngine.Random.Range(minTime,maxTime);
        }

        public void CheckForCalls(long stopwatch){
            
            if( stopwatch > counter){
                Debug.Log(stopwatch);
                counter+=(long)UnityEngine.Random.Range(minTime,maxTime);
                callback();
            }
        }

        


    }


}
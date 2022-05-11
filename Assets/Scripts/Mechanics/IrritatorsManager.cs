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
    public class IrritatorsManager{

        System.Diagnostics.Stopwatch stopwatch;
        List<Irritator> Irritators;

        public IrritatorsManager(){
            stopwatch = new System.Diagnostics.Stopwatch();
            Irritators = new List<Irritator>();
        }

        public void Start(){
            stopwatch.Start();
        }

        public void CheckForUpdates(){
            
            foreach(var i in Irritators){
                i.CheckForCalls(stopwatch.ElapsedMilliseconds);
            } 
        }

        public void AddIrritator(Action callback, long minTime, long maxTime){
            Irritators.Add(new Irritator(callback,minTime,maxTime));
        }


    }


}
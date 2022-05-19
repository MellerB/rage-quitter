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
        MonoBehaviour mb;


        public IrritatorsManager(MonoBehaviour _mb){
            mb = _mb;
            stopwatch = new System.Diagnostics.Stopwatch();
            Irritators = new List<Irritator>();
        }

        public void Start(){
            stopwatch.Start();
        }

        public void CheckForUpdates(){
            
            foreach(var i in Irritators){
                var t = stopwatch.ElapsedMilliseconds;
                i.CheckForCalls(t);
            } 
        }

        public void AddIrritator(Action enableEffect, Action disableEffect, int effectDuration, long minTime, long maxTime){        
            Irritators.Add(new Irritator(enableEffect, disableEffect, effectDuration,minTime,maxTime,mb));
        }


    }


}
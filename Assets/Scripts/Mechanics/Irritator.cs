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
        MonoBehaviour mb;
        long minTime;
        long maxTime;
        long counter;
        int effectDuration;
        Action enableEffect;
        Action disableEffect;

        public Irritator(Action _enableEffect, Action _disableEffect,int _effectDuration ,long _minTime, long _maxTime, MonoBehaviour _mb){
            mb = _mb;
            effectDuration = _effectDuration;
            enableEffect = _enableEffect;
            disableEffect = _disableEffect;
            minTime = _minTime;
            maxTime = _maxTime;
            counter = (long)UnityEngine.Random.Range(minTime,maxTime);
            Debug.Log(effectDuration);
        }

        private IEnumerator coroutine(){
            enableEffect();
            yield return new WaitForSeconds(effectDuration);
            disableEffect();
        }

        public void CheckForCalls(long stopwatch){
            if( stopwatch > counter){
                Debug.Log(effectDuration);
                counter+=(long)UnityEngine.Random.Range(minTime,maxTime);
                Debug.Log(coroutine());
                Debug.Log(mb);
                mb.StartCoroutine(coroutine());
            }
        }

        


    }


}
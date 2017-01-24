using UnityEngine;
using System.Collections;
using Combat;
using Events;
using System;
using DG.Tweening;
using System.Collections.Generic;
using FluffyUnderware.Curvy;
using FluffyUnderware.Curvy.Controllers;

public class MoveCombatCamera : MonoBehaviour,
    CombatEvents.INewTurnHandler,
    CombatEvents.IInitCombatHandler,
    CombatEvents.IEventCameraHandler
{
    
    public Transform enemyPosition;
    public Transform playerPosition;

    public Transform lookAtPosition;
    public Transform startLookAtPosition;

    public CurvySpline playerSpline;
    public CurvySpline monsterSpline;
    public CurvySpline specialAttackHarasserSpline;
    public SplineController splineController;

    private int _turnCount = 0;

    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

    void Update()
    {
        if(lookAtPosition != null)
        {
            transform.DOLookAt(lookAtPosition.position, 0.0f);
        }

    }

    public void OnNewTurn(TurnManager.TurnState state, float turnDuration)
    {
        
        

        // DIRTY ****************
        if(state == TurnManager.TurnState.PlayerTurn)
        {
            if (_turnCount > 0)
            {
                splineController.Spline = playerSpline;
                splineController.Prepare();
                splineController.Play();
            }
            _turnCount++;   
            //transform.DOMove(playerPosition.position, 0.5f, true);
        }
        else if (state == TurnManager.TurnState.Enemyturn)
        {
            
                splineController.Spline = monsterSpline;
                splineController.Prepare();
                splineController.Speed = 10f;
                splineController.Play();
            
            //transform.DOMove(enemyPosition.position, 0.5f, true);
        }
    }



    public void OnInitCombat()
    {
        // DIRTY ****************
        splineController = GetComponent<SplineController>();
        playerPosition = CombatManager.instance.currentCombatZone.transform.FindChild("CameraAnchors").transform.FindChild("CameraAnchorPlayer");
        enemyPosition = CombatManager.instance.currentCombatZone.transform.FindChild("CameraAnchors").transform.FindChild("CameraAnchorMonster");

        lookAtPosition = CombatManager.instance.currentCombatZone.transform.FindChild("CameraAnchors").transform.FindChild("CameraLookAtPoint");
        startLookAtPosition = lookAtPosition;
        splineController.Spline = monsterSpline;
        splineController.Speed = 10f;
        splineController.Prepare();
        //splineController.Stop();

    }

    public enum CameraCurve
    {
        SpecialAttackHarasser,
        None,
    }

    public void OnEventCamera(CameraCurve cameraCurve, Transform target, bool start = false)
    {
        switch (cameraCurve)
        {
            case CameraCurve.None:
                splineController.Spline = monsterSpline;
                if (start)
                {
                    splineController.Prepare();
                }
                lookAtPosition = target == null ? startLookAtPosition : target;
                splineController.Speed = 10f;
                splineController.Play();
                break;

            case CameraCurve.SpecialAttackHarasser:
                splineController.Spline = specialAttackHarasserSpline;
                if (start)
                {
                    splineController.Prepare();
                }
                lookAtPosition = target == null ? startLookAtPosition : target;
                splineController.Speed = 10f;
                splineController.Play();
                break;

            
        }
    }


    
    /**plus utiliser pour l'instant***/
    [Serializable]
    public enum EventCamera
    {
        SpecialHarasser,
    }
    /**********************************/
    
    [Serializable]
    public struct EventCheckPoint
    {
        public EventCamera eventCam;
        public List<GameObject> listOfControlPoints;
    }

    [Header("Camera Curve Settings :")]
    public List<EventCheckPoint> listOfCheckPoint;

    public void StopAtAllCheckPoints(CurvySplineMoveEventArgs e)
    {
        foreach (EventCheckPoint cp in listOfCheckPoint)
            {
                //if (cp.eventCam == EventCamera.SpecialHarasser)
                //{
                    foreach (GameObject p in cp.listOfControlPoints)
                    {
                        if (e.ControlPoint.gameObject == p)
                        {
                            GetComponent<SplineController>().Speed = 0;
                            break;
                        }
                    }
                //}

       }
    }
    
}

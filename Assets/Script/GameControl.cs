﻿using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update
    public MovePerson _movePerson;
    public Transform _posFire;
    public HudControl _hudControl;
    public SldScripty _sldScripty;
    public SldScripty _sldScriptyFire;
    public int _life;
    public int _point;

    public List<EnemyControl> _enemyControlList = new List<EnemyControl>();
    public List<GameObject> _itemList = new List<GameObject>();

    public Vector2 offset;


    private void Awake()
    {
        MovePersonON(false);//liberar movimento player
        _sldScripty.PauseSliderON(true);
    }


    public void StopEnemeys(bool check)
    {
        for (int i = 0; i < _enemyControlList.Count; i++)
        {
            _enemyControlList[i].Stop(check);           
        }
    }

   public void ResetPlat()
    {
        for (int i = 0; i < _enemyControlList.Count; i++)
        {
            _enemyControlList[i]._restoreLife = true;
        }
        for (int i = 0; i < _itemList.Count; i++)
        {
            _itemList[i].SetActive(true);
            _itemList[i].GetComponent<ItemScript>().RestartItem();
        }
    }
    public void MovePersonON(bool move)
    {
        _movePerson.enabled = move;
    }
    public void LifeFire(bool check)
    {
        if (check) {
            _sldScriptyFire._mainSlider.value = _life;
            _life = Convert.ToInt32(_sldScriptyFire._mainSlider.value);
        }
        else
        {
            _life = Convert.ToInt32(_sldScriptyFire._mainSlider.value);
        }
        _hudControl._textLife.text = "x" + _life;
    }

   public void HitPlayer(Transform _vRestart)
    {
        if (_life > 1)//restart
        {
            _hudControl.BackGameOn(true);
            _life--;
            LifeFire(true);
            _hudControl.TextRestart();
            _hudControl._textLife.text = "x" + _life;
            _movePerson.VectorTempPos(_vRestart);// enviar valores para restart de posição
        }
        else if (_life == 1)
        {
            _movePerson.VectorTempPos(_vRestart);
            _hudControl.GameOverON();
        }
    }


}
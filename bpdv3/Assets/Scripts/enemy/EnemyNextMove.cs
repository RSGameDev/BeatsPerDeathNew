﻿using System;
using Floor;
using Managers;
using UnityEngine;

namespace EnemyNS
{
    public class EnemyNextMove : MonoBehaviour
    {
        #region Private & Constant variables

        [SerializeField] private Enemy _enemy;
        private GameObject nextMoveCurrentTile;
        [SerializeField] private EnemyMovement _enemyMovement;
        private const string s_Ontile = "OnTile";

        #endregion

        #region Public & Protected variables

        public bool token = true;

        #endregion


        #region Constructors

        #endregion

        #region Private methods

        private void OnDisable()
        {
            if (_enemy.hasSpawned)
            {
                NewCycle();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_enemyMovement.IsEnemyMoving)
            {
                return;
            }

            if (other.CompareTag(s_Ontile))
            {
                _enemyMovement.NextMoveLocationGO = other.gameObject;
                nextMoveCurrentTile = other.gameObject;
                if (!other.gameObject.GetComponent<OnTile>().possessToken)
                {
                    other.gameObject.GetComponent<OnTile>().possessToken = true;
                    token = false;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(s_Ontile))
            {
                other.gameObject.GetComponent<OnTile>().possessToken = false;
            }
        }

        #endregion

        #region Public methods

        public void NewCycle()
        {
            nextMoveCurrentTile.GetComponent<OnTile>().possessToken = false;
            token = true;
        }

        #endregion
    }
}
﻿using System;
using EnemyNS;
using Floor;
using PlayerNS;
using UnityEngine;

// This script is attached to an object beneath the player, enemy, coin. So it can attach itself to the tile. As when the tile moves across the object needs to be moving along with it.
namespace Mechanics
{
    public class Anchor : MonoBehaviour
    {
        [SerializeField] private EnemyMovement _enemyMovement;

        private const string s_Enemy = "enemy";
        private const string s_Coin = "coin";
        private const string s_Player = "Player";
        private const string s_FloorLayer = "Floor";

        private Vector3 _newPosition;
        public GameObject anchorTileObject;
        private PlayerMovement playermovement;
        public Vector3 currentTilePosition;
        public bool isMoving;

        //private void Awake()
        //{
        //    tag = gameObject.transform.parent.tag;
        //    playermovement = GetComponentInParent<PlayerMovement>();
        //}
//
        //private void OnDisable()
        //{
        //    anchorTileObject = null;
        //}
//
        private void Update()
        {
            if (!isMoving)
            {
                transform.parent.transform.position = currentTilePosition; //
            }
        }

        private void OnTriggerStay(Collider other)
        {
            currentTilePosition = new Vector3(other.transform.position.x, 0,
                other.transform.position.z);
            //    if ((tag == s_Enemy || tag == s_Coin) && other.gameObject.layer == LayerMask.NameToLayer(s_FloorLayer))
            //    {
            //        //if (enemy.isAlive)
            //        //{
            //        if (!_enemyMovement._canMove)
            //        {
            //            AttachObjectToTile(other);
            //        }
            //        else
            //        {
            //            DetachFromTile();
            //        }
//
            //        //}
            //        //else
            //        //{
            //        //    DetachFromTile();
            //        //}
            //    }
//
            //    if (tag == s_Player && other.gameObject.layer == LayerMask.NameToLayer(s_FloorLayer))
            //    {
            //        if (!playermovement.IsPlayerInputDetected)
            //        {
            //            print("no input");
            //            AttachObjectToTile(other);
            //        }
            //        else
            //        {
            //            DetachFromTile();
            //        }
        }
//
        //// This function was made so that the objects will stick to the tiles as the level scrolls. Otherwise the objects would stay in place and the level moves underneath them.
        //private void AttachObjectToTile(Collider other)
        //{
        //    anchorTileObject = other.gameObject;
        //    _newPosition = other.GetComponent<Renderer>().bounds.center;
        //    switch (transform.parent.tag)
        //    {
        //        case s_Enemy:
        //            transform.parent.position = new Vector3(anchorTileObject.transform.position.x,
        //                //anchorTileObject.transform.position.y + 1f, anchorTileObject.transform.position.z);
        //                anchorTileObject.transform.position.y + 0.25f, anchorTileObject.transform.position.z);
        //            break;
        //        //case s_Player:
        //        //    transform.parent.position = new Vector3(anchorTileObject.transform.position.x,
        //        //        anchorTileObject.transform.position.y + 0.25f, anchorTileObject.transform.position.z);
        //        //    break;
        //    }
//
        //    transform.parent.SetParent(other.transform);
        //}
//
        //// When the object moves off a tile, the parent for the object is reassigned.
        //private void OnTriggerExit(Collider other)
        //{
        //    if (other.gameObject.layer == LayerMask.NameToLayer(s_FloorLayer))
        //    {
        //        //transform.parent.SetParent(transform); ************ be mindful of this line. may need revisiting to check
        //        transform.parent.SetParent(null);
        //    }
        //}
//
        //public void DetachFromTile()
        //{
        //    //anchorTileObject = null;
        //    transform.parent.SetParent(null);
        //}
    }

    /*public class Anchor : MonoBehaviour
    {
        #region Private & Constant variables

        private const string s_Enemy = "enemy";
        private const string s_Coin = "coin";
        private const string s_Player = "Player";
        private const string s_FloorLayer = "Floor";
        private Vector3 _newPosition;

        #endregion

        #region Public & Protected variables

        public GameObject anchorTileObject;

        #endregion

        //new
        public Enemy enemy;
        public PlayerMovement playermovement;
        public EnemyMovement enemymovement;

        private string tag;

        private void OnDisable()
        {
            DetachFromTile();
        }

        private void Awake()
        {
            tag = gameObject.transform.parent.tag;
        }

        private void OnTriggerStay(Collider other)
        {
            if ((tag == s_Enemy || tag == s_Coin) && other.gameObject.layer == LayerMask.NameToLayer(s_FloorLayer))
            {
                if (enemy.isAlive)
                {
                    if (!enemymovement.IsEnemyMoving)
                    {
                        AttachObjectToTile(other);
                    }
                    else
                    {
                        DetachFromTile();
                    }
                }
                else
                {
                    DetachFromTile();
                }
            }

            if (tag == s_Player && other.gameObject.layer == LayerMask.NameToLayer(s_FloorLayer))
            {
                if (!playermovement.IsPlayerInputDetected)
                {
                    AttachObjectToTile(other);
                }
                else
                {
                    DetachFromTile();
                }
            }
        }

        // This function was made so that the objects will stick to the tiles as the level scrolls. Otherwise the objects would stay in place and the level moves underneath them.
        private void AttachObjectToTile(Collider other)
        {
            anchorTileObject = other.gameObject;
            _newPosition = other.GetComponent<Renderer>().bounds.center;
            switch (transform.parent.tag)
            {
                case s_Enemy:
                    transform.parent.position = new Vector3(anchorTileObject.transform.position.x,
                        //anchorTileObject.transform.position.y + 1f, anchorTileObject.transform.position.z);
                        anchorTileObject.transform.position.y + 0.25f, anchorTileObject.transform.position.z);
                    break;
                case s_Player:
                    transform.parent.position = new Vector3(anchorTileObject.transform.position.x,
                        anchorTileObject.transform.position.y + 0.25f, anchorTileObject.transform.position.z);
                    break;
            }

            transform.parent.SetParent(other.transform);
        }

        // When the object moves off a tile, the parent for the objecxt is reassigned.
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(s_FloorLayer))
            {
                transform.parent.SetParent(transform);
            }
        }

        public void DetachFromTile()
        {
            anchorTileObject = null;
            transform.parent.SetParent(null);
        }
    }*/
}
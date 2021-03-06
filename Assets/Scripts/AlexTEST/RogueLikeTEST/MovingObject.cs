﻿using System.Collections;
using UnityEngine;

namespace RogueLikeTEST
{
    public abstract class MovingObject : MonoBehaviour
    {
        public float moveTime = 0.1f;
        public LayerMask blockingLayer;


        private BoxCollider2D _boxCollider;
        private Rigidbody2D _rb2D;
        private float _inverseMoveTime;
    
        protected virtual void Start ()
        {
            _boxCollider = GetComponent <BoxCollider2D> ();

            _rb2D = GetComponent <Rigidbody2D> ();

            _inverseMoveTime = 1f / moveTime;
        }
    
    
        protected bool Move (int xDir, int yDir, out RaycastHit2D hit)
        {
            Vector2 start = transform.position;

            Vector2 end = start + new Vector2 (xDir, yDir);

            _boxCollider.enabled = false;

            hit = Physics2D.Linecast (start, end, blockingLayer);

            _boxCollider.enabled = true;

            if(hit.transform == null)
            {
                StartCoroutine (SmoothMovement (end));
                return true;
            }

            return false;
        }


        protected IEnumerator SmoothMovement (Vector3 end)
        {
            float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            while(sqrRemainingDistance > float.Epsilon)
            {
                Vector3 newPostion = Vector3.MoveTowards(_rb2D.position, end, _inverseMoveTime * Time.deltaTime);

                _rb2D.MovePosition (newPostion);

                sqrRemainingDistance = (transform.position - end).sqrMagnitude;
                yield return null;
            }
        }
    
        protected virtual void AttemptMove <T> (int xDir, int yDir)
            where T : Component
        {
            RaycastHit2D hit;

            bool canMove = Move (xDir, yDir, out hit);

            if(hit.transform == null)
                return;

            T hitComponent = hit.transform.GetComponent <T> ();

            if(!canMove && hitComponent != null)

                OnCantMove (hitComponent);
        }

        protected abstract void OnCantMove <T> (T component)
            where T : Component;
    }
}

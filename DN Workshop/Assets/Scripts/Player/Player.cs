using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private int _healthPoint;
        private int _manaPoint;
        
        private int _damagePoint;
        private bool _piercing; //power

        public GameObject goPrefab;
        public List<GameObject> _pool;
        public Vector3 initPos;
        public int maxSizePool;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Fire();
            }
        }

        void Fire()
        {
            if (_pool.Count == 0)
            {
                var go = Instantiate(goPrefab, initPos, quaternion.identity);
                _pool.Add(go);
                go.GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime, ForceMode.Impulse);
            }
            else
            {
                foreach (var gob in _pool)
                {
                   
                    if (gob.gameObject != goPrefab)
                    {
                        if (_pool.Count > maxSizePool)
                        {
                            if (!gob.activeSelf)
                            {
                                gob.SetActive(false);
                            }
                        }
                        else
                        {
                            var go = Instantiate(goPrefab, initPos, quaternion.identity);
                            _pool.Add(go);
                            go.GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime * 100, ForceMode.Impulse);
                        }
                    }
                    else
                    {
                        if (!gob.activeSelf)
                        {
                            gob.transform.position = initPos;
                            gob.GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime * 100, ForceMode.Impulse);
                        }
                    }
                }
            }
            
            
        }


        private void OnTriggerEnter(Collider other)
        {
            AI ai = other.GetComponent<AI>();

            if (ai && ai.IsHealthMoreThan(4))
            {
                ai.GetHurt(_damagePoint, _piercing);
            }
        }
    }
}

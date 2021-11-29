using System.Collections.Generic;
using UnityEngine;

namespace Capsule

{
    public class ColliderCapsule : MonoBehaviour
    {
        // public int CheckCapsuleCollision(GameObject ene, Vector3 localDiffPlace, Vector3 localPoint, float maxLen, float maxSeLen){
       
        //     return -1;
        // }
        public bool CheckCapsuleCollision(GameObject ene, Vector3 localDiffPlace, Vector3 localPoint, float maxLen, float maxSeLen)
        {
            float naiseki = Vector3.Dot(localDiffPlace, localPoint);
            float absN = Mathf.Abs(naiseki);
            // Debug.Log("localMyPlace " + localDiffPlace+ " naiseki " + naiseki+ " localPoint " + localPoint);

            if (maxLen + ene.transform.localScale.x < absN)
            {
                return false;
            }
            else
            {
                if (maxLen - maxSeLen <= absN && absN <= maxLen + ene.transform.localScale.x)
                {
                    Vector3 circleCenter = (maxLen - maxSeLen) * localPoint * naiseki / (Mathf.Abs(naiseki));
                    Vector3 circleDistance = circleCenter - localDiffPlace;
                    //  Debug.Log("circleCenter " + circleCenter + " circleDistance " + circleDistance.magnitude +
                    //            " ene.transform.localScale.x " +
                    //            ene.transform.localScale.x);
                    if (circleDistance.magnitude < ene.transform.localScale.x + maxSeLen)
                    {
                        /*どうあがいても円判定の実装がおかしいので早めになおしておく*/
                        Debug.Log("円判定");
                        return true;
                    }
                }

                if (absN < maxLen - maxSeLen)
                {
                    Vector3 line = naiseki * localPoint;
                    Vector3 lineDistance = line - localDiffPlace;
                    //  Debug.Log("line " + line + " lineDistance " + lineDistance.magnitude + " ene.transform.localScale.x " +
                    //           ene.transform.localScale.x);

                    if (lineDistance.magnitude < ene.transform.localScale.x + maxSeLen)
                    {
                        Debug.Log("カプセル判定");
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
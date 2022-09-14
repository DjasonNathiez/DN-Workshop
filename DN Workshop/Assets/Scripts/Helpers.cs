using UnityEngine;

namespace Utilitaire
{
    public static class Helpers
    {
        public enum Axis
        {
            X,
            Y,
            Z
        }

        public static void FlipScale(this GameObject go, Axis axis)
        {
            var scaleX = go.transform.localScale.x;
            var scaleY = go.transform.localScale.y;
            var scaleZ = go.transform.localScale.z;
            
            switch (axis)
            {
                case Axis.X:
                    go.transform.localScale = new Vector3(-scaleX, scaleY, scaleZ);
                    
                    break;
                
                case Axis.Y:
                    go.transform.localScale = new Vector3(scaleX, -scaleY, scaleZ);
                    break;
                
                case Axis.Z:
                    go.transform.localScale = new Vector3(scaleX, scaleY, -scaleZ);
                    break;
            }
        }
    }
}


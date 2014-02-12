﻿using UnityEngine;

namespace Assets.Src.net.kibotu.sandbox.unity.dragnslay.components.behaviours
{
    public class RotationTest : MonoBehaviour
    {
        public float radius;
        public float yoffset;
        public Transform center;
        public float circulationTerm;
        public Quaternion rotation;
        private float time;

        public Vector2 heightvariance;
        public float heightchangetime;
        private float randomHeight;
        private float heighttime;
        private float lastyoffset;
        public float height;
        public float strafeAngle;

        public void Awake() {
            yoffset = Random.Range(1f,3f);
            center = transform.parent;
            radius = Random.Range(5f,10f);
            rotation = Quaternion.identity;
            circulationTerm = Random.Range(4f,10f);
            heightvariance = new Vector2(-2f,2f);
            heightchangetime = 4f;
            strafeAngle = 10f;
        }

        public void Update()
        {
            time += Time.deltaTime;
            heighttime += Time.deltaTime;

            transform.position = GetFinalDestination();
            transform.rotation = GetFinalRotation();
        }

        public Vector3 GetFinalDestination()
        {
            height = ComputeHeightVariation();
            return RotateAroundCenterY(transform.position, time, radius, center.position, circulationTerm, height);
        }

        private float ComputeHeightVariation()
        {
            if (heighttime > heightchangetime)
            {
                heighttime = 0;
                lastyoffset = randomHeight;
                randomHeight = Random.Range(heightvariance.x, heightvariance.y) + yoffset;
            }
            return Mathf.Lerp(lastyoffset, randomHeight, heighttime / heightchangetime);
        }

        public Quaternion GetFinalRotation()
        {
            // beware this is the most complicated way i could come up with to rotate the plane along the tangent of the circle
            Vector3 targetDir = RotateAroundCenterY(transform.position, (time + circulationTerm / 360), radius, center.position, circulationTerm, height) - transform.position;
            float step = 1000 * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            Debug.DrawRay(transform.position, newDir, Color.red);
            return Quaternion.LookRotation(newDir) * Quaternion.Euler(0, 0, -strafeAngle);//*Quaternion.Euler(-90f, 0, 0) * Quaternion.Euler(0,0,90) *;
        }

        public static Vector3 RotateAroundCenterY(Vector3 position, float time, float radius, Vector3 center, float circulationTerm, float yoffset)
        {
            var circle = RotoateAroundCenter(time, radius, new Vector2(center.x, center.z), circulationTerm);
            position.x = circle.x;
            position.y = center.y + yoffset;
            position.z = circle.y;
            return position;
        }

        public static Vector2 RotoateAroundCenter(float time, float radius, Vector2 center, float circulationTerm)
        {
            var dx = center.x + (-radius * Mathf.Cos(Phi(time, circulationTerm)));
            var dy = center.y + (radius * Mathf.Sin(Phi(time, circulationTerm)));
            return new Vector2(dx, dy);
        }

        public static float Phi(float t, float tu)
        {
            return (Mathf.Abs(tu) < 0.0001f) ? 2f * Mathf.PI * t : 2f * Mathf.PI * t / tu;
        }
    }
}

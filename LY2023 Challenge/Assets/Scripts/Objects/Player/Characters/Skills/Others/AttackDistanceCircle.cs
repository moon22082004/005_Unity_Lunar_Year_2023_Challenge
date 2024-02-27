using UnityEngine;

namespace LY2023Challenge
{
    public class AttackDistanceCircle : MonoBehaviour
    {
        private LineRenderer _lineRenderer;
        private float _distance;

        public float Distance
        {
            get => _distance;
            set => _distance = value;
        }

        private void Awake()
        {
            this.transform.position = PlayerManager.Instance.Player.transform.position;
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            this.DrawCircle(100, this.Distance);
        }

        public void DrawCircle(int steps, float radius)
        {
            _lineRenderer.positionCount = steps + 1;
            for (int currentStep = 0; currentStep <= steps; currentStep++)
            {
                float circumferenceProgress = ((float)(currentStep)) / steps;
                float currentRadian = circumferenceProgress * 2 * Mathf.PI;

                float xScaled = Mathf.Cos(currentRadian);
                float yScaled = Mathf.Sin(currentRadian);

                Vector3 currentPos = new Vector3(xScaled * radius + this.transform.position.x, yScaled * radius + this.transform.position.y, 0);

                _lineRenderer.SetPosition(currentStep, currentPos);
            }
        }
    }
}
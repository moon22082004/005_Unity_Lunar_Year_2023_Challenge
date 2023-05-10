using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDistanceCircle : MonoBehaviour
{
    [SerializeField] private WoodBowSkillsExecuter _woodBowSkillsExecuter;
    [SerializeField] private Transform playerAttackPointTransform;
    private LineRenderer _lineRenderer;
    private float _distance;

    public float Distance
    {
        get => this._distance;
        set => this._distance = value;
    }

    private void Awake() 
    {
        this.transform.position = this.playerAttackPointTransform.position;
        this._lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() 
    {
        this.DrawCircle(100, this.Distance);
    }

    public void DrawCircle(int steps, float radius)
    {
        this._lineRenderer.positionCount = steps + 1;
        for (int currentStep = 0; currentStep <= steps; currentStep++ )
        {
            float circumferenceProgress = ((float)(currentStep))/steps;
            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            Vector3 currentPos = new Vector3(xScaled * radius + this.playerAttackPointTransform.position.x, yScaled * radius + this.playerAttackPointTransform.position.y, 0);

            this._lineRenderer.SetPosition(currentStep, currentPos);
        }
    }
}

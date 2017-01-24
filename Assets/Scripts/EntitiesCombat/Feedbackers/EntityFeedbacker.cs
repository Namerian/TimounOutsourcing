using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Combat;
using Events;

public abstract class EntityFeedbacker : MonoBehaviour,
    CombatEvents.IStartAttackHandler,
    CombatEvents.IEntitySubstractLife,
    CombatEvents.IImpactAttackHandler,
    CombatEvents.IStartGuardHandler,
    CombatEvents.IEndGuardHandler,
    CombatEvents.IEntityIsLowOnStamina,
    CombatEvents.IEntityIsNormalOnStamina,
    CombatEvents.IEntityIsLowOnLife,
    CombatEvents.IEntityIsNormalOnLife,
    CombatEvents.ICombatEnterHandler

{

    public float preparationScaleModifier = 0.8f;
    public Vector3 preparationModifier = new Vector3(-0.2f, 0,0);

    public float attackDuration = 0.3f;
    public Vector3 attackDirection = new Vector3(1.5f, 0, 0);
    public int attackVibra = 10;
    public float attackElasticity = 10f;

    public float hurtDuration = 0.4f;
    public Vector3 hurtDirection = new Vector3(-1, 0, 0);
    public int hurtVibra = 10;
    public float hurtElasticity = 0.5f;

    public float hurtColorDuration = 0.05f;

    public Vector3 guardRotation = new Vector3(0, 0, -20);
    public float timeToGuard = 0.1f;


    private bool IsLowStamina = false;
    private bool IsLowLife = false;
    private bool IsCurrentlyIdlying = false;
    private bool IsIdle = true;
    private bool IsGuarding = false;
    private Material _mat;
    private Transform _transform;
    

    // Use this for initialization
    void Awake () {
        _transform = GetComponent<Transform>();
        _mat = GetComponent<Renderer>().material;
        EventCenter.AddSubscriber(this);

        Initialize();
    }

    public abstract void Initialize();

    public void Cleanup()
    {
        EventCenter.RemoveSubscriber(this);
        _mat = null;
        _transform = null;
    }

    private void ClearEffect(bool newIdle, float duration = 0)
    {
        initTransform(duration);
        initColor(Color.white,duration);

        IsCurrentlyIdlying = false;
        IsIdle = newIdle;
    }

    private void initTransform(float duration = 0)
    {
        _transform.DOComplete();

        _transform.DOScale(1, duration);
        _transform.DOLocalMove(new Vector3(0, 0, 0), duration);
        _transform.DORotate(new Vector3(0, 0, 0), duration);
    }

    private void initColor(Color color, float duration = 0)
    {
        _mat.DOComplete();
        _mat.DOColor(color, duration);
    }

    public void OnCombatEnter()
    {
        IsLowLife = false;
        IsLowStamina = false;
        ClearEffect(true);
    }

    public void OnStartAttack(EntityAction parAction, Entity parOwner, Entity parTarget)
    {
        
        if (parOwner.gameObject == transform.parent.gameObject)
        {
            ClearEffect(false);

            _transform.DOScale(preparationScaleModifier, parAction.impactTime).OnComplete(() => launchAttack(parAction));
            _transform.DOLocalMove(preparationModifier, parAction.impactTime);
        }
    }

    private void launchAttack(EntityAction action)
    {
        /////////////////////////*******************************//////////////////////// NEEEDS ATTACK DURATION AS A VARIABLE/////////////////
        _transform.DOPunchPosition(attackDirection, attackDuration, attackVibra, attackElasticity).OnComplete(() => ClearEffect(true));
    }

   
    public void OnEntitySubstractLife(Entity entity, float damage)
    {
        /* Not used for now
       if (entity.gameObject == transform.parent.gameObject)
       {
           initColor(Color.white);


       }*/
    }

    public void OnImpactAttack(EntityAction parAction, Entity parOwner, Entity parTarget)
    {
        if (parTarget != null && parTarget.gameObject == transform.parent.gameObject)
        {
            if(IsGuarding)
            {
                _transform.DOPunchPosition(hurtDirection*0.5f, hurtDuration, hurtVibra, hurtElasticity);
            }
            else
            {
                ClearEffect(false);

                _mat.DOColor(Color.red, hurtColorDuration).OnComplete(() => initColor(Color.white, hurtColorDuration));
                _transform.DOPunchPosition(hurtDirection, hurtDuration, hurtVibra, hurtElasticity).OnComplete(() => ClearEffect(true));
            }

        }
    }

    public void OnStartGuard(Entity parOwner)
    {
        if (parOwner.gameObject == transform.parent.gameObject)
        {
            ClearEffect(false);

            _transform.DORotate(guardRotation, timeToGuard);
            _mat.DOColor(Color.black, hurtColorDuration);

            IsGuarding = true;
        }
    }

    public void OnEndGuard(Entity parOwner)
    {
        if (parOwner.gameObject == transform.parent.gameObject)
        {
            ClearEffect(true, timeToGuard);
            IsGuarding = false;
        }
    }

    public void OnEntityIsLowOnStamina(Entity entity)
    {
        if (entity.gameObject == transform.parent.gameObject)
        {
            IsLowStamina = true;
        }
    }

    public void OnIEntityIsNormalOnStamina(Entity entity)
    {
        if (entity.gameObject == transform.parent.gameObject)
        {
            IsLowStamina = false;
        }
    }

    public void OnEntityIsLowOnLife(Entity entity)
    {
        if (entity.gameObject == transform.parent.gameObject)
        {
            IsLowLife = true;
        }
    }

    public void OnEntityIsNormalOnLife(Entity entity)
    {
        if (entity.gameObject == transform.parent.gameObject)
        {
            IsLowLife = false;
        }
    }

    private void launchScaleBlink(Color startColor, Color endColor, float blinkDuration)
    {
        //_transform.DOScale
    }

    
    // Update is called once per frame
    void Update ()
    {
        
       if(IsIdle && !IsCurrentlyIdlying)
        {
            IsCurrentlyIdlying = true;

            _transform.DOShakePosition(Random.Range(1.2f,2f), new Vector3(0.1f,0.3f,0.1f), 1).SetLoops(-1);

            if (IsLowLife)
            {
                _transform.DOShakeScale(Random.Range(0.2f, 0.5f),new Vector3(0, 0.3f, 0),1).SetLoops(-1);
            }
            if (IsLowStamina)
            {
                _transform.DOShakeScale(Random.Range(0.4f, 1f), new Vector3(0, 0f, 0.3f), 1).SetLoops(-1);
            }
        }
    }
    


}

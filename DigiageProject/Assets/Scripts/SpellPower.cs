using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SpellPower : MonoBehaviour
{
    [SerializeField]
    enum powers
    {
        GrowUp,
        Explosion,
        Blind,
        Fly
    }
    [SerializeField] powers _pover;
    [SerializeField] ParticleSystem effect;

    // use at the player colision 
    public void UseSpellPower()
    {
        switch (_pover)
        {
            case powers.GrowUp:
                GrowUpAction();
                break;
            case powers.Explosion:
                ExceptionAction();
                break;
            case powers.Blind:
                BlindAction();
                break;
            case powers.Fly:
                FlyAction();
                break;
            default:
                break;
        }
    }
    void GrowUpAction()
    {
        transform.DOScale(new Vector3(3, 3, 3), 0.2f).OnComplete(() => EffectEnd());
    }
    void ExceptionAction()
    {
       
    }
    void BlindAction()
    {

    }
    void FlyAction()
    {

    }
    void EffectEnd()
    {

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        effect.Play();
        transform.parent = null;
    }
}

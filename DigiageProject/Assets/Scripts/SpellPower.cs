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
        transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.6f).OnComplete(() => EffectEnd());
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

        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        effect.Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        transform.parent = null;
    }
}

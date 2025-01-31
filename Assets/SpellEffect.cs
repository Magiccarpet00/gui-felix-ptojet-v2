using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SpellEffect : SpellZone
{

 

    //---------D�finition des combinaisons d'effets--------------

    public void SetSpellColliderEffect(SpellScriptableObject spell, Collider enemy) //Blink n'est pas dans cette m�thode 
    {
        foreach (string spellEffect in spell.spellEffect)
        {
            if (spellEffect == "Dommage")
            {
                GameManager.instance.dammageEffectScript.DammageEffect(spell,enemy);
            }
            if (spellEffect == "Slow")
            {
                GameManager.instance.slowEffectScript.SlowEffect(spell, enemy);
            }
            if (spellEffect == "Dot")
            {
                foreach (Collider hitEnemies in collidersInZone)
                {
                    Debug.Log(collidersInZone.Count);
                    GameManager.instance.dotEffectScript.DotEffect(spell, enemy);


                }

            }

        }
    
    }

    public void SetSpellNoColliderEffect(SpellScriptableObject spell, Vector3 interpolatePos)
    {
        
        foreach (string spellEffect in spell.spellEffect)
        {
            if (spellEffect == "Blink")
            {
                GameManager.instance.blinkEffectScript.BlinkEffect(spell, interpolatePos);

            }
            if (spellEffect == "Hot")
            {
                GameManager.instance.hotEffectScript.HotEffect(spell);

            }
        }
           
    }

    }





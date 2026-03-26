
using System.Collections.Generic;
using UnityEngine;

public class Player :MonoBehaviour
{
    public Skill Target;

    public int Level;

    public List<Skill> LearndSkills;
    private void Start()
    {
        //CheckName(Target);


        

    }

    public void CheckName(Skill target)
    {
        if(target == null)
        {
            Debug.LogWarning("Target skill is null.");
            return;
        }

        SkillManager.Instance.NameOfSkill(target);
    }


    public void TryToLearnSkill(Skill target)
    {
        if( SkillManager.Instance.TryLearnSkill(this, target, out Skill result))
        {
          
            if(LearndSkills.Contains(target))
            {
                Debug.Log("Ya has aprendido esta habilidad");
                return;
            }
            LearndSkills.Add(result);
            Debug.Log("Haiblidad añadida");
        }
        else
        {
            Debug.Log("Cant learn right now :C , requieres el nivel"+ target.LevelRestriction);
        }
    }



}

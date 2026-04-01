using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Skill Target;

    public int Level;

    public List<Skill> LearndSkills;
    private void Start()
    {
        // Simulación del flujo de gameplay

        // Recorrer todas las habilidades y verificar si se pueden aprender
        foreach (var skill in SkillManager.Instance.SkillList)
        {
            bool canLearn = SkillManager.ValidateCondition(skill, s => Level >= s.LevelRestriction);
            Debug.Log($"¿Puede aprender {skill.SkillName}? {canLearn}");
        }

        // Intentar aprender una habilidad específica
        Skill targetSkill = SkillManager.Instance.SkillList[0]; // Ejemplo: primera habilidad de la lista
        TryToLearnSkill(targetSkill);

        // Recorrer habilidades aprendidas
        foreach (var learnedSkill in LearndSkills)
        {
            Debug.Log($"Habilidad aprendida: {learnedSkill.SkillName}");
        }

        // Ejecutar una acción con una habilidad
        SkillManager.ExecuteAction(targetSkill, skill => Debug.Log($"Ejecutando habilidad: {skill.SkillName}"));

        // Buscar una habilidad específica sin usar el resultado
        if (SkillManager.TryFind(SkillManager.Instance.SkillList.ToArray(), s => s.SkillName == "Fireball", out _))
        {
            Debug.Log("Habilidad Fireball encontrada.");
        }
        else
        {
            Debug.Log("Habilidad Fireball no encontrada.");
        }
    }

    public void CheckName(Skill target)
    {
        if (target == null)
        {
            Debug.LogWarning("Target skill is null.");
            return;
        }

        SkillManager.Instance.NameOfSkill(target);
    }


    public void TryToLearnSkill(Skill target)
    {
        if (SkillManager.Instance.TryLearnSkill(this, target, out Skill result))
        {

            if (LearndSkills.Contains(target))
            {
                Debug.Log("Ya has aprendido esta habilidad");
                return;
            }
            LearndSkills.Add(result);
            Debug.Log("habilidad añadida");
        }
        else
        {
            Debug.Log("Cant learn right now :C , requieres el nivel" + target.LevelRestriction);
        }
    }



}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Blizzard : SkillTrig {
    
    public override void use_active (){
        InGameObject _owner = gameObject.GetComponent <InGameObject> ();

        ContObj.I.change_velocity (_owner, new Vector2 (0, 0));
        _owner.isAtk = true;
        _owner.toAnim = 1;
        
        Vector2 _pos = gameObject.transform.position;
        
        InGameObject _msl = ContObj.I.create_obj ("blizzardDummy", _pos, _owner.owner).GetComponent <InGameObject> ();
        _msl.timedLife = 10f;
        _msl.controllerID = _owner.id;
    }
}

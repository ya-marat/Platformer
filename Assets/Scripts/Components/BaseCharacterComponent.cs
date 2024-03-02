using System;

public abstract class BaseCharacterComponent
{
    public virtual void InitComponent(ICharacterEntity characterEntity){}
    public virtual void UpdateComponent(ICharacterEntity characterEntity){}
    public virtual void FixedUpdateComponent(ICharacterEntity characterEntity){}
}

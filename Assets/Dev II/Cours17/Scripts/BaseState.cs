public abstract class BaseState
{
    //All the class that inherit from Base state will have to implement their own Enter,Update,Exit function 
    //since those function are abstract
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

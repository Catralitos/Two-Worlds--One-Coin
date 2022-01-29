# Unity-StateMachines

This Unity package contains core classes intended to be used for the creation of entities that implement a state-machine pattern in Unity projects. This can be useful for the creation of enemies and other NPCs.

## Installation

To add this package to a Unity project, clone this repository into the project's Assets folder. It can also be done by importing the Unity Packace found in this repository's releases section.

## Usage

To create a behaviour that implements the state-machine pattern, it should inherit from the StateMachineBehaviour class. This is not necessary, but this class already has some base functions and members that facilitate this implementation. An example of such an implementation can be found in [PingPong.cs](Assets/StateMachines/Examples/PingPong/PingPong.cs), shown below:

```csharp
public class PingPong : StateMachineBehaviour<PingPong>
{
    public float TimeBetweenStates;

    protected override void Start()
    {
        state = PingState.Create(this);
    }
}
```

Each state of the entity should be defined as its own class, inheriting from the implementation of the generic `State` class of that entity's type. Although not necessary, a base class can be created for all states of this entity to inherit from:

```csharp
public abstract class PingPongState : State<PingPong>
{
    protected static new T Create<T>(PingPong target) where T : PingPongState
    {
        T state = State<PingPong>.Create<T>(target);
        return state;
    }
}
```

The pattern shown in the `Create<T>` function above can be used to pass parameters from the state's target entity to the state being created, or any other external parameters that the state may require. This serves as a way to "construct" the state without overriding Unity's underlying MonoBehaviour initialization.

The `State` class has several virtual methods that facilitate the implementation of each state's behaviour. `StateUpdate` is akin to Unity's `Update` function, being called every frame. `Initialize` is akin to Unity's `Start` function, being called right before a state's first update occurs (on the first frame in which the state is active). `SetState` can be used to transition an entity to a new state. An example of such an implementation can be found in [PingState.cs](Assets/StateMachines/Examples/PingPong/PingState.cs) and [PongState.cs](Assets/StateMachines/Examples/PingPong/PongState.cs):

```csharp
public class PingState : PingPongState
{
    float t = 0;

    public override void StateUpdate()
    {
        t += Time.deltaTime;
        textField.text = $"Ping {string.Format("{0:0.00}", t)}";

        if (t > target.TimeBetweenStates)
        {
            SetState(PongState.Create(target));
        }
    }

    public static PingState Create(PingPong target)
    {
        return PingPongState.Create<PingState>(target);
    }
}
```
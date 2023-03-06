### BehaviorController (Composite Pattern)

##### Participants
- Component: `SteeringBehavior`
- Leaf: `SeekBehavior`, `WanderBehavior`, ...
- Composite: `BehaviorController`

```
                  +-------------------+
                  | SteeringBehavior  |
                  +-------------------+
                          ^     
            +-------------|------------+         
            |             |            |       
+-----------------+ +-------------------+ 
| SeekBehavior    | | WanderBehavior    | + ...  
+-----------------+ +-------------------+
            |             |            |       
            +-------------|------------+       
                          v     
                +--------------------+
                | BehaviorController |
                +--------------------+
```
##### Collaborations
`BehaviorController` maintains a list of `SteeringBehavior` objects and manages their execution by calling `GetForce()` to obtain the total force to apply to the object it controls.

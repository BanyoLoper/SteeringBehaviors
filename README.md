# SteeringBehaviors v0.4.3
Unity Scripts for adding Steering Behaviors to Game Objects.

### Behaviors Supported

- `Seek`: **Transform** dependent, no arrival included.
- `Run Away`: **Seek()** dependent.
- `Arrival`: **Slowing Radius** dependent.
- `Wander`: **Coroutine** dependent.
- `Pursuit`: **Seek** and order in Behavior controller dependent.

More behaviors will be added soon:
- Evade
- Collision Avoid
- Path following
- Leader Following
- Queue

### Installation
There are 2 versions of the code, the current that's all in one script (old) and the Composite Version (WIP)

Notice that shaders needs URP.

Current (old)
1. Clone the repository
`
git clone https://github.com/BanyoLoper/SteeringBehaviors.git
`
2. Add the script `SteeringBehaviors.cs` to your GameObject.
3. Set up the parameters it needs.
4. Run the game.

New (WIP)
1. Clone the repository
`
git clone https://github.com/BanyoLoper/SteeringBehaviors.git
`
2. Add the script `BehaviorController.cs` to your GameObject.
3. Add any `Behhavior` such as `SeekBehavior.cs`
4. Assign the `Behavior` to `BehaviorsList` in `BehaviorController`
5. Set up the parameters you need.
6. Run the game

### Collaboration
Feel free to collaborate, this is a public repo made principally for Game Development students.
If you need DM and request the access, still you'll need to create a PR.





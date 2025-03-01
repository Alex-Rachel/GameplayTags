# GameplayTags
[![license](https://img.shields.io/github/license/Alex-Rachel/GameplayTags.svg)](https://github.com/Alex-Rachel/GameplayTags/blob/main/LICENSE) 
[![last](https://img.shields.io/github/last-commit/Alex-Rachel/GameplayTags.svg)](https://github.com/Alex-Rachel/GameplayTags)
[![issue](https://img.shields.io/github/issues/Alex-Rachel/GameplayTags.svg)](https://github.com/Alex-Rachel/GameplayTags/issues)
[![topLanguage](https://img.shields.io/github/languages/top/Alex-Rachel/GameplayTags.svg)](https://github.com/Alex-Rachel/GameplayTags)


GameplayTags for C#/Unity. 

A A High performance of GameplayTags implementation for C# or Unity. Gameplay tags are a flexible and efficient way to handle and categorize gameplay-related properties and states.

## As U Know
GameplayTag :Gameplaytag can extend a lot of functionality. It`s a struct that optimizes network transport with runtimeindex. U Must Need Define in Code. It Could not add a define in runtime.

GameplayTagContainer: It's a container that you'll usually use in your game, and it holds a collection of GamePlaytags on this object.

## Basic Usage

Gameplay tags are registered through attributes in the assembly. Here is an example:

```csharp
// Need Define in Code.
[assembly: GameplayTag("Ability")]
[assembly: GameplayTag("Ability.CanAttack")]
[assembly: GameplayTag("Ability.CanAttack.CanCrit")]
[assembly: GameplayTag("Ability.CanHurt")]
[assembly: GameplayTag("State")]
[assembly: GameplayTag("State.Buff")]
[assembly: GameplayTag("State.DeBuff")]
[assembly: GameplayTag("State.Buff.AddAttribute")]
[assembly: GameplayTag("State.DeBuff.DeAttribute")]
```
### GameplayTagCountContainer

`GameplayTagCountContainer` is a class used to manage gameplay tags with event callbacks for tag count changes. Here’s how to use it:

#### Creating a Tag Container

```csharp
GameplayTagCountContainer tagContainer = new GameplayTagCountContainer();
```
#### Adding a Tag To Container

```csharp
GameplayTag tag = GameplayTagManager.RequestTag("ExampleTag");
tagContainer.AddTag(tag);
```

#### Removing a Tag

```csharp
tagContainer.RemoveTag(tag);
```

#### Registering a Callback for Tag Changes

```csharp
void OnTagChanged(GameplayTag tag, int newCount)
{
    Debug.Log($"Tag {tag.Name} count changed to {newCount}");
}

tagContainer.RegisterTagEventCallback(tag, GameplayTagEventType.AnyCountChange, OnTagChanged);
```

#### Removing a Callback

```csharp
tagContainer.RemoveTagEventCallback(tag, GameplayTagEventType.AnyCountChange, OnTagChanged);
```

#### Querying the Count of a Tag

```csharp
int tagCount = tagContainer.GetTagCount(tag);
Debug.Log($"Tag {tag.Name} has a count of {tagCount}");
```

#### Clearing All Tags

```csharp
tagContainer.Clear();
```

### GameplayTagContainer

`GameplayTagContainer` is a class for storing a collection of gameplay tags. It is serializable and provides a user-friendly interface in the Unity editor.

#### Creating a Tag Container

```csharp
GameplayTagContainer tagContainer = new GameplayTagContainer();
```

#### Adding a Tag

```csharp
GameplayTag tag = GameplayTagManager.RequestTag("ExampleTag");
tagContainer.AddTag(tag);
// or 
tagContaier.AddTag("ExampleTag");
```

#### Removing a Tag

```csharp
tagContainer.RemoveTag(tag);
```

#### Clearing All Tags

```csharp
tagContainer.Clear();
```

### Union and Intersection Operations

Union and intersection operations can be performed on any type of container that implements `IGameplayTagContainer`. These operations can be used to create new `GameplayTagContainer` instances.

#### Creating a Union of Tag Containers

```csharp
GameplayTagContainer union = GameplayTagContainer.Union(container1, container2);
```

#### Creating an Intersection of Tag Containers

```csharp
GameplayTagContainer intersection = GameplayTagContainer.Intersection(container1, container2);
```

## Differences between GameplayTagCountContainer and GameplayTagContainer

- **GameplayTagCountContainer**: Focuses on managing tags with the ability to register callbacks for when tag counts change. It is useful when you need to respond to tag count changes.
- **GameplayTagContainer**: Designed to store a collection of tags, it is serializable and offers a user-friendly interface in the Unity editor. It provides basic tag management without the event-driven functionality of `GameplayTagCountContainer`.

## AllGameplayTags Generated Class

A Source Generator provides access to any gameplay tag declared within the current assembly without requiring a dedicated field to store the tag value. This approach eliminates the need to repeatedly call `GameplayTagManager.RequestTag`. For example, the gameplay tag "A.B.C" can be accessed through `AllGameplayTags.A.B.C.Get()`, simplifying tag retrieval and enhancing performance by avoiding redundant tag requests. [Read More](Documentation~/CodeGeneration.md).


## Thanks for GameplayTags of BandoWare. This Project base of it.
GameplayTags:https://github.com/BandoWare/GameplayTags


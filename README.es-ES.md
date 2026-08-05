

# GameplayTags
[![license](https://img.shields.io/github/license/Alex-Rachel/GameplayTags.svg)](https://github.com/Alex-Rachel/GameplayTags/blob/main/LICENSE) 
[![last](https://img.shields.io/github/last-commit/Alex-Rachel/GameplayTags.svg)](https://github.com/Alex-Rachel/GameplayTags)
[![issue](https://img.shields.io/github/issues/Alex-Rachel/GameplayTags.svg)](https://github.com/Alex-Rachel/GameplayTags/issues)
[![topLanguage](https://img.shields.io/github/languages/top/Alex-Rachel/GameplayTags.svg)](https://github.com/Alex-Rachel/GameplayTags)


GameplayTags para C#/Unity. 

Una implementación de alto rendimiento de GameplayTags para C# o Unity. Los tags de jugabilidad son una forma flexible y eficiente de manejar y categorizar propiedades y estados relacionados con la jugabilidad.

## Como Ya Sabrás
GameplayTag: El tag de jugabilidad puede extender muchas funcionalidades. Es un struct que optimiza el transporte de red mediante runtimeindex. Debes definirlo en el código. No se puede añadir una definición en tiempo de ejecución.

GameplayTagContainer: Es un contenedor que generalmente usarás en tu juego y mantiene una colección de GameplayTags en este objeto.

## Uso Básico

Los tags de jugabilidad se registran a través de atributos en el ensamblado. Aquí tienes un ejemplo:

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

`GameplayTagCountContainer` es una clase utilizada para gestionar tags de jugabilidad con callbacks de eventos para cambios en la cantidad de tags. Aquí se explica cómo usarla:

#### Creación de un Contenedor de Tags

```csharp
GameplayTagCountContainer tagContainer = new GameplayTagCountContainer();
```
#### Agregar un Tag al Contenedor

```csharp
GameplayTag tag = GameplayTagManager.RequestTag("ExampleTag");
tagContainer.AddTag(tag);
```

#### Eliminar un Tag

```csharp
tagContainer.RemoveTag(tag);
```

#### Registrar un Callback para Cambios en Tags

```csharp
void OnTagChanged(GameplayTag tag, int newCount)
{
    Debug.Log($"Tag {tag.Name} count changed to {newCount}");
}

tagContainer.RegisterTagEventCallback(tag, GameplayTagEventType.AnyCountChange, OnTagChanged);
```

#### Eliminar un Callback

```csharp
tagContainer.RemoveTagEventCallback(tag, GameplayTagEventType.AnyCountChange, OnTagChanged);
```

#### Consultar la Cantidad de un Tag

```csharp
int tagCount = tagContainer.GetTagCount(tag);
Debug.Log($"Tag {tag.Name} has a count of {tagCount}");
```

#### Limpiar Todos los Tags

```csharp
tagContainer.Clear();
```

### GameplayTagContainer

`GameplayTagContainer` es una clase para almacenar una colección de tags de jugabilidad. Es serializable y proporciona una interfaz amigable para el usuario en el editor de Unity.

#### Creación de un Contenedor de Tags

```csharp
GameplayTagContainer tagContainer = new GameplayTagContainer();
```

#### Agregar un Tag

```csharp
GameplayTag tag = GameplayTagManager.RequestTag("ExampleTag");
tagContainer.AddTag(tag);
// or 
tagContaier.AddTag("ExampleTag");
```

#### Eliminar un Tag

```csharp
tagContainer.RemoveTag(tag);
```

#### Limpiar Todos los Tags

```csharp
tagContainer.Clear();
```

### Operaciones de Unión e Intersección

Las operaciones de unión e intersección se pueden realizar en cualquier tipo de contenedor que implemente `IGameplayTagContainer`. Estas operaciones pueden utilizarse para crear nuevas instancias de `GameplayTagContainer`.

#### Crear una Unión de Contenedores de Tags

```csharp
GameplayTagContainer union = GameplayTagContainer.Union(container1, container2);
```

#### Crear una Intersección de Contenedores de Tags

```csharp
GameplayTagContainer intersection = GameplayTagContainer.Intersection(container1, container2);
```

## Diferencias entre GameplayTagCountContainer y GameplayTagContainer

- **GameplayTagCountContainer**: Se centra en la gestión de tags con la capacidad de registrar callbacks para cuando cambie la cantidad de tags. Es útil cuando necesitas responder a cambios en la cantidad de tags.
- **GameplayTagContainer**: Diseñado para almacenar una colección de tags, es serializable y ofrece una interfaz amigable para el usuario en el editor de Unity. Proporciona gestión básica de tags sin la funcionalidad basada en eventos de `GameplayTagCountContainer`.

## Clase Generada AllGameplayTags

Un Source Generator proporciona acceso a cualquier tag de jugabilidad declarado dentro del ensamblado actual sin requerir un campo dedicado para almacenar el valor del tag. Este enfoque elimina la necesidad de llamar repetidamente a `GameplayTagManager.RequestTag`. Por ejemplo, el tag de jugabilidad "A.B.C" puede accederse a través de `AllGameplayTags.A.B.C.Get()`, simplificando la recuperación de tags y mejorando el rendimiento al evitar solicitudes redundantes. [Leer Más](Documentation~/CodeGeneration.md).


## Gracias por GameplayTags de BandoWare. Este proyecto se basa en él.
GameplayTags:https://github.com/BandoWare/GameplayTags

using System;

namespace GameplayTags
{
   public enum GameplayTagFlags
   {
      None = 0,

      [Obsolete("It should be removed soon")]
      HideInEditor = 1 << 0,
   }
}
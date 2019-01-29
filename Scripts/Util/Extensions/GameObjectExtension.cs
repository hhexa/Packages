using UnityEngine;

public static class GameObjectExtension
{
    public static T Get<T>(this GameObject gameObject) where T : Component
    {
        T result = gameObject.GetComponent<T>();
        if (result == null)
            result = gameObject.AddComponent<T>();
        return result;
    }
}

/*
      Comment on this method by a user ( I havent tested this personally though ) :

      public static T Get<T>(this GameObject gameObject) where T : Component
      {
          return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
      }

      Interesting read, something i will point out though, using:
      return gameObject.GetComponent() ?? gameObject.AddComponent();
      Will not react as expected due to the null-coalescing (??) operator doing a reference comparison to null. UnityEngine.Object s never really equal null, just a special ‘null’ object (which the == operator is overloaded to check for). So in this case if the component doesnt exist it will just return the ‘null’ object, rather than adding the component.
      This also occurs on the null-conditional operator (?.) which makes them, unfortunately, mostly useless in unity.
*/

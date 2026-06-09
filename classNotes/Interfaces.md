# Software Design II
## Interfaces
- construct that defines a contract for classes to follow
- class includes blueprint for building object and implementations (defines abilities)
- **Interface is NOT a class!**
  - rather than acting as blueprint, acts as contract  
    ```csharp 
    public interface IFlyable{
      void Fly();
      string Signal();
    }
    ```
  - -able suffix preferred; "I" prefix also helps denote Interface as well
  - Declares abilities

```csharp
public interface Ismartphone{
  void BowseInternet();
  void MakePhoneCall();
  void SendTextMessage(string msg);
}

public class Phone {
// ...
}

public class LandLinePhone: Phone {
  // ...
}
public class FlipPhone : Phone {
  // ...
}
public class iPhone : Phone, ISmartphone{
  // ...
}
public class Android : Phone, ISmartphone{
  // ...
}
```
- allows defining relationships regardless of inheritance tree
- allows for multiple interfaces
- class must be listed first, followed by interfaces
- allows you to disregard underlying type
  - use as a datatype to group rather than using the class datatype


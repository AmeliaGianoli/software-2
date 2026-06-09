Airplane plane = new Airplane { };

// CANNOT instantiate an interface
// IFlyable flyingThing = new IFlyable { };

// can use as a datatype:
IFlyable flyingThing = new Airplane { };

flyingThing = new Bird { };
flyingThing = new BaldEagle { };


BaldEagle eagle = new BaldEagle { };
eagle.Fly();


/**********************************
Adding to list
*********************************/


List<IFlyable> flyableList = new List<IFlyable>
{
  //   planeOne,  
  // 
  //   birdOne,
  //   birdTwo,
  //   birdThree,

  // // following inherit from Bird:
  //   baldEagleOne,
  //   baldEagleTwo

};


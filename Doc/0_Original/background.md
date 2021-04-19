# Unit Testing DOJO
## Background

Hi my name is Mulon Esk, Billionaire, Rocketry enthusiast and definitely not a lizard person trying to return home to Mars.

My company, SpaceY (because, Y not?), has been trying to launch our latest rocket prototype into orbit, however we keep running into problems at launch and RUDs (Rapid unscheduled disassemblies) are expensive.

We have decided to contract you to help test some of our simulation software.

### Diagram (MarsOrBust9)
![Rocket]("Rocket.jpg")

### Materials list
- 1 x Rocket (frame)
- 1 x Rocket Engine
- 2 x Fuel Tanks

### Equipment
- 1 x Rocket assembler
- 1 x Refueler


### Problems
1. The Fuel tanks explode.
2. The Rocket won't start.
3. Mars is too far away

### Extras
- NUnit features
    - Update `FuelTankRupturesAboveMaxAmount` to test values for both `Oxygen` and `Methane` 

- AutoMoq features
    - Update `Create_Fuel_Tank` and mock out the `CreateFuelTank` on `IFuelTankAssemblyService`.
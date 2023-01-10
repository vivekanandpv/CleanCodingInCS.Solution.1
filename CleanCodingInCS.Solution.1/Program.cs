using System;

// Problem:
// Evolve a Truck class according to SOLID principles with following functionalities: Start, stop, turn left, turn right, reverse, honk
// Create a dynamic system where the parts are externally configured from the client.
// Implement different engines (Diesel, hydrogen, hybrid, electric) and let the client choose the different engines in the runtime.


namespace CleanCodingInCS.Solution {
    class Program {
        static void Main(string[] args) {
            IEngine engine = new DieselEngine();
            ISteering steering = new PowerSteering();
            IHorn horn = new ElectricHorn();
            
            ITruck truck = new Truck(engine, steering, horn);
            
            truck.Start();
            truck.Stop();
            
            truck.SetEngine(new HybridEngine());
            
            truck.Start();
            truck.Stop();
        }
    }

    interface ITruck {
        void Start();
        void Stop();
        void TurnLeft();
        void TurnRight();
        void Honk();
        void SetEngine(IEngine engine);
    }

    interface IEngine {
        void Start();
        void Stop();
    }

    interface ISteering {
        void TurnLeft();
        void TurnRight();
    }

    interface IHorn {
        void Honk();
    }

    class DieselEngine : IEngine {
        public void Start() {
            Console.WriteLine("Diesel engine starts");
        }

        public void Stop() {
            Console.WriteLine("Diesel engine stops");
        }
    }
    
    class HydrogenEngine : IEngine {
        public void Start() {
            Console.WriteLine("Hydrogen engine starts");
        }

        public void Stop() {
            Console.WriteLine("Hydrogen engine stops");
        }
    }
    
    class HybridEngine : IEngine {
        public void Start() {
            Console.WriteLine("Hybrid engine starts");
        }

        public void Stop() {
            Console.WriteLine("Hybrid engine stops");
        }
    }
    
    class ElectricEngine : IEngine {
        public void Start() {
            Console.WriteLine("Electric engine starts");
        }

        public void Stop() {
            Console.WriteLine("Electric engine stops");
        }
    }

    class PowerSteering : ISteering {
        public void TurnLeft() {
            Console.WriteLine("Power steering turns left");
        }

        public void TurnRight() {
            Console.WriteLine("Power steering turns right");
        }
    }

    class ElectricHorn : IHorn {
        public void Honk() {
            Console.WriteLine("Electric horn honks");
        }
    }

    class Truck : ITruck {
        public IEngine Engine { get; set; }
        public ISteering Steering { get; set; }
        public IHorn Horn { get; set; }

        public Truck(IEngine engine, ISteering steering, IHorn horn) {
            Engine = engine;
            Steering = steering;
            Horn = horn;
        }

        public void Start() {
            Engine.Start();
            Console.WriteLine("Truck starts...");
        }

        public void Stop() {
            Engine.Stop();
            Console.WriteLine("Truck stops...");
        }

        public void TurnLeft() {
            Steering.TurnLeft();
        }

        public void TurnRight() {
            Steering.TurnRight();
        }

        public void Honk() {
            Horn.Honk();
        }

        public void SetEngine(IEngine engine) {
            Engine = engine;
        }
    }
}
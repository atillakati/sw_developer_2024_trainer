using System;

namespace VererbungGL
{
    public class Vehicle
    {
        private string _description;
        private ConsoleColor _color;
        private int _maxSpeed;
        private int _currentSpeed;
        private DateTime _dateOfManufacture;
       
        //custom ctor
        public Vehicle(string description, int maxSpeed, DateTime dateOfManufacture)
            : this(description, maxSpeed, dateOfManufacture, ConsoleColor.White)
        {            
        }

        public Vehicle(string description, int maxSpeed, DateTime dateOfManufacture, ConsoleColor color)
        {
            _maxSpeed = maxSpeed;
            _description = description;
            _dateOfManufacture = dateOfManufacture;

            _color = color;
            _currentSpeed = 0;
        }


        public DateTime DateOfManufacture
        {
            get { return _dateOfManufacture.Date; }
        }

        public int Age
        {
            get { return DateTime.Now.Year - _dateOfManufacture.Year; }
        }

        public string Description
        {
            get { return _description; }
        }

        public ConsoleColor Color
        {
            get { return _color; }
            set
            {
                _color = value;
            }
        }

        public int MaxSpeed
        {
            get { return _maxSpeed; }
        }

        public int CurrentSpeed
        {
            get { return _currentSpeed; }
        }


        public void DisplayInfo()
        {
            Console.ForegroundColor = _color;
            Console.WriteLine($"{_description}: {_currentSpeed} / {_maxSpeed} km/h");

            Console.ResetColor();
        }

        public void SpeedUp(int deltaSpeed)
        {
            if (_currentSpeed + deltaSpeed <= _maxSpeed &&
                _currentSpeed + deltaSpeed > 0)
            {
                //update current speed
                _currentSpeed += deltaSpeed;
            }
        }
    }
}

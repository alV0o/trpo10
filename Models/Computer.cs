using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trpo10.Models
{
    public interface IPrototype
    {
        public IPrototype Clone();
    }
    public class Computer : IPrototype
    {
        public string CPU { get; set; }
        public int RAM { get; set; }
        public int SSD { get; set; }
        public string GraphicsCard { get; set; }

        public IPrototype Clone()
        {
            Computer computer = new();
            computer.CPU = CPU;
            computer.RAM = RAM;
            computer.SSD = SSD;
            computer.GraphicsCard = GraphicsCard;
            return computer;
        }
    }

    public class ComputerBuilder
    {
        private string _cpu = "";
        private int _ram = 0;
        private int _ssd = 0;
        private string _graphicsCard = "";
        public ComputerBuilder SetCPU(string cpu)
        {
            _cpu = cpu;
            return this;
        }
        public ComputerBuilder SetRAM(int ram)
        {
            _ram = ram;
            return this;
        }
        public ComputerBuilder SetSSD(int ssd)
        {
            _ssd = ssd;
            return this;
        }
        public ComputerBuilder SetGraphicsCard(string graphicsCard)
        {
            _graphicsCard = graphicsCard;
            return this;
        }
        public Computer Build()
        {
            Computer computer = new();
            computer.CPU = _cpu;
            computer.RAM = _ram;
            computer.SSD = _ssd;
            computer.GraphicsCard = _graphicsCard;
            if (String.IsNullOrWhiteSpace(_cpu) ||
                _ram == 0 ||
                _ssd == 0 ||
                String.IsNullOrWhiteSpace(_graphicsCard))
                throw new Exception("Требуется добавить все данные");
            return computer;
        }
    }
}

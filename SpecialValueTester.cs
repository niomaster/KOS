﻿namespace kOS
{
    public class SpecialValueTester : SpecialValue
    {
        readonly CPU cpu;

        public SpecialValueTester(CPU cpu)
        {
            this.cpu = cpu;
        }

        public override string ToString()
        {
            return "3";
        }

        public override object GetSuffix(string suffixName)
        {
            switch (suffixName)
            {
                case "A":
                    return cpu.SessionTime;
            }

            return base.GetSuffix(suffixName);
        }
    }
}

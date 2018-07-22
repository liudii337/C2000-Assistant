using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Modles
{
    public class Regs
    {
        public string Name { get; set; }
        public RegCategoly Categoly { get; set; }
        public string ImageFile { get; set; }

        public Regs(string name, RegCategoly categoly)
        {
            Name = name;
            Categoly = categoly;
            //名字最后一个若为H的话，说明其为高位，应考虑到这种情况
            if (name[name.Length - 1] == 'H')
            {  name.TrimEnd('H');}
            ImageFile = string.Format("/Assets/{0}/{1}.png", categoly.ToString().ToLower(), name);
        }

        public Regs(string name, RegCategoly categoly, string sub_name)
        {
            Name = name;
            Categoly = categoly;
            //名字最后一个若为H的话，说明其为高位，应考虑到这种情况
            if (name[name.Length - 1] == 'H')
            { name.TrimEnd('H'); }
            ImageFile = string.Format("/Assets/{0}/{1}.png", categoly.ToString().ToLower(), sub_name);
        }
    }

    public enum RegCategoly
    {
        CPUTimer,
        SYSCTRL,
        PIE,
        GPIO,
        ePWM,
        eCAP,
        eQEP,
        ADC,
        SCI,
        SPI,
        CAN,
        McBSP,
        XINTF,
        DMA,
        I2C
    }
}

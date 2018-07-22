using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Modles
{
    class RegManager
    {
        private static List<Regs> GetRegs()
        {
            var regs = new List<Regs>();

            regs.Add(new Regs("TIMERxTIM", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTIMH", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxPRD", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxPRDH", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTCR", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTPR", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTPRH", RegCategoly.CPUTimer));

            regs.Add(new Regs("PLLSTS", RegCategoly.SYSCTRL));
            regs.Add(new Regs("HISPCP", RegCategoly.SYSCTRL));
            regs.Add(new Regs("LOSPCP", RegCategoly.SYSCTRL));
            regs.Add(new Regs("LPMCR0", RegCategoly.SYSCTRL));
            regs.Add(new Regs("PCLKCR0", RegCategoly.SYSCTRL));
            regs.Add(new Regs("PCLKCR1", RegCategoly.SYSCTRL));
            regs.Add(new Regs("PCLKCR3", RegCategoly.SYSCTRL));
            regs.Add(new Regs("PLLCR", RegCategoly.SYSCTRL));
            regs.Add(new Regs("SCSR", RegCategoly.SYSCTRL));
            regs.Add(new Regs("WDCNTR", RegCategoly.SYSCTRL));
            regs.Add(new Regs("WDKEY", RegCategoly.SYSCTRL));
            regs.Add(new Regs("WDCR", RegCategoly.SYSCTRL));

            regs.Add(new Regs("PIECTRL", RegCategoly.PIE));
            regs.Add(new Regs("PIEACK", RegCategoly.PIE));
            regs.Add(new Regs("PIEIER", RegCategoly.PIE));
            regs.Add(new Regs("PIEIFR", RegCategoly.PIE));

            regs.Add(new Regs("GPAMUX1", RegCategoly.GPIO));
            regs.Add(new Regs("GPAMUX2", RegCategoly.GPIO));
            regs.Add(new Regs("GPBMUX1", RegCategoly.GPIO));
            regs.Add(new Regs("GPBMUX2", RegCategoly.GPIO));
            regs.Add(new Regs("GPCMUX1", RegCategoly.GPIO));
            regs.Add(new Regs("GPCMUX2", RegCategoly.GPIO));
            regs.Add(new Regs("GPACTRL", RegCategoly.GPIO));
            regs.Add(new Regs("GPBCTRL", RegCategoly.GPIO));
            regs.Add(new Regs("GPAQSEL1", RegCategoly.GPIO));
            regs.Add(new Regs("GPAQSEL2", RegCategoly.GPIO));
            regs.Add(new Regs("GPBQSEL1", RegCategoly.GPIO));
            regs.Add(new Regs("GPBQSEL2", RegCategoly.GPIO));
            regs.Add(new Regs("GPADIR", RegCategoly.GPIO));
            regs.Add(new Regs("GPBDIR", RegCategoly.GPIO));
            regs.Add(new Regs("GPCDIR", RegCategoly.GPIO));
            regs.Add(new Regs("GPAPUD", RegCategoly.GPIO));
            regs.Add(new Regs("GPBPUD", RegCategoly.GPIO));
            regs.Add(new Regs("GPCPUD", RegCategoly.GPIO));
            regs.Add(new Regs("GPADAT", RegCategoly.GPIO));
            regs.Add(new Regs("GPBDAT", RegCategoly.GPIO));
            regs.Add(new Regs("GPCDAT", RegCategoly.GPIO));
            regs.Add(new Regs("GPASET", RegCategoly.GPIO));
            regs.Add(new Regs("GPBSET", RegCategoly.GPIO));
            regs.Add(new Regs("GPCSET", RegCategoly.GPIO));
            regs.Add(new Regs("GPACLEAR", RegCategoly.GPIO, "GPASET"));
            regs.Add(new Regs("GPBCLEAR", RegCategoly.GPIO, "GPBSET"));
            regs.Add(new Regs("GPCCLEAR", RegCategoly.GPIO, "GPCSET"));
            regs.Add(new Regs("GPATOGGLE", RegCategoly.GPIO, "GPASET"));
            regs.Add(new Regs("GPBTOGGLE", RegCategoly.GPIO, "GPBSET"));
            regs.Add(new Regs("GPCTOGGLE", RegCategoly.GPIO, "GPCSET"));
            regs.Add(new Regs("GPIOLPMSEL", RegCategoly.GPIO));
            regs.Add(new Regs("GPIOXINTnSEL", RegCategoly.GPIO));
            regs.Add(new Regs("GPIOXNMISEL", RegCategoly.GPIO));

            string[] list_ePWM = { "TBPRD", "TBPHS","TBCTR","TBCTL","TBSTS","TBPHSHR",
                                "CMPA","CMPB","CMPCTL","CMPAHR",
                                "AQCTLA","AQCTLB","AQSFRC","AQCSFRC",
                                "DBCTL","DBRED","DBFED","PCCTL",
                                "TZSEL","TZCTL","TZEINT","TZFLG","TZCLR","TZFRC",
                                "ETSEL","ETPS","ETFLG","ETCLR","ETFRC","HRCNFG"};
            foreach(var item in list_ePWM)
            {
                regs.Add(new Regs(item, RegCategoly.ePWM));
            }

            string[] list_eCAP = { "TSCTR", "CTRPHS","CAP1","CAP2","CAP3","CAP4",
                                "ECCTL1","ECCTL2","ECEINT","ECFLG","ECCLR","ECFRC"};
            foreach (var item in list_eCAP)
            {
                regs.Add(new Regs(item, RegCategoly.eCAP));
            }
            regs.Add(new Regs("TIMERxTIM", RegCategoly.PIE));

            string[] list_eQEP = { "QEDCCTL", "QEPCTL","QPOSCTL","QCAPCTL","QPOSCNT","QPOSINIT",
                                "QPOSMAX","QPOSCMP","QPOSILAT","QPOSSLAT",
                                "QPOSLAT","QUTMR","QUPRD","QWDTMR",
                                "QWDPRD","QEINT","QFLG","QCLR",
                                "QFRC","QEPSTS","QCTMR","QCPRD","QCTMRLAT","QCPRDLAT"};
            foreach (var item in list_eQEP)
            {
                regs.Add(new Regs(item, RegCategoly.eQEP));
            }

            string[] list_ADC = { "ADCTRL1", "ADCTRL2","ADCTRL3","ADCMAXCONV","ADCASEQSR","ADCST",
                                "ADCCHSELSEQn","ADCRESULTn","ADCREFSEL","ADCOFFTRIM"};
            foreach (var item in list_ADC)
            {
                regs.Add(new Regs(item, RegCategoly.ADC));
            }

            string[] list_SCI = { "SCICCR", "SCICTL1","SCIBAUD","SCICTL2","SCIRXST",
                                "SCIRXEMU","SCIRXBUF","SCITXBUF","SCIFFTX",
                                "SCIFFRX","SCIFFCT","SCIPRI"};
            foreach (var item in list_SCI)
            {
                regs.Add(new Regs(item, RegCategoly.SCI));
            }

            string[] list_SPI = { "SPICCR", "SPICTL","SPISTS","SPIBRR","SPIRXEMU",
                                "SPIRXBUF","SPITXBUF","SPIDAT","SPIFFTX",
                                "SPIFFRX","SPIPRI"};
            foreach (var item in list_SPI)
            {
                regs.Add(new Regs(item, RegCategoly.SPI));
            }


            regs.Add(new Regs("TIMERxTIM", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTIM", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTIM", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTIM", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTIM", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTIM", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTIM", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTIM", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTIM", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTIM", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTIM", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTIM", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTIM", RegCategoly.CPUTimer));
            regs.Add(new Regs("TIMERxTIM", RegCategoly.CPUTimer));


            return sounds;
        }

        public static void GetAllSounds(ObservableCollection<SoundsItem> sounds)
        {
            var allsounds = GetSounds();
            sounds.Clear();
            allsounds.ForEach(p => sounds.Add(p));
        }
    }
}

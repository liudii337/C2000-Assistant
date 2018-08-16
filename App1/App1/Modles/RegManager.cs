using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


            string[] list_eQEP = { "QDECCTL", "QEPCTL","QPOSCTL","QCAPCTL","QPOSCNT","QPOSINIT",
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

            string[] list_CAN = { "MSGCTRL", "MSGID","CANME","CANMD","CANTRS","CANTRR",
                                "CANTA","CANAA","CANRMP","CANRML",
                                "CANRFP","CANGAM","CANMC","CANBTC",
                                "CANES","CANTEC","CANREC","CANGIF0",
                                "CANGIF1","CANGIM","CANMIM","CANMIL","CANOPC","CANTIOC",
                                "CANRIOC","CANTSC","MOTS","MOTO","CANTOC","CANTOS"};
            foreach (var item in list_CAN)
            {
                regs.Add(new Regs(item, RegCategoly.CAN));
            }

            string[] list_McBsp = { "MFFTX", "MFFRX","MFFCT","MFFINT","MFFST","DRR",
                                "DXR","SPCR1",
                                "SPCR2","PCR","RCR1","RCR2",
                                "XCR1","XCR2","SRGR1","SRGR2",
                                "MCR1","MCR2","RCER","XCER"};
            foreach (var item in list_McBsp)
            {
                regs.Add(new Regs(item, RegCategoly.McBSP));
            }

            string[] list_XINTF = { "XTIMING", "XINTCNF2","XBANK","XREVISION","XRESET"};
            foreach (var item in list_XINTF)
            {
                regs.Add(new Regs(item, RegCategoly.XINTF));
            }

            string[] list_DMA = { "DMACTRL", "DEBUGCTRL", "REVISION", "PRIORITYCTRL1", "PRIORITYSTAT",
                                "MODE", "CONTROL", "BURST_SIZE", "BURST_COUNT", "SRC_BURST_STEP",
                                "DST_BURST_STEP", "TRANSFER_SIZE", "TRANSFER_COUNT", "SRC_TRANSFER_STEP", "DST_TRANSFER_STEP",
                                "SRCDST_WRAP_SIZE", "SRCDST_WRAP_COUNT", "SRCDST_WRAP_STEP"};
            foreach (var item in list_DMA)
            {
                regs.Add(new Regs(item, RegCategoly.DMA));
            }

            string[] list_I2C = { "I2CMDR", "I2CEMDR", "I2CIER", "I2CSTR", "I2CISRC",
                                "I2CPSC", "I2CCLKL", "I2CCLKH", "I2CSAR", "I2COAR",
                                "I2CCNT", "I2CDRR", "I2CDXR", "I2CFFTX", "I2CFFRX"};
            foreach (var item in list_I2C)
            {
                regs.Add(new Regs(item, RegCategoly.I2C));
            }


            return regs;
        }

        public static void GetAllRegs(ObservableCollection<Regs> regs)
        {
            var allregs = GetRegs();
            regs.Clear();
            allregs.ForEach(p => regs.Add(p));
        }

        public static void GetRegByCategory(ObservableCollection<Regs> regs,RegCategoly regCategoly)
        {
            var allregs = GetRegs();
            var fillteredRegs = allregs.Where(p => p.Categoly == regCategoly).ToList();
            regs.Clear();
            fillteredRegs.ForEach(p => regs.Add(p));
        }
    }
}

using System.Collections.Generic;

namespace Models
{
    public class PeriodicElement
    {
        public Element? Element { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public string GroupColor(string groupName)
        {
            if (groupName == "Alkali metal")
            {
                return "#CC8587"; // old rose
            }
            else if (groupName == "Alkaline earth metal")
            {
                return "#FFA000"; // orange peel
            }
            else if (groupName == "Transition metal")
            {
                return "#D8D8FF"; // periwinkle
            }
            else if (groupName == "Post-transition metal")
            {
                return "#D0F0C0"; // tea green
            }
            else if (groupName == "Metalloid")
            {
                return "#FF96D1"; // persian pink
            }
            else if (groupName == "Nonmetal")
            {
                return "#95E1FF"; // pale azure
            }
            else if (groupName == "Halogen")
            {
                return "#FFCC75"; // sunset
            }
            else if (groupName == "Noble gas")
            {
                return "#FFEB7B"; // maize
            }
            else if (groupName == "Lanthanide")
            {
                return "#C6E9FD"; // columbia blue
            }
            else if (groupName == "Actinide")
            {
                return "#FFDAE0"; // mimi pink
            }
            else
            {
                return "#FFFFFF";
            }
        }
    }

    public class Element
    {
        public string AtomicNumber { get; set; } = "";
        public string Symbol { get; set; } = "";
        public string Name { get; set; } = "";
        public string AtomicMass { get; set; } = "";
        public string CPKHexColor { get; set; } = "";
        public string ElectronConfiguration { get; set; } = "";
        public string Electronegativity { get; set; } = "";
        public string AtomicRadius { get; set; } = "";
        public string IonizationEnergy { get; set; } = "";
        public string ElectronAffinity { get; set; } = "";
        public List<string> OxidationStates { get; set; } = new List<string>();
        public string StandardState { get; set; } = "";
        public string MeltingPoint { get; set; } = "";
        public string BoilingPoint { get; set; } = "";
        public string Density { get; set; } = "";
        public string GroupBlock { get; set; } = "";
        public string YearDiscovered { get; set; } = "";

        // Grid Placement
        /*public int Row { get; set; } = 0;
        public int Column { get; set; } = 0;

        public override string ToString()
        {
            string oxidationStates = string.Join(",", OxidationStates);
            return $"Atomic Number: {AtomicNumber}\nSymbol: {Symbol}\nName: {Name}\nAtomic Mass: {AtomicMass}\nColor: {ElementColor}\nElectron Configuration: {ElectronConfiguration}\nElectronegativity: {Electronegativity}\nAtomic Radius: {AtomicRadius}\nIonization Energy: {IonizationEnergy}\nElectron Affinity: {ElectionAffinity}\nOxidation States: {oxidationStates}\nStandard State: {StandardState}\nMelting Point: {MeltingPoint}\nBoiling Point: {BoilingPoint}\nDensity: {Density}\nGroup Block: {GroupBlock}\nYear Discovered: {YearDiscovered}";
        }*/
    }
}
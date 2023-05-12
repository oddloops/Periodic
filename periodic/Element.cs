using System.Collections.Generic;

public class PeriodicElement
{
    public Element? Element { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
}

public class Element {
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
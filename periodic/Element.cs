using System.Collections.Generic;

public class Element {
    public int AtomicNumber { get; set; }
    public string Symbol { get; set; } = "";
    public string Name { get; set; } = "";
    public float AtomicMass { get; set; } 
    public string color { get; set; } = "";
    public string ElectronConfiguration { get; set; } = "";
    public float ElectroNegativity { get; set; }
    public int AtomicRadius { get; set; }
    public float IonizationEnergy { get; set; }
    public float ElectionAffinity { get; set; }
    public List<string> OxidationStates { get; set; } = new List<string>();
    public string? StandardState { get; set; }
    public float MeltingPoint { get; set; }
    public float BoilingPoint { get; set; }
    public double Density { get; set; }
    public string GroupBlock { get; set; } = "";
    public int YearDiscovered { get; set; }
    
    // Grid Placement
    public int Row { get; set; }
    public int Column { get; set; }

    public override string ToString()
    {
        string oxidationStates = string.Join(",", OxidationStates);
        return $"Atomic Number: {AtomicNumber}\nSymbol: {Symbol}\nName: {Name}\nAtomic Mass: {AtomicMass}\nColor: {color}\nElectron Configuration: {ElectronConfiguration}\nElectronegativity: {ElectroNegativity}\nAtomic Radius: {AtomicRadius}\nIonization Energy: {IonizationEnergy}\nElectron Affinity: {ElectionAffinity}\nOxidation States: {oxidationStates}\nStandard State: {StandardState}\nMelting Point: {MeltingPoint}\nBoiling Point: {BoilingPoint}\nDensity: {Density}\nGroup Block: {GroupBlock}\nYear Discovered: {YearDiscovered}";
    }

}
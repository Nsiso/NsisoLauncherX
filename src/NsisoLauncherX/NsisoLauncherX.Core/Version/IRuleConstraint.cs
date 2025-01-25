namespace NsisoLauncherX.Core.Version;

public interface IRuleConstraint
{
    public bool CheckIsEnable(Dictionary<string, bool>? givenFeatures);
}